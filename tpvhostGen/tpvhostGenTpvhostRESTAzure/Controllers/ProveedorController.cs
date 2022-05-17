using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using tpvhostGenTpvhostRESTAzure.DTO;
using tpvhostGenTpvhostRESTAzure.DTOA;
using tpvhostGenTpvhostRESTAzure.CAD;
using tpvhostGenTpvhostRESTAzure.Assemblers;
using tpvhostGenTpvhostRESTAzure.AssemblersDTO;
using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CEN.Rest;
using TpvhostGenNHibernate.CP.Rest;


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_ProveedorControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Proveedor")]
public class ProveedorController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Proveedor/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        ProveedorRESTCAD proveedorRESTCAD = null;
        ProveedorCEN proveedorCEN = null;

        List<ProveedorEN> proveedorEN = null;
        List<ProveedorDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                proveedorRESTCAD = new ProveedorRESTCAD (session);
                proveedorCEN = new ProveedorCEN (proveedorRESTCAD);

                // Data
                // TODO: paginación

                proveedorEN = proveedorCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (proveedorEN != null) {
                        returnValue = new List<ProveedorDTOA>();
                        foreach (ProveedorEN entry in proveedorEN)
                                returnValue.Add (ProveedorAssembler.Convert (entry, session));
                }
        }

        catch (Exception e)
        {
                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) throw new HttpResponseException (HttpStatusCode.Forbidden);
                else if (e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 204 - Empty
        if (returnValue == null || returnValue.Count == 0)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}









[HttpGet]
// [Route("{idProveedor}", Name="GetOIDProveedor")]

[Route ("~/api/Proveedor/{idProveedor}")]

public HttpResponseMessage ReadOID (int idProveedor)
{
        // CAD, CEN, EN, returnValue
        ProveedorRESTCAD proveedorRESTCAD = null;
        ProveedorCEN proveedorCEN = null;
        ProveedorEN proveedorEN = null;
        ProveedorDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                proveedorRESTCAD = new ProveedorRESTCAD (session);
                proveedorCEN = new ProveedorCEN (proveedorRESTCAD);

                // Data
                proveedorEN = proveedorCEN.ReadOID (idProveedor);

                // Convert return
                if (proveedorEN != null) {
                        returnValue = ProveedorAssembler.Convert (proveedorEN, session);
                }
        }

        catch (Exception e)
        {
                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) throw new HttpResponseException (HttpStatusCode.Forbidden);
                else if (e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 404 - Not found
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NotFound);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}




[HttpPost]


[Route ("~/api/Proveedor/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] ProveedorDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        ProveedorRESTCAD proveedorRESTCAD = null;
        ProveedorCEN proveedorCEN = null;
        ProveedorDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                proveedorRESTCAD = new ProveedorRESTCAD (session);
                proveedorCEN = new ProveedorCEN (proveedorRESTCAD);

                // Create
                returnOID = proveedorCEN.Nuevo (
                        dto.Nombre                                                                               //Atributo Primitivo: p_nombre
                        , dto.NumeroTelefono                                                                                                                                                     //Atributo Primitivo: p_numeroTelefono
                        , dto.Email                                                                                                                                                      //Atributo Primitivo: p_email
                        );
                SessionCommit ();

                // Convert return
                returnValue = ProveedorAssembler.Convert (proveedorRESTCAD.ReadOIDDefault (returnOID), session);
        }

        catch (Exception e)
        {
                SessionRollBack ();

                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) throw new HttpResponseException (HttpStatusCode.Forbidden);
                else if (e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 201 - Created
        response = this.Request.CreateResponse (HttpStatusCode.Created, returnValue);

        // Location Header
        /*
         * Dictionary<string, object> routeValues = new Dictionary<string, object>();
         *
         * // TODO: y rolPaths
         * routeValues.Add("id", returnOID);
         *
         * uri = Url.Link("GetOIDProveedor", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/Proveedor/Modificar")]

public HttpResponseMessage Modificar (int idProveedor, [FromBody] ProveedorDTO dto)
{
        // CAD, CEN, returnValue
        ProveedorRESTCAD proveedorRESTCAD = null;
        ProveedorCEN proveedorCEN = null;
        ProveedorDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                proveedorRESTCAD = new ProveedorRESTCAD (session);
                proveedorCEN = new ProveedorCEN (proveedorRESTCAD);

                // Modify
                proveedorCEN.Modificar (idProveedor,
                        dto.Nombre
                        ,
                        dto.NumeroTelefono
                        ,
                        dto.Email
                        );

                // Return modified object
                returnValue = ProveedorAssembler.Convert (proveedorRESTCAD.ReadOIDDefault (idProveedor), session);

                SessionCommit ();
        }

        catch (Exception e)
        {
                SessionRollBack ();

                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) throw new HttpResponseException (HttpStatusCode.Forbidden);
                else if (e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 404 - Not found
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NotFound);
        // Return 200 - OK
        else{
                response = this.Request.CreateResponse (HttpStatusCode.OK, returnValue);

                return response;
        }
}





[HttpDelete]


[Route ("~/api/Proveedor/Eliminar")]

public HttpResponseMessage Eliminar (int p_proveedor_oid)
{
        // CAD, CEN
        ProveedorRESTCAD proveedorRESTCAD = null;
        ProveedorCEN proveedorCEN = null;

        try
        {
                SessionInitializeTransaction ();


                proveedorRESTCAD = new ProveedorRESTCAD (session);
                proveedorCEN = new ProveedorCEN (proveedorRESTCAD);

                proveedorCEN.Eliminar (p_proveedor_oid);
                SessionCommit ();
        }

        catch (Exception e)
        {
                SessionRollBack ();

                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) throw new HttpResponseException (HttpStatusCode.Forbidden);
                else if (e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(TpvhostGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 204 - No Content
        return this.Request.CreateResponse (HttpStatusCode.NoContent);
}









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_ProveedorControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
