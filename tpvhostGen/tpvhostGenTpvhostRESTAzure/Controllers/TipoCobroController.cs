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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_TipoCobroControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/TipoCobro")]
public class TipoCobroController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/TipoCobro/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        TipoCobroRESTCAD tipoCobroRESTCAD = null;
        TipoCobroCEN tipoCobroCEN = null;

        List<TipoCobroEN> tipoCobroEN = null;
        List<TipoCobroDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                tipoCobroRESTCAD = new TipoCobroRESTCAD (session);
                tipoCobroCEN = new TipoCobroCEN (tipoCobroRESTCAD);

                // Data
                // TODO: paginación

                tipoCobroEN = tipoCobroCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (tipoCobroEN != null) {
                        returnValue = new List<TipoCobroDTOA>();
                        foreach (TipoCobroEN entry in tipoCobroEN)
                                returnValue.Add (TipoCobroAssembler.Convert (entry, session));
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
// [Route("{idTipoCobro}", Name="GetOIDTipoCobro")]

[Route ("~/api/TipoCobro/{idTipoCobro}")]

public HttpResponseMessage ReadOID (int idTipoCobro)
{
        // CAD, CEN, EN, returnValue
        TipoCobroRESTCAD tipoCobroRESTCAD = null;
        TipoCobroCEN tipoCobroCEN = null;
        TipoCobroEN tipoCobroEN = null;
        TipoCobroDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                tipoCobroRESTCAD = new TipoCobroRESTCAD (session);
                tipoCobroCEN = new TipoCobroCEN (tipoCobroRESTCAD);

                // Data
                tipoCobroEN = tipoCobroCEN.ReadOID (idTipoCobro);

                // Convert return
                if (tipoCobroEN != null) {
                        returnValue = TipoCobroAssembler.Convert (tipoCobroEN, session);
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


[Route ("~/api/TipoCobro/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] TipoCobroDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        TipoCobroRESTCAD tipoCobroRESTCAD = null;
        TipoCobroCEN tipoCobroCEN = null;
        TipoCobroDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                tipoCobroRESTCAD = new TipoCobroRESTCAD (session);
                tipoCobroCEN = new TipoCobroCEN (tipoCobroRESTCAD);

                // Create
                returnOID = tipoCobroCEN.Nuevo (
                        dto.Descripcion                                                                          //Atributo Primitivo: p_descripcion
                        );
                SessionCommit ();

                // Convert return
                returnValue = TipoCobroAssembler.Convert (tipoCobroRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDTipoCobro", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/TipoCobro/Modificar")]

public HttpResponseMessage Modificar (int idTipoCobro, [FromBody] TipoCobroDTO dto)
{
        // CAD, CEN, returnValue
        TipoCobroRESTCAD tipoCobroRESTCAD = null;
        TipoCobroCEN tipoCobroCEN = null;
        TipoCobroDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                tipoCobroRESTCAD = new TipoCobroRESTCAD (session);
                tipoCobroCEN = new TipoCobroCEN (tipoCobroRESTCAD);

                // Modify
                tipoCobroCEN.Modificar (idTipoCobro,
                        dto.Descripcion
                        );

                // Return modified object
                returnValue = TipoCobroAssembler.Convert (tipoCobroRESTCAD.ReadOIDDefault (idTipoCobro), session);

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


[Route ("~/api/TipoCobro/Eliminar")]

public HttpResponseMessage Eliminar (int p_tipocobro_oid)
{
        // CAD, CEN
        TipoCobroRESTCAD tipoCobroRESTCAD = null;
        TipoCobroCEN tipoCobroCEN = null;

        try
        {
                SessionInitializeTransaction ();


                tipoCobroRESTCAD = new TipoCobroRESTCAD (session);
                tipoCobroCEN = new TipoCobroCEN (tipoCobroRESTCAD);

                tipoCobroCEN.Eliminar (p_tipocobro_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_TipoCobroControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
