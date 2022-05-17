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


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_LineaPedidoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/LineaPedido")]
public class LineaPedidoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/LineaPedido/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        LineaPedidoRESTCAD lineaPedidoRESTCAD = null;
        LineaComandaCEN lineaComandaCEN = null;

        List<LineaComandaEN> lineaComandaEN = null;
        List<LineaPedidoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                lineaPedidoRESTCAD = new LineaPedidoRESTCAD (session);
                lineaComandaCEN = new LineaComandaCEN (lineaPedidoRESTCAD);

                // Data
                // TODO: paginación

                lineaComandaEN = lineaComandaCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (lineaComandaEN != null) {
                        returnValue = new List<LineaPedidoDTOA>();
                        foreach (LineaComandaEN entry in lineaComandaEN)
                                returnValue.Add (LineaPedidoAssembler.Convert (entry, session));
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
// [Route("{idLineaPedido}", Name="GetOIDLineaPedido")]

[Route ("~/api/LineaPedido/{idLineaPedido}")]

public HttpResponseMessage ReadOID (int idLineaPedido)
{
        // CAD, CEN, EN, returnValue
        LineaPedidoRESTCAD lineaPedidoRESTCAD = null;
        LineaComandaCEN lineaComandaCEN = null;
        LineaComandaEN lineaComandaEN = null;
        LineaPedidoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                lineaPedidoRESTCAD = new LineaPedidoRESTCAD (session);
                lineaComandaCEN = new LineaComandaCEN (lineaPedidoRESTCAD);

                // Data
                lineaComandaEN = lineaComandaCEN.ReadOID (idLineaPedido);

                // Convert return
                if (lineaComandaEN != null) {
                        returnValue = LineaPedidoAssembler.Convert (lineaComandaEN, session);
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





















/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_LineaPedidoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
