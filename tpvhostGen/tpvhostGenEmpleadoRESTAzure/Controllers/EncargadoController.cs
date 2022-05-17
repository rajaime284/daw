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


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_EncargadoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/Encargado")]
public class EncargadoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Encargado/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        EncargadoRESTCAD encargadoRESTCAD = null;
        EncargadoCEN encargadoCEN = null;

        List<EncargadoEN> encargadoEN = null;
        List<EncargadoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                encargadoRESTCAD = new EncargadoRESTCAD (session);
                encargadoCEN = new EncargadoCEN (encargadoRESTCAD);

                // Data
                // TODO: paginación

                encargadoEN = encargadoCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (encargadoEN != null) {
                        returnValue = new List<EncargadoDTOA>();
                        foreach (EncargadoEN entry in encargadoEN)
                                returnValue.Add (EncargadoAssembler.Convert (entry, session));
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
// [Route("{idEncargado}", Name="GetOIDEncargado")]

[Route ("~/api/Encargado/{idEncargado}")]

public HttpResponseMessage ReadOID (int idEncargado)
{
        // CAD, CEN, EN, returnValue
        EncargadoRESTCAD encargadoRESTCAD = null;
        EncargadoCEN encargadoCEN = null;
        EncargadoEN encargadoEN = null;
        EncargadoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                encargadoRESTCAD = new EncargadoRESTCAD (session);
                encargadoCEN = new EncargadoCEN (encargadoRESTCAD);

                // Data
                encargadoEN = encargadoCEN.ReadOID (idEncargado);

                // Convert return
                if (encargadoEN != null) {
                        returnValue = EncargadoAssembler.Convert (encargadoEN, session);
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





















/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_EncargadoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
