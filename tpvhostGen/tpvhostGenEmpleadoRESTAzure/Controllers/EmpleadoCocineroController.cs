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


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_EmpleadoCocineroControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/EmpleadoCocinero")]
public class EmpleadoCocineroController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/EmpleadoCocinero/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        EmpleadoCocineroRESTCAD empleadoCocineroRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;

        List<EmpleadoEN> empleadoEN = null;
        List<EmpleadoCocineroDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                empleadoCocineroRESTCAD = new EmpleadoCocineroRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoCocineroRESTCAD);

                // Data
                // TODO: paginación

                empleadoEN = empleadoCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (empleadoEN != null) {
                        returnValue = new List<EmpleadoCocineroDTOA>();
                        foreach (EmpleadoEN entry in empleadoEN)
                                returnValue.Add (EmpleadoCocineroAssembler.Convert (entry, session));
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
// [Route("{idEmpleadoCocinero}", Name="GetOIDEmpleadoCocinero")]

[Route ("~/api/EmpleadoCocinero/{idEmpleadoCocinero}")]

public HttpResponseMessage ReadOID (int idEmpleadoCocinero)
{
        // CAD, CEN, EN, returnValue
        EmpleadoCocineroRESTCAD empleadoCocineroRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoEN empleadoEN = null;
        EmpleadoCocineroDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                empleadoCocineroRESTCAD = new EmpleadoCocineroRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoCocineroRESTCAD);

                // Data
                empleadoEN = empleadoCEN.ReadOID (idEmpleadoCocinero);

                // Convert return
                if (empleadoEN != null) {
                        returnValue = EmpleadoCocineroAssembler.Convert (empleadoEN, session);
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


[Route ("~/api/EmpleadoCocinero/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] EmpleadoDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        EmpleadoCocineroRESTCAD empleadoCocineroRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoCocineroDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                empleadoCocineroRESTCAD = new EmpleadoCocineroRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoCocineroRESTCAD);

                // Create
                returnOID = empleadoCEN.Nuevo (

                        //Atributo OID: p_negocio
                        // attr.estaRelacionado: true
                        dto.Negocio_oid                 // association role

                        , dto.Nombre                                                                                                                                                     //Atributo Primitivo: p_nombre
                        , dto.Apellidos                                                                                                                                                  //Atributo Primitivo: p_apellidos
                        , dto.Pass                                                                                                                                                       //Atributo Primitivo: p_pass
                        );
                SessionCommit ();

                // Convert return
                returnValue = EmpleadoCocineroAssembler.Convert (empleadoCocineroRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDEmpleadoCocinero", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}


















/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_EmpleadoCocineroControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
