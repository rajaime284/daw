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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_LineaCompraProveedorControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/LineaCompraProveedor")]
public class LineaCompraProveedorController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/LineaCompraProveedor/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        LineaCompraProveedorRESTCAD lineaCompraProveedorRESTCAD = null;
        LineaCompraProveedorCEN lineaCompraProveedorCEN = null;

        List<LineaCompraProveedorEN> lineaCompraProveedorEN = null;
        List<LineaCompraProveedorDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                lineaCompraProveedorRESTCAD = new LineaCompraProveedorRESTCAD (session);
                lineaCompraProveedorCEN = new LineaCompraProveedorCEN (lineaCompraProveedorRESTCAD);

                // Data
                // TODO: paginación

                lineaCompraProveedorEN = lineaCompraProveedorCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (lineaCompraProveedorEN != null) {
                        returnValue = new List<LineaCompraProveedorDTOA>();
                        foreach (LineaCompraProveedorEN entry in lineaCompraProveedorEN)
                                returnValue.Add (LineaCompraProveedorAssembler.Convert (entry, session));
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
// [Route("{idLineaCompraProveedor}", Name="GetOIDLineaCompraProveedor")]

[Route ("~/api/LineaCompraProveedor/{idLineaCompraProveedor}")]

public HttpResponseMessage ReadOID (int idLineaCompraProveedor)
{
        // CAD, CEN, EN, returnValue
        LineaCompraProveedorRESTCAD lineaCompraProveedorRESTCAD = null;
        LineaCompraProveedorCEN lineaCompraProveedorCEN = null;
        LineaCompraProveedorEN lineaCompraProveedorEN = null;
        LineaCompraProveedorDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                lineaCompraProveedorRESTCAD = new LineaCompraProveedorRESTCAD (session);
                lineaCompraProveedorCEN = new LineaCompraProveedorCEN (lineaCompraProveedorRESTCAD);

                // Data
                lineaCompraProveedorEN = lineaCompraProveedorCEN.ReadOID (idLineaCompraProveedor);

                // Convert return
                if (lineaCompraProveedorEN != null) {
                        returnValue = LineaCompraProveedorAssembler.Convert (lineaCompraProveedorEN, session);
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


[Route ("~/api/LineaCompraProveedor/NuevaLineaServicio")]




public HttpResponseMessage NuevaLineaServicio ( [FromBody] LineaCompraProveedorDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        LineaCompraProveedorRESTCAD lineaCompraProveedorRESTCAD = null;
        LineaCompraProveedorCEN lineaCompraProveedorCEN = null;
        LineaCompraProveedorDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                lineaCompraProveedorRESTCAD = new LineaCompraProveedorRESTCAD (session);
                lineaCompraProveedorCEN = new LineaCompraProveedorCEN (lineaCompraProveedorRESTCAD);

                // Create
                returnOID = lineaCompraProveedorCEN.NuevaLineaServicio (
                        dto.Cantidad                                                                             //Atributo Primitivo: p_cantidad
                        ,
                        //Atributo OID: p_servicio
                        // attr.estaRelacionado: true
                        dto.Servicio_oid                 // association role

                        ,
                        //Atributo OID: p_compraProveedor
                        // attr.estaRelacionado: true
                        dto.CompraProveedor_oid                 // association role

                        ,
                        //Atributo OID: p_producto
                        // attr.estaRelacionado: true
                        dto.Producto_oid                 // association role

                        , dto.Costo                                                                                                                                                      //Atributo Primitivo: p_Costo
                        );
                SessionCommit ();

                // Convert return
                returnValue = LineaCompraProveedorAssembler.Convert (lineaCompraProveedorRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDLineaCompraProveedor", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/LineaCompraProveedor/Modificar")]

public HttpResponseMessage Modificar (int idLineaCompraProveedor, [FromBody] LineaCompraProveedorDTO dto)
{
        // CAD, CEN, returnValue
        LineaCompraProveedorRESTCAD lineaCompraProveedorRESTCAD = null;
        LineaCompraProveedorCEN lineaCompraProveedorCEN = null;
        LineaCompraProveedorDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                lineaCompraProveedorRESTCAD = new LineaCompraProveedorRESTCAD (session);
                lineaCompraProveedorCEN = new LineaCompraProveedorCEN (lineaCompraProveedorRESTCAD);

                // Modify
                lineaCompraProveedorCEN.Modificar (idLineaCompraProveedor,
                        dto.Cantidad
                        ,
                        dto.Costo
                        );

                // Return modified object
                returnValue = LineaCompraProveedorAssembler.Convert (lineaCompraProveedorRESTCAD.ReadOIDDefault (idLineaCompraProveedor), session);

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


[Route ("~/api/LineaCompraProveedor/Eliminar")]

public HttpResponseMessage Eliminar (int p_lineacompraproveedor_oid)
{
        // CAD, CEN
        LineaCompraProveedorRESTCAD lineaCompraProveedorRESTCAD = null;
        LineaCompraProveedorCEN lineaCompraProveedorCEN = null;

        try
        {
                SessionInitializeTransaction ();


                lineaCompraProveedorRESTCAD = new LineaCompraProveedorRESTCAD (session);
                lineaCompraProveedorCEN = new LineaCompraProveedorCEN (lineaCompraProveedorRESTCAD);

                lineaCompraProveedorCEN.Eliminar (p_lineacompraproveedor_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_LineaCompraProveedorControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
