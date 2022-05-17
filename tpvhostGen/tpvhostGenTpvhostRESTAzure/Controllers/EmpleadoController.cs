using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using tpvhostGenTpvhostRESTAzure.DTO;
using tpvhostGenTpvhostRESTAzure.DTOA;
using tpvhostGenTpvhostRESTAzure.CAD;
using tpvhostGenTpvhostRESTAzure.Assemblers;
using tpvhostGenTpvhostRESTAzure.AssemblersDTO;
using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CEN.Rest;
using TpvhostGenNHibernate.CP.Rest;


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_EmpleadoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Empleado")]
public class EmpleadoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Empleado/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        EmpleadoRESTCAD empleadoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;

        List<EmpleadoEN> empleadoEN = null;
        List<EmpleadoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                empleadoRESTCAD = new EmpleadoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoRESTCAD);

                // Data
                // TODO: paginación

                empleadoEN = empleadoCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (empleadoEN != null) {
                        returnValue = new List<EmpleadoDTOA>();
                        foreach (EmpleadoEN entry in empleadoEN)
                                returnValue.Add (EmpleadoAssembler.Convert (entry, session));
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





[Route ("~/api/Empleado/GetAllEmpleadoByNegocio")]

public HttpResponseMessage GetAllEmpleadoByNegocio (int idNegocio)
{
        // CAD, EN
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioEN negocioEN = null;

        // returnValue
        List<EmpleadoEN> en = null;
        List<EmpleadoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);

                // Exists Negocio
                negocioEN = negocioRESTCAD.ReadOIDDefault (idNegocio);
                if (negocioEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Negocio#" + idNegocio + " not found"));

                // Rol
                // TODO: paginación


                en = negocioRESTCAD.GetAllEmpleadoByNegocio (idNegocio).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<EmpleadoDTOA>();
                        foreach (EmpleadoEN entry in en)
                                returnValue.Add (EmpleadoAssembler.Convert (entry, session));
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
// [Route("{idEmpleado}", Name="GetOIDEmpleado")]

[Route ("~/api/Empleado/{idEmpleado}")]

public HttpResponseMessage ReadOID (int idEmpleado)
{
        // CAD, CEN, EN, returnValue
        EmpleadoRESTCAD empleadoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoEN empleadoEN = null;
        EmpleadoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                empleadoRESTCAD = new EmpleadoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoRESTCAD);

                // Data
                empleadoEN = empleadoCEN.ReadOID (idEmpleado);

                // Convert return
                if (empleadoEN != null) {
                        returnValue = EmpleadoAssembler.Convert (empleadoEN, session);
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


[Route ("~/api/Empleado/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] EmpleadoDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        EmpleadoRESTCAD empleadoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                empleadoRESTCAD = new EmpleadoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoRESTCAD);

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
                returnValue = EmpleadoAssembler.Convert (empleadoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDEmpleado", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}


[HttpPost]

[Route ("~/api/Empleado/Login")]


public HttpResponseMessage Login ( [FromBody] EmpleadoDTO dto)
{
        // CAD, CEN, returnValue
        EmpleadoRESTCAD empleadoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        string token = null;

        try
        {
                SessionInitializeTransaction ();
                empleadoRESTCAD = new EmpleadoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoRESTCAD);


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







[HttpPut]


[Route ("~/api/Empleado/Modificar")]

public HttpResponseMessage Modificar (int idEmpleado, [FromBody] EmpleadoDTO dto)
{
        // CAD, CEN, returnValue
        EmpleadoRESTCAD empleadoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                empleadoRESTCAD = new EmpleadoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoRESTCAD);

                // Modify
                empleadoCEN.Modificar (idEmpleado,
                        dto.Nombre
                        ,
                        dto.Apellidos
                        ,
                        dto.Pass
                        );

                // Return modified object
                returnValue = EmpleadoAssembler.Convert (empleadoRESTCAD.ReadOIDDefault (idEmpleado), session);

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

        // Return 404 - Not found
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NotFound);
        // Return 200 - OK
        else{
                response = this.Request.CreateResponse (HttpStatusCode.OK, returnValue);

                return response;
        }
}





[HttpDelete]


[Route ("~/api/Empleado/Eliminar")]

public HttpResponseMessage Eliminar (int p_empleado_oid)
{
        // CAD, CEN
        EmpleadoRESTCAD empleadoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;

        try
        {
                SessionInitializeTransaction ();


                empleadoRESTCAD = new EmpleadoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoRESTCAD);

                empleadoCEN.Eliminar (p_empleado_oid);
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

        // Return 204 - No Content
        return this.Request.CreateResponse (HttpStatusCode.NoContent);
}









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_EmpleadoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
