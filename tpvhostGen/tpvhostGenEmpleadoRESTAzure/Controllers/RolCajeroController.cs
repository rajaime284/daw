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


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_RolCajeroControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/RolCajero")]
public class RolCajeroController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/RolCajero/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        RolCajeroRESTCAD rolCajeroRESTCAD = null;
        RolCEN rolCEN = null;

        List<RolEN> rolEN = null;
        List<RolCajeroDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                rolCajeroRESTCAD = new RolCajeroRESTCAD (session);
                rolCEN = new RolCEN (rolCajeroRESTCAD);

                // Data
                // TODO: paginación

                rolEN = rolCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (rolEN != null) {
                        returnValue = new List<RolCajeroDTOA>();
                        foreach (RolEN entry in rolEN)
                                returnValue.Add (RolCajeroAssembler.Convert (entry, session));
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
// [Route("{idRolCajero}", Name="GetOIDRolCajero")]

[Route ("~/api/RolCajero/{idRolCajero}")]

public HttpResponseMessage ReadOID (int idRolCajero)
{
        // CAD, CEN, EN, returnValue
        RolCajeroRESTCAD rolCajeroRESTCAD = null;
        RolCEN rolCEN = null;
        RolEN rolEN = null;
        RolCajeroDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                rolCajeroRESTCAD = new RolCajeroRESTCAD (session);
                rolCEN = new RolCEN (rolCajeroRESTCAD);

                // Data
                rolEN = rolCEN.ReadOID (idRolCajero);

                // Convert return
                if (rolEN != null) {
                        returnValue = RolCajeroAssembler.Convert (rolEN, session);
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


[Route ("~/api/RolCajero/NuevoCajero")]




public HttpResponseMessage NuevoCajero ( [FromBody] RolDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        RolCajeroRESTCAD rolCajeroRESTCAD = null;
        RolCEN rolCEN = null;
        RolCajeroDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                rolCajeroRESTCAD = new RolCajeroRESTCAD (session);
                rolCEN = new RolCEN (rolCajeroRESTCAD);

                // Create
                returnOID = rolCEN.NuevoCajero (
                        dto.Empleo                                                                               //Atributo Primitivo: p_empleo
                        ,
                        //Atributo OID: p_empleado
                        // attr.estaRelacionado: true
                        dto.Empleado_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = RolCajeroAssembler.Convert (rolCajeroRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDRolCajero", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}















[HttpPost]

[Route ("~/api/RolCajero/AsignarCajero")]


public HttpResponseMessage AsignarCajero (int p_rol, int p_cajero)
{
        // CAD, CEN, returnValue
        RolCajeroRESTCAD rolCajeroRESTCAD = null;
        RolCEN rolCEN = null;

        try
        {
                SessionInitializeTransaction ();


                rolCajeroRESTCAD = new RolCajeroRESTCAD (session);
                rolCEN = new RolCEN (rolCajeroRESTCAD);


                // Operation
                rolCEN.AsignarCajero (p_rol, p_cajero);
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






/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_RolCajeroControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
