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


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_CocineroControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/Cocinero")]
public class CocineroController : BasicController
{
// Voy a generar el readAll












[HttpGet]
// [Route("{idCocinero}", Name="GetOIDCocinero")]

[Route ("~/api/Cocinero/{idCocinero}")]

public HttpResponseMessage ReadOID (int idCocinero)
{
        // CAD, CEN, EN, returnValue
        CocineroRESTCAD cocineroRESTCAD = null;
        CocineroCEN cocineroCEN = null;
        CocineroEN cocineroEN = null;
        CocineroDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                cocineroRESTCAD = new CocineroRESTCAD (session);
                cocineroCEN = new CocineroCEN (cocineroRESTCAD);

                // Data
                cocineroEN = cocineroCEN.ReadOID (idCocinero);

                // Convert return
                if (cocineroEN != null) {
                        returnValue = CocineroAssembler.Convert (cocineroEN, session);
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

[Route ("~/api/Cocinero/FinalizarPedido")]


public HttpResponseMessage FinalizarPedido (int p_oid)
{
        // CAD, CEN, returnValue
        CocineroRESTCAD cocineroRESTCAD = null;
        CocineroCEN cocineroCEN = null;

        try
        {
                SessionInitializeTransaction ();


                cocineroRESTCAD = new CocineroRESTCAD (session);
                cocineroCEN = new CocineroCEN (cocineroRESTCAD);


                // Operation
                cocineroCEN.FinalizarPedido (p_oid);
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

        // Return 200 - OK
        return this.Request.CreateResponse (HttpStatusCode.OK);
}






/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_CocineroControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
