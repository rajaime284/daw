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


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_RolEncargadoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/RolEncargado")]
public class RolEncargadoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/RolEncargado/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        RolEncargadoRESTCAD rolEncargadoRESTCAD = null;
        RolCEN rolCEN = null;

        List<RolEN> rolEN = null;
        List<RolEncargadoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                rolEncargadoRESTCAD = new RolEncargadoRESTCAD (session);
                rolCEN = new RolCEN (rolEncargadoRESTCAD);

                // Data
                // TODO: paginación

                rolEN = rolCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (rolEN != null) {
                        returnValue = new List<RolEncargadoDTOA>();
                        foreach (RolEN entry in rolEN)
                                returnValue.Add (RolEncargadoAssembler.Convert (entry, session));
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
// [Route("{idRolEncargado}", Name="GetOIDRolEncargado")]

[Route ("~/api/RolEncargado/{idRolEncargado}")]

public HttpResponseMessage ReadOID (int idRolEncargado)
{
        // CAD, CEN, EN, returnValue
        RolEncargadoRESTCAD rolEncargadoRESTCAD = null;
        RolCEN rolCEN = null;
        RolEN rolEN = null;
        RolEncargadoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                rolEncargadoRESTCAD = new RolEncargadoRESTCAD (session);
                rolCEN = new RolCEN (rolEncargadoRESTCAD);

                // Data
                rolEN = rolCEN.ReadOID (idRolEncargado);

                // Convert return
                if (rolEN != null) {
                        returnValue = RolEncargadoAssembler.Convert (rolEN, session);
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


[Route ("~/api/RolEncargado/NuevoEncargado")]




public HttpResponseMessage NuevoEncargado ( [FromBody] RolDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        RolEncargadoRESTCAD rolEncargadoRESTCAD = null;
        RolCEN rolCEN = null;
        RolEncargadoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                rolEncargadoRESTCAD = new RolEncargadoRESTCAD (session);
                rolCEN = new RolCEN (rolEncargadoRESTCAD);

                // Create
                returnOID = rolCEN.NuevoEncargado (
                        dto.Empleo                                                                               //Atributo Primitivo: p_empleo
                        ,
                        //Atributo OID: p_empleado
                        // attr.estaRelacionado: true
                        dto.Empleado_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = RolEncargadoAssembler.Convert (rolEncargadoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDRolEncargado", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}















[HttpPost]

[Route ("~/api/RolEncargado/AsignarEncargado")]


public HttpResponseMessage AsignarEncargado (int p_rol, int p_encargado)
{
        // CAD, CEN, returnValue
        RolEncargadoRESTCAD rolEncargadoRESTCAD = null;
        RolCEN rolCEN = null;

        try
        {
                SessionInitializeTransaction ();


                rolEncargadoRESTCAD = new RolEncargadoRESTCAD (session);
                rolCEN = new RolCEN (rolEncargadoRESTCAD);


                // Operation
                rolCEN.AsignarEncargado (p_rol, p_encargado);
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






/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_RolEncargadoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
