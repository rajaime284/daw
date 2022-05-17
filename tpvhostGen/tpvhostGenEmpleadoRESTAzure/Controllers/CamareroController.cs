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


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_CamareroControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/Camarero")]
public class CamareroController : BasicController
{
// Voy a generar el readAll












[HttpGet]
// [Route("{idCamarero}", Name="GetOIDCamarero")]

[Route ("~/api/Camarero/{idCamarero}")]

public HttpResponseMessage ReadOID (int idCamarero)
{
        // CAD, CEN, EN, returnValue
        CamareroRESTCAD camareroRESTCAD = null;
        CamareroCEN camareroCEN = null;
        CamareroEN camareroEN = null;
        CamareroDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                camareroRESTCAD = new CamareroRESTCAD (session);
                camareroCEN = new CamareroCEN (camareroRESTCAD);

                // Data
                camareroEN = camareroCEN.ReadOID (idCamarero);

                // Convert return
                if (camareroEN != null) {
                        returnValue = CamareroAssembler.Convert (camareroEN, session);
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





















/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_CamareroControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
