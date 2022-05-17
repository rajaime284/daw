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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_NegocioControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Negocio")]
public class NegocioController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Negocio/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioCEN negocioCEN = null;

        List<NegocioEN> negocioEN = null;
        List<NegocioDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);
                negocioCEN = new NegocioCEN (negocioRESTCAD);

                // Data
                // TODO: paginación

                negocioEN = negocioCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (negocioEN != null) {
                        returnValue = new List<NegocioDTOA>();
                        foreach (NegocioEN entry in negocioEN)
                                returnValue.Add (NegocioAssembler.Convert (entry, session));
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





[Route ("~/api/Negocio/GetAllNegocioByEmpresa")]

public HttpResponseMessage GetAllNegocioByEmpresa (int idEmpresa)
{
        // CAD, EN
        EmpresaRESTCAD empresaRESTCAD = null;
        EmpresaEN empresaEN = null;

        // returnValue
        List<NegocioEN> en = null;
        List<NegocioDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                empresaRESTCAD = new EmpresaRESTCAD (session);

                // Exists Empresa
                empresaEN = empresaRESTCAD.ReadOIDDefault (idEmpresa);
                if (empresaEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Empresa#" + idEmpresa + " not found"));

                // Rol
                // TODO: paginación


                en = empresaRESTCAD.GetAllNegocioByEmpresa (idEmpresa).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<NegocioDTOA>();
                        foreach (NegocioEN entry in en)
                                returnValue.Add (NegocioAssembler.Convert (entry, session));
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
// [Route("{idNegocio}", Name="GetOIDNegocio")]

[Route ("~/api/Negocio/{idNegocio}")]

public HttpResponseMessage ReadOID (int idNegocio)
{
        // CAD, CEN, EN, returnValue
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioCEN negocioCEN = null;
        NegocioEN negocioEN = null;
        NegocioDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);
                negocioCEN = new NegocioCEN (negocioRESTCAD);

                // Data
                negocioEN = negocioCEN.ReadOID (idNegocio);

                // Convert return
                if (negocioEN != null) {
                        returnValue = NegocioAssembler.Convert (negocioEN, session);
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


[Route ("~/api/Negocio/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] NegocioDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioCEN negocioCEN = null;
        NegocioDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);
                negocioCEN = new NegocioCEN (negocioRESTCAD);

                // Create
                returnOID = negocioCEN.Nuevo (
                        dto.Nombre                                                                               //Atributo Primitivo: p_nombre
                        , dto.Direccion                                                                                                                                                  //Atributo Primitivo: p_direccion
                        , dto.Ciudad                                                                                                                                                     //Atributo Primitivo: p_ciudad
                        , dto.Cp                                                                                                                                                 //Atributo Primitivo: p_cp
                        , dto.Provincia                                                                                                                                                  //Atributo Primitivo: p_provincia
                        , dto.Pais                                                                                                                                                       //Atributo Primitivo: p_pais
                        ,
                        //Atributo OID: p_empresa
                        // attr.estaRelacionado: true
                        dto.Empresa_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = NegocioAssembler.Convert (negocioRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDNegocio", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/Negocio/Modificar")]

public HttpResponseMessage Modificar (int idNegocio, [FromBody] NegocioDTO dto)
{
        // CAD, CEN, returnValue
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioCEN negocioCEN = null;
        NegocioDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);
                negocioCEN = new NegocioCEN (negocioRESTCAD);

                // Modify
                negocioCEN.Modificar (idNegocio,
                        dto.Nombre
                        ,
                        dto.Direccion
                        ,
                        dto.Ciudad
                        ,
                        dto.Cp
                        ,
                        dto.Provincia
                        ,
                        dto.Pais
                        );

                // Return modified object
                returnValue = NegocioAssembler.Convert (negocioRESTCAD.ReadOIDDefault (idNegocio), session);

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


[Route ("~/api/Negocio/Eliminar")]

public HttpResponseMessage Eliminar (int p_negocio_oid)
{
        // CAD, CEN
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioCEN negocioCEN = null;

        try
        {
                SessionInitializeTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);
                negocioCEN = new NegocioCEN (negocioRESTCAD);

                negocioCEN.Eliminar (p_negocio_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_NegocioControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
