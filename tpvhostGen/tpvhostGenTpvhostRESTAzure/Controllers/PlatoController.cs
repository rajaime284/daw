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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_PlatoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Plato")]
public class PlatoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Plato/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        PlatoRESTCAD platoRESTCAD = null;
        PlatoCEN platoCEN = null;

        List<PlatoEN> platoEN = null;
        List<PlatoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);
                platoCEN = new PlatoCEN (platoRESTCAD);

                // Data
                // TODO: paginación

                platoEN = platoCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (platoEN != null) {
                        returnValue = new List<PlatoDTOA>();
                        foreach (PlatoEN entry in platoEN)
                                returnValue.Add (PlatoAssembler.Convert (entry, session));
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
// [Route("{idPlato}", Name="GetOIDPlato")]

[Route ("~/api/Plato/{idPlato}")]

public HttpResponseMessage ReadOID (int idPlato)
{
        // CAD, CEN, EN, returnValue
        PlatoRESTCAD platoRESTCAD = null;
        PlatoCEN platoCEN = null;
        PlatoEN platoEN = null;
        PlatoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);
                platoCEN = new PlatoCEN (platoRESTCAD);

                // Data
                platoEN = platoCEN.ReadOID (idPlato);

                // Convert return
                if (platoEN != null) {
                        returnValue = PlatoAssembler.Convert (platoEN, session);
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


[Route ("~/api/Plato/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] PlatoDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        PlatoRESTCAD platoRESTCAD = null;
        PlatoCEN platoCEN = null;
        PlatoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);
                platoCEN = new PlatoCEN (platoRESTCAD);

                // Create
                returnOID = platoCEN.Nuevo (
                        dto.Nombre                                                                               //Atributo Primitivo: p_nombre
                        , dto.Precio                                                                                                                                                     //Atributo Primitivo: p_precio
                        , LineaPlatoAssemblerDTO.ConvertList (dto.LineaPlato)
                        //Atributo Object: p_lineaPlato
                        );
                SessionCommit ();

                // Convert return
                returnValue = PlatoAssembler.Convert (platoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDPlato", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/Plato/Modificar")]

public HttpResponseMessage Modificar (int idPlato, [FromBody] PlatoDTO dto)
{
        // CAD, CEN, returnValue
        PlatoRESTCAD platoRESTCAD = null;
        PlatoCEN platoCEN = null;
        PlatoDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);
                platoCEN = new PlatoCEN (platoRESTCAD);

                // Modify
                platoCEN.Modificar (idPlato,
                        dto.Nombre
                        ,
                        dto.Precio
                        );

                // Return modified object
                returnValue = PlatoAssembler.Convert (platoRESTCAD.ReadOIDDefault (idPlato), session);

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


[Route ("~/api/Plato/Eliminar")]

public HttpResponseMessage Eliminar (int p_plato_oid)
{
        // CAD, CEN
        PlatoRESTCAD platoRESTCAD = null;
        PlatoCEN platoCEN = null;

        try
        {
                SessionInitializeTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);
                platoCEN = new PlatoCEN (platoRESTCAD);

                platoCEN.Eliminar (p_plato_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_PlatoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
