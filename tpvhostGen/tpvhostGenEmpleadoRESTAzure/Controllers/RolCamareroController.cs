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


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_RolCamareroControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/RolCamarero")]
public class RolCamareroController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/RolCamarero/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        RolCamareroRESTCAD rolCamareroRESTCAD = null;
        RolCEN rolCEN = null;

        List<RolEN> rolEN = null;
        List<RolCamareroDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                rolCamareroRESTCAD = new RolCamareroRESTCAD (session);
                rolCEN = new RolCEN (rolCamareroRESTCAD);

                // Data
                // TODO: paginación

                rolEN = rolCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (rolEN != null) {
                        returnValue = new List<RolCamareroDTOA>();
                        foreach (RolEN entry in rolEN)
                                returnValue.Add (RolCamareroAssembler.Convert (entry, session));
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
// [Route("{idRolCamarero}", Name="GetOIDRolCamarero")]

[Route ("~/api/RolCamarero/{idRolCamarero}")]

public HttpResponseMessage ReadOID (int idRolCamarero)
{
        // CAD, CEN, EN, returnValue
        RolCamareroRESTCAD rolCamareroRESTCAD = null;
        RolCEN rolCEN = null;
        RolEN rolEN = null;
        RolCamareroDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                rolCamareroRESTCAD = new RolCamareroRESTCAD (session);
                rolCEN = new RolCEN (rolCamareroRESTCAD);

                // Data
                rolEN = rolCEN.ReadOID (idRolCamarero);

                // Convert return
                if (rolEN != null) {
                        returnValue = RolCamareroAssembler.Convert (rolEN, session);
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


[Route ("~/api/RolCamarero/NuevoCamarero")]




public HttpResponseMessage NuevoCamarero ( [FromBody] RolDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        RolCamareroRESTCAD rolCamareroRESTCAD = null;
        RolCEN rolCEN = null;
        RolCamareroDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                rolCamareroRESTCAD = new RolCamareroRESTCAD (session);
                rolCEN = new RolCEN (rolCamareroRESTCAD);

                // Create
                returnOID = rolCEN.NuevoCamarero (
                        dto.Empleo                                                                               //Atributo Primitivo: p_empleo
                        ,
                        //Atributo OID: p_empleado
                        // attr.estaRelacionado: true
                        dto.Empleado_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = RolCamareroAssembler.Convert (rolCamareroRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDRolCamarero", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}















[HttpPost]

[Route ("~/api/RolCamarero/AsignarCamarero")]


public HttpResponseMessage AsignarCamarero (int p_rol, int p_camarero)
{
        // CAD, CEN, returnValue
        RolCamareroRESTCAD rolCamareroRESTCAD = null;
        RolCEN rolCEN = null;

        try
        {
                SessionInitializeTransaction ();


                rolCamareroRESTCAD = new RolCamareroRESTCAD (session);
                rolCEN = new RolCEN (rolCamareroRESTCAD);


                // Operation
                rolCEN.AsignarCamarero (p_rol, p_camarero);
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






/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_RolCamareroControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
