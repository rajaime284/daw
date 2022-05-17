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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_UnidadMedidaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/UnidadMedida")]
public class UnidadMedidaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/UnidadMedida/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        UnidadMedidaRESTCAD unidadMedidaRESTCAD = null;
        UnidadMedidaCEN unidadMedidaCEN = null;

        List<UnidadMedidaEN> unidadMedidaEN = null;
        List<UnidadMedidaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                unidadMedidaRESTCAD = new UnidadMedidaRESTCAD (session);
                unidadMedidaCEN = new UnidadMedidaCEN (unidadMedidaRESTCAD);

                // Data
                // TODO: paginación

                unidadMedidaEN = unidadMedidaCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (unidadMedidaEN != null) {
                        returnValue = new List<UnidadMedidaDTOA>();
                        foreach (UnidadMedidaEN entry in unidadMedidaEN)
                                returnValue.Add (UnidadMedidaAssembler.Convert (entry, session));
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





[Route ("~/api/UnidadMedida/GetUnidadMedidaByProducto")]

public HttpResponseMessage GetUnidadMedidaByProducto (int idProducto)
{
        // CAD, EN
        ProductoRESTCAD productoRESTCAD = null;
        ProductoEN productoEN = null;

        // returnValue
        UnidadMedidaEN en = null;
        UnidadMedidaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                productoRESTCAD = new ProductoRESTCAD (session);

                // Exists Producto
                productoEN = productoRESTCAD.ReadOIDDefault (idProducto);
                if (productoEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Producto#" + idProducto + " not found"));

                // Rol
                // TODO: paginación


                en = productoRESTCAD.GetUnidadMedidaByProducto (idProducto);



                // Convert return
                if (en != null) {
                        returnValue = UnidadMedidaAssembler.Convert (en, session);
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
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}







[HttpGet]
// [Route("{idUnidadMedida}", Name="GetOIDUnidadMedida")]

[Route ("~/api/UnidadMedida/{idUnidadMedida}")]

public HttpResponseMessage ReadOID (int idUnidadMedida)
{
        // CAD, CEN, EN, returnValue
        UnidadMedidaRESTCAD unidadMedidaRESTCAD = null;
        UnidadMedidaCEN unidadMedidaCEN = null;
        UnidadMedidaEN unidadMedidaEN = null;
        UnidadMedidaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                unidadMedidaRESTCAD = new UnidadMedidaRESTCAD (session);
                unidadMedidaCEN = new UnidadMedidaCEN (unidadMedidaRESTCAD);

                // Data
                unidadMedidaEN = unidadMedidaCEN.ReadOID (idUnidadMedida);

                // Convert return
                if (unidadMedidaEN != null) {
                        returnValue = UnidadMedidaAssembler.Convert (unidadMedidaEN, session);
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


[Route ("~/api/UnidadMedida/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] UnidadMedidaDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        UnidadMedidaRESTCAD unidadMedidaRESTCAD = null;
        UnidadMedidaCEN unidadMedidaCEN = null;
        UnidadMedidaDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                unidadMedidaRESTCAD = new UnidadMedidaRESTCAD (session);
                unidadMedidaCEN = new UnidadMedidaCEN (unidadMedidaRESTCAD);

                // Create
                returnOID = unidadMedidaCEN.Nuevo (
                        dto.Descripcion                                                                          //Atributo Primitivo: p_descripcion
                        );
                SessionCommit ();

                // Convert return
                returnValue = UnidadMedidaAssembler.Convert (unidadMedidaRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDUnidadMedida", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/UnidadMedida/Modificar")]

public HttpResponseMessage Modificar (int idUnidadMedida, [FromBody] UnidadMedidaDTO dto)
{
        // CAD, CEN, returnValue
        UnidadMedidaRESTCAD unidadMedidaRESTCAD = null;
        UnidadMedidaCEN unidadMedidaCEN = null;
        UnidadMedidaDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                unidadMedidaRESTCAD = new UnidadMedidaRESTCAD (session);
                unidadMedidaCEN = new UnidadMedidaCEN (unidadMedidaRESTCAD);

                // Modify
                unidadMedidaCEN.Modificar (idUnidadMedida,
                        dto.Descripcion
                        );

                // Return modified object
                returnValue = UnidadMedidaAssembler.Convert (unidadMedidaRESTCAD.ReadOIDDefault (idUnidadMedida), session);

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


[Route ("~/api/UnidadMedida/Eliminar")]

public HttpResponseMessage Eliminar (int p_unidadmedida_oid)
{
        // CAD, CEN
        UnidadMedidaRESTCAD unidadMedidaRESTCAD = null;
        UnidadMedidaCEN unidadMedidaCEN = null;

        try
        {
                SessionInitializeTransaction ();


                unidadMedidaRESTCAD = new UnidadMedidaRESTCAD (session);
                unidadMedidaCEN = new UnidadMedidaCEN (unidadMedidaRESTCAD);

                unidadMedidaCEN.Eliminar (p_unidadmedida_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_UnidadMedidaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
