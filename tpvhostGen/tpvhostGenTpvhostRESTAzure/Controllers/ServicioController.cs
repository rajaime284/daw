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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_ServicioControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Servicio")]
public class ServicioController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Servicio/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        ServicioRESTCAD servicioRESTCAD = null;
        ServicioCEN servicioCEN = null;

        List<ServicioEN> servicioEN = null;
        List<ServicioDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                servicioRESTCAD = new ServicioRESTCAD (session);
                servicioCEN = new ServicioCEN (servicioRESTCAD);

                // Data
                // TODO: paginación

                servicioEN = servicioCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (servicioEN != null) {
                        returnValue = new List<ServicioDTOA>();
                        foreach (ServicioEN entry in servicioEN)
                                returnValue.Add (ServicioAssembler.Convert (entry, session));
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





[Route ("~/api/Servicio/GetAllServiciosByNegocio")]

public HttpResponseMessage GetAllServiciosByNegocio (int idNegocio)
{
        // CAD, EN
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioEN negocioEN = null;

        // returnValue
        List<ServicioEN> en = null;
        List<ServicioDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);

                // Exists Negocio
                negocioEN = negocioRESTCAD.ReadOIDDefault (idNegocio);
                if (negocioEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Negocio#" + idNegocio + " not found"));

                // Rol
                // TODO: paginación


                en = negocioRESTCAD.GetAllServiciosByNegocio (idNegocio).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<ServicioDTOA>();
                        foreach (ServicioEN entry in en)
                                returnValue.Add (ServicioAssembler.Convert (entry, session));
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





[Route ("~/api/Servicio/GetAllServicioByCategoriaServicio")]

public HttpResponseMessage GetAllServicioByCategoriaServicio (int idCategoriaServicio)
{
        // CAD, EN
        CategoriaServicioRESTCAD categoriaServicioRESTCAD = null;
        CategoriaServicioEN categoriaServicioEN = null;

        // returnValue
        List<ServicioEN> en = null;
        List<ServicioDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                categoriaServicioRESTCAD = new CategoriaServicioRESTCAD (session);

                // Exists CategoriaServicio
                categoriaServicioEN = categoriaServicioRESTCAD.ReadOIDDefault (idCategoriaServicio);
                if (categoriaServicioEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "CategoriaServicio#" + idCategoriaServicio + " not found"));

                // Rol
                // TODO: paginación


                en = categoriaServicioRESTCAD.GetAllServicioByCategoriaServicio (idCategoriaServicio).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<ServicioDTOA>();
                        foreach (ServicioEN entry in en)
                                returnValue.Add (ServicioAssembler.Convert (entry, session));
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
// [Route("{idServicio}", Name="GetOIDServicio")]

[Route ("~/api/Servicio/{idServicio}")]

public HttpResponseMessage ReadOID (int idServicio)
{
        // CAD, CEN, EN, returnValue
        ServicioRESTCAD servicioRESTCAD = null;
        ServicioCEN servicioCEN = null;
        ServicioEN servicioEN = null;
        ServicioDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                servicioRESTCAD = new ServicioRESTCAD (session);
                servicioCEN = new ServicioCEN (servicioRESTCAD);

                // Data
                servicioEN = servicioCEN.ReadOID (idServicio);

                // Convert return
                if (servicioEN != null) {
                        returnValue = ServicioAssembler.Convert (servicioEN, session);
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


[Route ("~/api/Servicio/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] ServicioDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        ServicioRESTCAD servicioRESTCAD = null;
        ServicioCEN servicioCEN = null;
        ServicioDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                servicioRESTCAD = new ServicioRESTCAD (session);
                servicioCEN = new ServicioCEN (servicioRESTCAD);

                // Create
                returnOID = servicioCEN.Nuevo (

                        //Atributo OID: p_negocio
                        // attr.estaRelacionado: true
                        dto.Negocio_oid                 // association role

                        , dto.Nombre                                                                                                                                                     //Atributo Primitivo: p_nombre
                        ,
                        //Atributo OID: p_categoriaServicio
                        // attr.estaRelacionado: true
                        dto.CategoriaServicio_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = ServicioAssembler.Convert (servicioRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDServicio", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/Servicio/Modificar")]

public HttpResponseMessage Modificar (int idServicio, [FromBody] ServicioDTO dto)
{
        // CAD, CEN, returnValue
        ServicioRESTCAD servicioRESTCAD = null;
        ServicioCEN servicioCEN = null;
        ServicioDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                servicioRESTCAD = new ServicioRESTCAD (session);
                servicioCEN = new ServicioCEN (servicioRESTCAD);

                // Modify
                servicioCEN.Modificar (idServicio,
                        dto.Nombre
                        );

                // Return modified object
                returnValue = ServicioAssembler.Convert (servicioRESTCAD.ReadOIDDefault (idServicio), session);

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


[Route ("~/api/Servicio/Eliminar")]

public HttpResponseMessage Eliminar (int p_servicio_oid)
{
        // CAD, CEN
        ServicioRESTCAD servicioRESTCAD = null;
        ServicioCEN servicioCEN = null;

        try
        {
                SessionInitializeTransaction ();


                servicioRESTCAD = new ServicioRESTCAD (session);
                servicioCEN = new ServicioCEN (servicioRESTCAD);

                servicioCEN.Eliminar (p_servicio_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_ServicioControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
