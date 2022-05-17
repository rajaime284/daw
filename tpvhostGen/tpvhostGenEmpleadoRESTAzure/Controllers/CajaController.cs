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


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_CajaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/Caja")]
public class CajaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Caja/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        CajaRESTCAD cajaRESTCAD = null;
        CajaCEN cajaCEN = null;

        List<CajaEN> cajaEN = null;
        List<CajaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                cajaRESTCAD = new CajaRESTCAD (session);
                cajaCEN = new CajaCEN (cajaRESTCAD);

                // Data
                // TODO: paginación

                cajaEN = cajaCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (cajaEN != null) {
                        returnValue = new List<CajaDTOA>();
                        foreach (CajaEN entry in cajaEN)
                                returnValue.Add (CajaAssembler.Convert (entry, session));
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
// [Route("{idCaja}", Name="GetOIDCaja")]

[Route ("~/api/Caja/{idCaja}")]

public HttpResponseMessage ReadOID (int idCaja)
{
        // CAD, CEN, EN, returnValue
        CajaRESTCAD cajaRESTCAD = null;
        CajaCEN cajaCEN = null;
        CajaEN cajaEN = null;
        CajaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                cajaRESTCAD = new CajaRESTCAD (session);
                cajaCEN = new CajaCEN (cajaRESTCAD);

                // Data
                cajaEN = cajaCEN.ReadOID (idCaja);

                // Convert return
                if (cajaEN != null) {
                        returnValue = CajaAssembler.Convert (cajaEN, session);
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





















/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_CajaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
