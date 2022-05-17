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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_TipoPagoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/TipoPago")]
public class TipoPagoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/TipoPago/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        TipoPagoRESTCAD tipoPagoRESTCAD = null;
        TipoPagoCEN tipoPagoCEN = null;

        List<TipoPagoEN> tipoPagoEN = null;
        List<TipoPagoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                tipoPagoRESTCAD = new TipoPagoRESTCAD (session);
                tipoPagoCEN = new TipoPagoCEN (tipoPagoRESTCAD);

                // Data
                // TODO: paginación

                tipoPagoEN = tipoPagoCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (tipoPagoEN != null) {
                        returnValue = new List<TipoPagoDTOA>();
                        foreach (TipoPagoEN entry in tipoPagoEN)
                                returnValue.Add (TipoPagoAssembler.Convert (entry, session));
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
// [Route("{idTipoPago}", Name="GetOIDTipoPago")]

[Route ("~/api/TipoPago/{idTipoPago}")]

public HttpResponseMessage ReadOID (int idTipoPago)
{
        // CAD, CEN, EN, returnValue
        TipoPagoRESTCAD tipoPagoRESTCAD = null;
        TipoPagoCEN tipoPagoCEN = null;
        TipoPagoEN tipoPagoEN = null;
        TipoPagoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                tipoPagoRESTCAD = new TipoPagoRESTCAD (session);
                tipoPagoCEN = new TipoPagoCEN (tipoPagoRESTCAD);

                // Data
                tipoPagoEN = tipoPagoCEN.ReadOID (idTipoPago);

                // Convert return
                if (tipoPagoEN != null) {
                        returnValue = TipoPagoAssembler.Convert (tipoPagoEN, session);
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


[Route ("~/api/TipoPago/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] TipoPagoDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        TipoPagoRESTCAD tipoPagoRESTCAD = null;
        TipoPagoCEN tipoPagoCEN = null;
        TipoPagoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                tipoPagoRESTCAD = new TipoPagoRESTCAD (session);
                tipoPagoCEN = new TipoPagoCEN (tipoPagoRESTCAD);

                // Create
                returnOID = tipoPagoCEN.Nuevo (
                        dto.Descripcion                                                                          //Atributo Primitivo: p_descripcion
                        );
                SessionCommit ();

                // Convert return
                returnValue = TipoPagoAssembler.Convert (tipoPagoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDTipoPago", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/TipoPago/Modificar")]

public HttpResponseMessage Modificar (int idTipoPago, [FromBody] TipoPagoDTO dto)
{
        // CAD, CEN, returnValue
        TipoPagoRESTCAD tipoPagoRESTCAD = null;
        TipoPagoCEN tipoPagoCEN = null;
        TipoPagoDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                tipoPagoRESTCAD = new TipoPagoRESTCAD (session);
                tipoPagoCEN = new TipoPagoCEN (tipoPagoRESTCAD);

                // Modify
                tipoPagoCEN.Modificar (idTipoPago,
                        dto.Descripcion
                        );

                // Return modified object
                returnValue = TipoPagoAssembler.Convert (tipoPagoRESTCAD.ReadOIDDefault (idTipoPago), session);

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


[Route ("~/api/TipoPago/Eliminar")]

public HttpResponseMessage Eliminar (int p_tipopago_oid)
{
        // CAD, CEN
        TipoPagoRESTCAD tipoPagoRESTCAD = null;
        TipoPagoCEN tipoPagoCEN = null;

        try
        {
                SessionInitializeTransaction ();


                tipoPagoRESTCAD = new TipoPagoRESTCAD (session);
                tipoPagoCEN = new TipoPagoCEN (tipoPagoRESTCAD);

                tipoPagoCEN.Eliminar (p_tipopago_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_TipoPagoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
