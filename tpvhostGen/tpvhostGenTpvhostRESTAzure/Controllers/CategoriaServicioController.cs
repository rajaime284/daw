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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_CategoriaServicioControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/CategoriaServicio")]
public class CategoriaServicioController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/CategoriaServicio/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        CategoriaServicioRESTCAD categoriaServicioRESTCAD = null;
        CategoriaServicioCEN categoriaServicioCEN = null;

        List<CategoriaServicioEN> categoriaServicioEN = null;
        List<CategoriaServicioDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                categoriaServicioRESTCAD = new CategoriaServicioRESTCAD (session);
                categoriaServicioCEN = new CategoriaServicioCEN (categoriaServicioRESTCAD);

                // Data
                // TODO: paginación

                categoriaServicioEN = categoriaServicioCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (categoriaServicioEN != null) {
                        returnValue = new List<CategoriaServicioDTOA>();
                        foreach (CategoriaServicioEN entry in categoriaServicioEN)
                                returnValue.Add (CategoriaServicioAssembler.Convert (entry, session));
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
// [Route("{idCategoriaServicio}", Name="GetOIDCategoriaServicio")]

[Route ("~/api/CategoriaServicio/{idCategoriaServicio}")]

public HttpResponseMessage ReadOID (int idCategoriaServicio)
{
        // CAD, CEN, EN, returnValue
        CategoriaServicioRESTCAD categoriaServicioRESTCAD = null;
        CategoriaServicioCEN categoriaServicioCEN = null;
        CategoriaServicioEN categoriaServicioEN = null;
        CategoriaServicioDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                categoriaServicioRESTCAD = new CategoriaServicioRESTCAD (session);
                categoriaServicioCEN = new CategoriaServicioCEN (categoriaServicioRESTCAD);

                // Data
                categoriaServicioEN = categoriaServicioCEN.ReadOID (idCategoriaServicio);

                // Convert return
                if (categoriaServicioEN != null) {
                        returnValue = CategoriaServicioAssembler.Convert (categoriaServicioEN, session);
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


[Route ("~/api/CategoriaServicio/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] CategoriaServicioDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        CategoriaServicioRESTCAD categoriaServicioRESTCAD = null;
        CategoriaServicioCEN categoriaServicioCEN = null;
        CategoriaServicioDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                categoriaServicioRESTCAD = new CategoriaServicioRESTCAD (session);
                categoriaServicioCEN = new CategoriaServicioCEN (categoriaServicioRESTCAD);

                // Create
                returnOID = categoriaServicioCEN.Nuevo (
                        dto.Descripcion                                                                          //Atributo Primitivo: p_descripcion
                        );
                SessionCommit ();

                // Convert return
                returnValue = CategoriaServicioAssembler.Convert (categoriaServicioRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDCategoriaServicio", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/CategoriaServicio/Modificar")]

public HttpResponseMessage Modificar (int idCategoriaServicio, [FromBody] CategoriaServicioDTO dto)
{
        // CAD, CEN, returnValue
        CategoriaServicioRESTCAD categoriaServicioRESTCAD = null;
        CategoriaServicioCEN categoriaServicioCEN = null;
        CategoriaServicioDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                categoriaServicioRESTCAD = new CategoriaServicioRESTCAD (session);
                categoriaServicioCEN = new CategoriaServicioCEN (categoriaServicioRESTCAD);

                // Modify
                categoriaServicioCEN.Modificar (idCategoriaServicio,
                        dto.Descripcion
                        );

                // Return modified object
                returnValue = CategoriaServicioAssembler.Convert (categoriaServicioRESTCAD.ReadOIDDefault (idCategoriaServicio), session);

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


[Route ("~/api/CategoriaServicio/Eliminar")]

public HttpResponseMessage Eliminar (int p_categoriaservicio_oid)
{
        // CAD, CEN
        CategoriaServicioRESTCAD categoriaServicioRESTCAD = null;
        CategoriaServicioCEN categoriaServicioCEN = null;

        try
        {
                SessionInitializeTransaction ();


                categoriaServicioRESTCAD = new CategoriaServicioRESTCAD (session);
                categoriaServicioCEN = new CategoriaServicioCEN (categoriaServicioRESTCAD);

                categoriaServicioCEN.Eliminar (p_categoriaservicio_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_CategoriaServicioControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
