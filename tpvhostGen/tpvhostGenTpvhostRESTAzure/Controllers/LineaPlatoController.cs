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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_LineaPlatoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/LineaPlato")]
public class LineaPlatoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/LineaPlato/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        LineaPlatoRESTCAD lineaPlatoRESTCAD = null;
        LineaPlatoCEN lineaPlatoCEN = null;

        List<LineaPlatoEN> lineaPlatoEN = null;
        List<LineaPlatoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                lineaPlatoRESTCAD = new LineaPlatoRESTCAD (session);
                lineaPlatoCEN = new LineaPlatoCEN (lineaPlatoRESTCAD);

                // Data
                // TODO: paginación

                lineaPlatoEN = lineaPlatoCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (lineaPlatoEN != null) {
                        returnValue = new List<LineaPlatoDTOA>();
                        foreach (LineaPlatoEN entry in lineaPlatoEN)
                                returnValue.Add (LineaPlatoAssembler.Convert (entry, session));
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





[Route ("~/api/LineaPlato/GetAllLineaPlatoByPlato")]

public HttpResponseMessage GetAllLineaPlatoByPlato (int idPlato)
{
        // CAD, EN
        PlatoRESTCAD platoRESTCAD = null;
        PlatoEN platoEN = null;

        // returnValue
        List<LineaPlatoEN> en = null;
        List<LineaPlatoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);

                // Exists Plato
                platoEN = platoRESTCAD.ReadOIDDefault (idPlato);
                if (platoEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Plato#" + idPlato + " not found"));

                // Rol
                // TODO: paginación


                en = platoRESTCAD.GetAllLineaPlatoByPlato (idPlato).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<LineaPlatoDTOA>();
                        foreach (LineaPlatoEN entry in en)
                                returnValue.Add (LineaPlatoAssembler.Convert (entry, session));
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
// [Route("{idLineaPlato}", Name="GetOIDLineaPlato")]

[Route ("~/api/LineaPlato/{idLineaPlato}")]

public HttpResponseMessage ReadOID (int idLineaPlato)
{
        // CAD, CEN, EN, returnValue
        LineaPlatoRESTCAD lineaPlatoRESTCAD = null;
        LineaPlatoCEN lineaPlatoCEN = null;
        LineaPlatoEN lineaPlatoEN = null;
        LineaPlatoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                lineaPlatoRESTCAD = new LineaPlatoRESTCAD (session);
                lineaPlatoCEN = new LineaPlatoCEN (lineaPlatoRESTCAD);

                // Data
                lineaPlatoEN = lineaPlatoCEN.ReadOID (idLineaPlato);

                // Convert return
                if (lineaPlatoEN != null) {
                        returnValue = LineaPlatoAssembler.Convert (lineaPlatoEN, session);
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


[Route ("~/api/LineaPlato/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] LineaPlatoDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        LineaPlatoRESTCAD lineaPlatoRESTCAD = null;
        LineaPlatoCEN lineaPlatoCEN = null;
        LineaPlatoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                lineaPlatoRESTCAD = new LineaPlatoRESTCAD (session);
                lineaPlatoCEN = new LineaPlatoCEN (lineaPlatoRESTCAD);

                // Create
                returnOID = lineaPlatoCEN.Nuevo (
                        dto.Cantidad                                                                             //Atributo Primitivo: p_cantidad
                        ,
                        //Atributo OID: p_producto
                        // attr.estaRelacionado: true
                        dto.Producto_oid                 // association role

                        ,
                        //Atributo OID: p_plato
                        // attr.estaRelacionado: true
                        dto.Plato_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = LineaPlatoAssembler.Convert (lineaPlatoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDLineaPlato", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/LineaPlato/Modificar")]

public HttpResponseMessage Modificar (int idLineaPlato, [FromBody] LineaPlatoDTO dto)
{
        // CAD, CEN, returnValue
        LineaPlatoRESTCAD lineaPlatoRESTCAD = null;
        LineaPlatoCEN lineaPlatoCEN = null;
        LineaPlatoDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                lineaPlatoRESTCAD = new LineaPlatoRESTCAD (session);
                lineaPlatoCEN = new LineaPlatoCEN (lineaPlatoRESTCAD);

                // Modify
                lineaPlatoCEN.Modificar (idLineaPlato,
                        dto.Cantidad
                        );

                // Return modified object
                returnValue = LineaPlatoAssembler.Convert (lineaPlatoRESTCAD.ReadOIDDefault (idLineaPlato), session);

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


[Route ("~/api/LineaPlato/Eliminar")]

public HttpResponseMessage Eliminar (int p_lineaplato_oid)
{
        // CAD, CEN
        LineaPlatoRESTCAD lineaPlatoRESTCAD = null;
        LineaPlatoCEN lineaPlatoCEN = null;

        try
        {
                SessionInitializeTransaction ();


                lineaPlatoRESTCAD = new LineaPlatoRESTCAD (session);
                lineaPlatoCEN = new LineaPlatoCEN (lineaPlatoRESTCAD);

                lineaPlatoCEN.Eliminar (p_lineaplato_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_LineaPlatoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
