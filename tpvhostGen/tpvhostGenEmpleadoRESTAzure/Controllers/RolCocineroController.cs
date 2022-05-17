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


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_RolCocineroControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/RolCocinero")]
public class RolCocineroController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/RolCocinero/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        RolCocineroRESTCAD rolCocineroRESTCAD = null;
        RolCEN rolCEN = null;

        List<RolEN> rolEN = null;
        List<RolCocineroDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                rolCocineroRESTCAD = new RolCocineroRESTCAD (session);
                rolCEN = new RolCEN (rolCocineroRESTCAD);

                // Data
                // TODO: paginación

                rolEN = rolCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (rolEN != null) {
                        returnValue = new List<RolCocineroDTOA>();
                        foreach (RolEN entry in rolEN)
                                returnValue.Add (RolCocineroAssembler.Convert (entry, session));
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
// [Route("{idRolCocinero}", Name="GetOIDRolCocinero")]

[Route ("~/api/RolCocinero/{idRolCocinero}")]

public HttpResponseMessage ReadOID (int idRolCocinero)
{
        // CAD, CEN, EN, returnValue
        RolCocineroRESTCAD rolCocineroRESTCAD = null;
        RolCEN rolCEN = null;
        RolEN rolEN = null;
        RolCocineroDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                rolCocineroRESTCAD = new RolCocineroRESTCAD (session);
                rolCEN = new RolCEN (rolCocineroRESTCAD);

                // Data
                rolEN = rolCEN.ReadOID (idRolCocinero);

                // Convert return
                if (rolEN != null) {
                        returnValue = RolCocineroAssembler.Convert (rolEN, session);
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


[Route ("~/api/RolCocinero/NuevoCocinero")]




public HttpResponseMessage NuevoCocinero ( [FromBody] RolDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        RolCocineroRESTCAD rolCocineroRESTCAD = null;
        RolCEN rolCEN = null;
        RolCocineroDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                rolCocineroRESTCAD = new RolCocineroRESTCAD (session);
                rolCEN = new RolCEN (rolCocineroRESTCAD);

                // Create
                returnOID = rolCEN.NuevoCocinero (
                        dto.Empleo                                                                               //Atributo Primitivo: p_empleo
                        ,
                        //Atributo OID: p_empleado
                        // attr.estaRelacionado: true
                        dto.Empleado_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = RolCocineroAssembler.Convert (rolCocineroRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDRolCocinero", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}















[HttpPost]

[Route ("~/api/RolCocinero/AsignarCocinero")]


public HttpResponseMessage AsignarCocinero (int p_rol, int p_cocinero)
{
        // CAD, CEN, returnValue
        RolCocineroRESTCAD rolCocineroRESTCAD = null;
        RolCEN rolCEN = null;

        try
        {
                SessionInitializeTransaction ();


                rolCocineroRESTCAD = new RolCocineroRESTCAD (session);
                rolCEN = new RolCEN (rolCocineroRESTCAD);


                // Operation
                rolCEN.AsignarCocinero (p_rol, p_cocinero);
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






/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_RolCocineroControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
