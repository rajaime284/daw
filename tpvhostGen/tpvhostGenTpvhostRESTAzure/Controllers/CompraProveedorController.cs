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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_CompraProveedorControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/CompraProveedor")]
public class CompraProveedorController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/CompraProveedor/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        CompraProveedorRESTCAD compraProveedorRESTCAD = null;
        CompraProveedorCEN compraProveedorCEN = null;

        List<CompraProveedorEN> compraProveedorEN = null;
        List<CompraProveedorDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                compraProveedorRESTCAD = new CompraProveedorRESTCAD (session);
                compraProveedorCEN = new CompraProveedorCEN (compraProveedorRESTCAD);

                // Data
                // TODO: paginación

                compraProveedorEN = compraProveedorCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (compraProveedorEN != null) {
                        returnValue = new List<CompraProveedorDTOA>();
                        foreach (CompraProveedorEN entry in compraProveedorEN)
                                returnValue.Add (CompraProveedorAssembler.Convert (entry, session));
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





[Route ("~/api/CompraProveedor/GetAllCompraProveedorByProveedor")]

public HttpResponseMessage GetAllCompraProveedorByProveedor (int idProveedor)
{
        // CAD, EN
        ProveedorRESTCAD proveedorRESTCAD = null;
        ProveedorEN proveedorEN = null;

        // returnValue
        List<CompraProveedorEN> en = null;
        List<CompraProveedorDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                proveedorRESTCAD = new ProveedorRESTCAD (session);

                // Exists Proveedor
                proveedorEN = proveedorRESTCAD.ReadOIDDefault (idProveedor);
                if (proveedorEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Proveedor#" + idProveedor + " not found"));

                // Rol
                // TODO: paginación


                en = proveedorRESTCAD.GetAllCompraProveedorByProveedor (idProveedor).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<CompraProveedorDTOA>();
                        foreach (CompraProveedorEN entry in en)
                                returnValue.Add (CompraProveedorAssembler.Convert (entry, session));
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
// [Route("{idCompraProveedor}", Name="GetOIDCompraProveedor")]

[Route ("~/api/CompraProveedor/{idCompraProveedor}")]

public HttpResponseMessage ReadOID (int idCompraProveedor)
{
        // CAD, CEN, EN, returnValue
        CompraProveedorRESTCAD compraProveedorRESTCAD = null;
        CompraProveedorCEN compraProveedorCEN = null;
        CompraProveedorEN compraProveedorEN = null;
        CompraProveedorDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                compraProveedorRESTCAD = new CompraProveedorRESTCAD (session);
                compraProveedorCEN = new CompraProveedorCEN (compraProveedorRESTCAD);

                // Data
                compraProveedorEN = compraProveedorCEN.ReadOID (idCompraProveedor);

                // Convert return
                if (compraProveedorEN != null) {
                        returnValue = CompraProveedorAssembler.Convert (compraProveedorEN, session);
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


[Route ("~/api/CompraProveedor/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] CompraProveedorDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        CompraProveedorRESTCAD compraProveedorRESTCAD = null;
        CompraProveedorCEN compraProveedorCEN = null;
        CompraProveedorDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                compraProveedorRESTCAD = new CompraProveedorRESTCAD (session);
                compraProveedorCEN = new CompraProveedorCEN (compraProveedorRESTCAD);

                // Create
                returnOID = compraProveedorCEN.Nuevo (
                        LineaCompraProveedorAssemblerDTO.ConvertList (dto.LineaCompraProveedor)
                        //Atributo Object: p_lineaCompraProveedor
                        ,
                        //Atributo OID: p_proveedor
                        // attr.estaRelacionado: true
                        dto.Proveedor_oid                 // association role

                        ,
                        //Atributo OID: p_negocio
                        // attr.estaRelacionado: true
                        dto.Negocio_oid                 // association role

                        , dto.EstadoCompra                                                                                                                                                       //Atributo Primitivo: p_estadoCompra
                        , dto.Fecha                                                                                                                                                      //Atributo Primitivo: p_fecha
                        );
                SessionCommit ();

                // Convert return
                returnValue = CompraProveedorAssembler.Convert (compraProveedorRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDCompraProveedor", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/CompraProveedor/Modificar")]

public HttpResponseMessage Modificar (int idCompraProveedor, [FromBody] CompraProveedorDTO dto)
{
        // CAD, CEN, returnValue
        CompraProveedorRESTCAD compraProveedorRESTCAD = null;
        CompraProveedorCEN compraProveedorCEN = null;
        CompraProveedorDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                compraProveedorRESTCAD = new CompraProveedorRESTCAD (session);
                compraProveedorCEN = new CompraProveedorCEN (compraProveedorRESTCAD);

                // Modify
                compraProveedorCEN.Modificar (idCompraProveedor,
                        dto.EstadoCompra
                        ,
                        dto.Fecha
                        );

                // Return modified object
                returnValue = CompraProveedorAssembler.Convert (compraProveedorRESTCAD.ReadOIDDefault (idCompraProveedor), session);

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


[Route ("~/api/CompraProveedor/Eliminar")]

public HttpResponseMessage Eliminar (int p_compraproveedor_oid)
{
        // CAD, CEN
        CompraProveedorRESTCAD compraProveedorRESTCAD = null;
        CompraProveedorCEN compraProveedorCEN = null;

        try
        {
                SessionInitializeTransaction ();


                compraProveedorRESTCAD = new CompraProveedorRESTCAD (session);
                compraProveedorCEN = new CompraProveedorCEN (compraProveedorRESTCAD);

                compraProveedorCEN.Eliminar (p_compraproveedor_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_CompraProveedorControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
