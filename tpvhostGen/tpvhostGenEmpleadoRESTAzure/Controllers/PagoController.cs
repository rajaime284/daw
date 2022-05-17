using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using tpvhostGenEmpleadoRESTAzure.DTO;
using tpvhostGenEmpleadoRESTAzure.DTOA;
using tpvhostGenEmpleadoRESTAzure.CAD;
using tpvhostGenEmpleadoRESTAzure.Assemblers;
using tpvhostGenEmpleadoRESTAzure.AssemblersDTO;
using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CEN.Rest;
using TpvhostGenNHibernate.CP.Rest;


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_PagoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/Pago")]
public class PagoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Pago/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        PagoRESTCAD pagoRESTCAD = null;
        CobroCEN cobroCEN = null;

        List<CobroEN> cobroEN = null;
        List<PagoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                pagoRESTCAD = new PagoRESTCAD (session);
                cobroCEN = new CobroCEN (pagoRESTCAD);

                // Data
                // TODO: paginación

                cobroEN = cobroCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (cobroEN != null) {
                        returnValue = new List<PagoDTOA>();
                        foreach (CobroEN entry in cobroEN)
                                returnValue.Add (PagoAssembler.Convert (entry, session));
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
// [Route("{idPago}", Name="GetOIDPago")]

[Route ("~/api/Pago/{idPago}")]

public HttpResponseMessage ReadOID (int idPago)
{
        // CAD, CEN, EN, returnValue
        PagoRESTCAD pagoRESTCAD = null;
        CobroCEN cobroCEN = null;
        CobroEN cobroEN = null;
        PagoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                pagoRESTCAD = new PagoRESTCAD (session);
                cobroCEN = new CobroCEN (pagoRESTCAD);

                // Data
                cobroEN = cobroCEN.ReadOID (idPago);

                // Convert return
                if (cobroEN != null) {
                        returnValue = PagoAssembler.Convert (cobroEN, session);
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


[Route ("~/api/Pago/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] CobroDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        PagoRESTCAD pagoRESTCAD = null;
        CobroCEN cobroCEN = null;
        PagoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                pagoRESTCAD = new PagoRESTCAD (session);
                cobroCEN = new CobroCEN (pagoRESTCAD);

                // Create
                returnOID = cobroCEN.Nuevo (
                        dto.Monto                                                                                //Atributo Primitivo: p_monto
                        ,
                        //Atributo OID: p_comanda
                        // attr.estaRelacionado: true
                        dto.Comanda_oid                 // association role

                        ,
                        //Atributo OID: p_cliente
                        // attr.estaRelacionado: true
                        dto.Cliente_oid                 // association role

                        , dto.TipoDeCobro                                                                                                                                                //Atributo Primitivo: p_tipoDeCobro
                        ,
                        //Atributo OID: p_tipoCobro
                        // attr.estaRelacionado: true
                        dto.TipoCobro_oid                 // association role

                        , dto.NumeroTransaccion                                                                                                                                                  //Atributo Primitivo: p_numeroTransaccion
                        );
                SessionCommit ();

                // Convert return
                returnValue = PagoAssembler.Convert (pagoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDPago", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}


















/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_PagoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
