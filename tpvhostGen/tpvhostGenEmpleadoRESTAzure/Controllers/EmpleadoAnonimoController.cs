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


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_EmpleadoAnonimoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/EmpleadoAnonimo")]
public class EmpleadoAnonimoController : BasicController
{
// Voy a generar el readAll















[HttpPost]

[Route ("~/api/EmpleadoAnonimo/Login")]


public HttpResponseMessage Login ( [FromBody] EmpleadoDTO dto)
{
        // CAD, CEN, returnValue
        EmpleadoAnonimoRESTCAD empleadoAnonimoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        string token = null;

        try
        {
                SessionInitializeTransaction ();
                empleadoAnonimoRESTCAD = new EmpleadoAnonimoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoAnonimoRESTCAD);


                // Operation
                token = empleadoCEN.Login (
                        dto.DNI
                        , dto.Pass
                        );

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
        if (token != null)
                return this.Request.CreateResponse (HttpStatusCode.OK, token);
        else
                return this.Request.CreateResponse (HttpStatusCode.Unauthorized, "");
}



















/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_EmpleadoAnonimoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
