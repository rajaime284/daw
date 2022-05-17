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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_EmpresaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Empresa")]
public class EmpresaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Empresa/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        EmpresaRESTCAD empresaRESTCAD = null;
        EmpresaCEN empresaCEN = null;

        List<EmpresaEN> empresaEN = null;
        List<EmpresaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                empresaRESTCAD = new EmpresaRESTCAD (session);
                empresaCEN = new EmpresaCEN (empresaRESTCAD);

                // Data
                // TODO: paginación

                empresaEN = empresaCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (empresaEN != null) {
                        returnValue = new List<EmpresaDTOA>();
                        foreach (EmpresaEN entry in empresaEN)
                                returnValue.Add (EmpresaAssembler.Convert (entry, session));
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





[Route ("~/api/Empresa/GetAllEmpresaByDuenyo")]

public HttpResponseMessage GetAllEmpresaByDuenyo (int idDuenyoRegistrado)
{
        // CAD, EN
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoEN duenyoEN = null;

        // returnValue
        List<EmpresaEN> en = null;
        List<EmpresaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);

                // Exists DuenyoRegistrado
                duenyoEN = duenyoRegistradoRESTCAD.ReadOIDDefault (idDuenyoRegistrado);
                if (duenyoEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "DuenyoRegistrado#" + idDuenyoRegistrado + " not found"));

                // Rol
                // TODO: paginación


                en = duenyoRegistradoRESTCAD.GetAllEmpresaByDuenyo (idDuenyoRegistrado).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<EmpresaDTOA>();
                        foreach (EmpresaEN entry in en)
                                returnValue.Add (EmpresaAssembler.Convert (entry, session));
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





[Route ("~/api/Empresa/GetEmpresaOfNegocio")]

public HttpResponseMessage GetEmpresaOfNegocio (int idNegocio)
{
        // CAD, EN
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioEN negocioEN = null;

        // returnValue
        EmpresaEN en = null;
        EmpresaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);

                // Exists Negocio
                negocioEN = negocioRESTCAD.ReadOIDDefault (idNegocio);
                if (negocioEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Negocio#" + idNegocio + " not found"));

                // Rol
                // TODO: paginación


                en = negocioRESTCAD.GetEmpresaOfNegocio (idNegocio);



                // Convert return
                if (en != null) {
                        returnValue = EmpresaAssembler.Convert (en, session);
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
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}







[HttpGet]
// [Route("{idEmpresa}", Name="GetOIDEmpresa")]

[Route ("~/api/Empresa/{idEmpresa}")]

public HttpResponseMessage ReadOID (int idEmpresa)
{
        // CAD, CEN, EN, returnValue
        EmpresaRESTCAD empresaRESTCAD = null;
        EmpresaCEN empresaCEN = null;
        EmpresaEN empresaEN = null;
        EmpresaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                empresaRESTCAD = new EmpresaRESTCAD (session);
                empresaCEN = new EmpresaCEN (empresaRESTCAD);

                // Data
                empresaEN = empresaCEN.ReadOID (idEmpresa);

                // Convert return
                if (empresaEN != null) {
                        returnValue = EmpresaAssembler.Convert (empresaEN, session);
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


[Route ("~/api/Empresa/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] EmpresaDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        EmpresaRESTCAD empresaRESTCAD = null;
        EmpresaCEN empresaCEN = null;
        EmpresaDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                empresaRESTCAD = new EmpresaRESTCAD (session);
                empresaCEN = new EmpresaCEN (empresaRESTCAD);

                // Create
                returnOID = empresaCEN.Nuevo (
                        dto.Nombre                                                                               //Atributo Primitivo: p_nombre
                        , dto.Direccion                                                                                                                                                  //Atributo Primitivo: p_direccion
                        ,
                        //Atributo OID: p_dueño
                        // attr.estaRelacionado: true
                        dto.Dueño_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = EmpresaAssembler.Convert (empresaRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDEmpresa", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/Empresa/Modificar")]

public HttpResponseMessage Modificar (int idEmpresa, [FromBody] EmpresaDTO dto)
{
        // CAD, CEN, returnValue
        EmpresaRESTCAD empresaRESTCAD = null;
        EmpresaCEN empresaCEN = null;
        EmpresaDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                empresaRESTCAD = new EmpresaRESTCAD (session);
                empresaCEN = new EmpresaCEN (empresaRESTCAD);

                // Modify
                empresaCEN.Modificar (idEmpresa,
                        dto.Nombre
                        ,
                        dto.Direccion
                        );

                // Return modified object
                returnValue = EmpresaAssembler.Convert (empresaRESTCAD.ReadOIDDefault (idEmpresa), session);

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


[Route ("~/api/Empresa/Eliminar")]

public HttpResponseMessage Eliminar (int p_empresa_oid)
{
        // CAD, CEN
        EmpresaRESTCAD empresaRESTCAD = null;
        EmpresaCEN empresaCEN = null;

        try
        {
                SessionInitializeTransaction ();


                empresaRESTCAD = new EmpresaRESTCAD (session);
                empresaCEN = new EmpresaCEN (empresaRESTCAD);

                empresaCEN.Eliminar (p_empresa_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_EmpresaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
