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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_ProductoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Producto")]
public class ProductoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Producto/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        ProductoRESTCAD productoRESTCAD = null;
        ProductoCEN productoCEN = null;

        List<ProductoEN> productoEN = null;
        List<ProductoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                productoRESTCAD = new ProductoRESTCAD (session);
                productoCEN = new ProductoCEN (productoRESTCAD);

                // Data
                // TODO: paginación

                productoEN = productoCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (productoEN != null) {
                        returnValue = new List<ProductoDTOA>();
                        foreach (ProductoEN entry in productoEN)
                                returnValue.Add (ProductoAssembler.Convert (entry, session));
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





[Route ("~/api/Producto/GetAllProductoByNegocio")]

public HttpResponseMessage GetAllProductoByNegocio (int idNegocio)
{
        // CAD, EN
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioEN negocioEN = null;

        // returnValue
        List<ProductoEN> en = null;
        List<ProductoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);

                // Exists Negocio
                negocioEN = negocioRESTCAD.ReadOIDDefault (idNegocio);
                if (negocioEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Negocio#" + idNegocio + " not found"));

                // Rol
                // TODO: paginación


                en = negocioRESTCAD.GetAllProductoByNegocio (idNegocio).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<ProductoDTOA>();
                        foreach (ProductoEN entry in en)
                                returnValue.Add (ProductoAssembler.Convert (entry, session));
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





[Route ("~/api/Producto/GetAllProductoOfUnidadMedida")]

public HttpResponseMessage GetAllProductoOfUnidadMedida (int idUnidadMedida)
{
        // CAD, EN
        UnidadMedidaRESTCAD unidadMedidaRESTCAD = null;
        UnidadMedidaEN unidadMedidaEN = null;

        // returnValue
        List<ProductoEN> en = null;
        List<ProductoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                unidadMedidaRESTCAD = new UnidadMedidaRESTCAD (session);

                // Exists UnidadMedida
                unidadMedidaEN = unidadMedidaRESTCAD.ReadOIDDefault (idUnidadMedida);
                if (unidadMedidaEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "UnidadMedida#" + idUnidadMedida + " not found"));

                // Rol
                // TODO: paginación


                en = unidadMedidaRESTCAD.GetAllProductoOfUnidadMedida (idUnidadMedida).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<ProductoDTOA>();
                        foreach (ProductoEN entry in en)
                                returnValue.Add (ProductoAssembler.Convert (entry, session));
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
// [Route("{idProducto}", Name="GetOIDProducto")]

[Route ("~/api/Producto/{idProducto}")]

public HttpResponseMessage ReadOID (int idProducto)
{
        // CAD, CEN, EN, returnValue
        ProductoRESTCAD productoRESTCAD = null;
        ProductoCEN productoCEN = null;
        ProductoEN productoEN = null;
        ProductoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                productoRESTCAD = new ProductoRESTCAD (session);
                productoCEN = new ProductoCEN (productoRESTCAD);

                // Data
                productoEN = productoCEN.ReadOID (idProducto);

                // Convert return
                if (productoEN != null) {
                        returnValue = ProductoAssembler.Convert (productoEN, session);
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


[Route ("~/api/Producto/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] ProductoDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        ProductoRESTCAD productoRESTCAD = null;
        ProductoCEN productoCEN = null;
        ProductoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                productoRESTCAD = new ProductoRESTCAD (session);
                productoCEN = new ProductoCEN (productoRESTCAD);

                // Create
                returnOID = productoCEN.Nuevo (

                        //Atributo OID: p_unidadMedida
                        // attr.estaRelacionado: true
                        dto.UnidadMedida_oid                 // association role

                        ,
                        //Atributo OID: p_negocio
                        // attr.estaRelacionado: true
                        dto.Negocio_oid                 // association role

                        , dto.Descripcion                                                                                                                                                //Atributo Primitivo: p_descripcion
                        );
                SessionCommit ();

                // Convert return
                returnValue = ProductoAssembler.Convert (productoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDProducto", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/Producto/Modificar")]

public HttpResponseMessage Modificar (int idProducto, [FromBody] ProductoDTO dto)
{
        // CAD, CEN, returnValue
        ProductoRESTCAD productoRESTCAD = null;
        ProductoCEN productoCEN = null;
        ProductoDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                productoRESTCAD = new ProductoRESTCAD (session);
                productoCEN = new ProductoCEN (productoRESTCAD);

                // Modify
                productoCEN.Modificar (idProducto,
                        dto.Descripcion
                        );

                // Return modified object
                returnValue = ProductoAssembler.Convert (productoRESTCAD.ReadOIDDefault (idProducto), session);

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


[Route ("~/api/Producto/Eliminar")]

public HttpResponseMessage Eliminar (int p_producto_oid)
{
        // CAD, CEN
        ProductoRESTCAD productoRESTCAD = null;
        ProductoCEN productoCEN = null;

        try
        {
                SessionInitializeTransaction ();


                productoRESTCAD = new ProductoRESTCAD (session);
                productoCEN = new ProductoCEN (productoRESTCAD);

                productoCEN.Eliminar (p_producto_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_ProductoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
