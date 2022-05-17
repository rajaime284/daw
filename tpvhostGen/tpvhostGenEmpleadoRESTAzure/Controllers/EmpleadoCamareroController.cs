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


/*PROTECTED REGION ID(usingtpvhostGenEmpleadoRESTAzure_EmpleadoCamareroControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/EmpleadoCamarero")]
public class EmpleadoCamareroController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/EmpleadoCamarero/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        EmpleadoCamareroRESTCAD empleadoCamareroRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;

        List<EmpleadoEN> empleadoEN = null;
        List<EmpleadoCamareroDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                empleadoCamareroRESTCAD = new EmpleadoCamareroRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoCamareroRESTCAD);

                // Data
                // TODO: paginación

                empleadoEN = empleadoCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (empleadoEN != null) {
                        returnValue = new List<EmpleadoCamareroDTOA>();
                        foreach (EmpleadoEN entry in empleadoEN)
                                returnValue.Add (EmpleadoCamareroAssembler.Convert (entry, session));
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
// [Route("{idEmpleadoCamarero}", Name="GetOIDEmpleadoCamarero")]

[Route ("~/api/EmpleadoCamarero/{idEmpleadoCamarero}")]

public HttpResponseMessage ReadOID (int idEmpleadoCamarero)
{
        // CAD, CEN, EN, returnValue
        EmpleadoCamareroRESTCAD empleadoCamareroRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoEN empleadoEN = null;
        EmpleadoCamareroDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                empleadoCamareroRESTCAD = new EmpleadoCamareroRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoCamareroRESTCAD);

                // Data
                empleadoEN = empleadoCEN.ReadOID (idEmpleadoCamarero);

                // Convert return
                if (empleadoEN != null) {
                        returnValue = EmpleadoCamareroAssembler.Convert (empleadoEN, session);
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


[Route ("~/api/EmpleadoCamarero/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] EmpleadoDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        EmpleadoCamareroRESTCAD empleadoCamareroRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoCamareroDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                empleadoCamareroRESTCAD = new EmpleadoCamareroRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoCamareroRESTCAD);

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
                returnValue = EmpleadoCamareroAssembler.Convert (empleadoCamareroRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDEmpleadoCamarero", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}


















/*PROTECTED REGION ID(tpvhostGenEmpleadoRESTAzure_EmpleadoCamareroControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
