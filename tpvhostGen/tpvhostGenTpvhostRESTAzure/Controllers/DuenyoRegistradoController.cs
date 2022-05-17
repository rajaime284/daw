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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_DuenyoRegistradoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/DuenyoRegistrado")]
public class DuenyoRegistradoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/DuenyoRegistrado/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;

        List<DuenyoEN> duenyoEN = null;
        List<DuenyoRegistradoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoRegistradoRESTCAD);

                // Data
                // TODO: paginación

                duenyoEN = duenyoCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (duenyoEN != null) {
                        returnValue = new List<DuenyoRegistradoDTOA>();
                        foreach (DuenyoEN entry in duenyoEN)
                                returnValue.Add (DuenyoRegistradoAssembler.Convert (entry, session));
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





[Route ("~/api/DuenyoRegistrado/GetDuenyoOfEmpresa")]

public HttpResponseMessage GetDuenyoOfEmpresa (int idEmpresa)
{
        // CAD, EN
        EmpresaRESTCAD empresaRESTCAD = null;
        EmpresaEN empresaEN = null;

        // returnValue
        DuenyoEN en = null;
        DuenyoRegistradoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                empresaRESTCAD = new EmpresaRESTCAD (session);

                // Exists Empresa
                empresaEN = empresaRESTCAD.ReadOIDDefault (idEmpresa);
                if (empresaEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Empresa#" + idEmpresa + " not found"));

                // Rol
                // TODO: paginación


                en = empresaRESTCAD.GetDuenyoOfEmpresa (idEmpresa);



                // Convert return
                if (en != null) {
                        returnValue = DuenyoRegistradoAssembler.Convert (en, session);
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
// [Route("{idDuenyoRegistrado}", Name="GetOIDDuenyoRegistrado")]

[Route ("~/api/DuenyoRegistrado/{idDuenyoRegistrado}")]

public HttpResponseMessage ReadOID (int idDuenyoRegistrado)
{
        // CAD, CEN, EN, returnValue
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;
        DuenyoEN duenyoEN = null;
        DuenyoRegistradoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoRegistradoRESTCAD);

                // Data
                duenyoEN = duenyoCEN.ReadOID (idDuenyoRegistrado);

                // Convert return
                if (duenyoEN != null) {
                        returnValue = DuenyoRegistradoAssembler.Convert (duenyoEN, session);
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


[Route ("~/api/DuenyoRegistrado/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] DuenyoDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;
        DuenyoRegistradoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoRegistradoRESTCAD);

                // Create
                returnOID = duenyoCEN.Nuevo (
                        dto.Dni                                                                          //Atributo Primitivo: p_dni
                        , dto.Nombre                                                                                                                                                     //Atributo Primitivo: p_nombre
                        , dto.Apellido                                                                                                                                                   //Atributo Primitivo: p_apellido
                        , dto.Telefono                                                                                                                                                   //Atributo Primitivo: p_telefono
                        , dto.Pass                                                                                                                                                       //Atributo Primitivo: p_pass
                        );
                SessionCommit ();

                // Convert return
                returnValue = DuenyoRegistradoAssembler.Convert (duenyoRegistradoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDDuenyoRegistrado", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}


[HttpPost]

[Route ("~/api/DuenyoRegistrado/Login")]


public HttpResponseMessage Login ( [FromBody] DuenyoDTO dto)
{
        // CAD, CEN, returnValue
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;
        string token = null;

        try
        {
                SessionInitializeTransaction ();
                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoRegistradoRESTCAD);


                // Operation
                token = duenyoCEN.Login (
                        dto.Id
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


[Route ("~/api/DuenyoRegistrado/Modificar")]

public HttpResponseMessage Modificar (int idDuenyoRegistrado, [FromBody] DuenyoDTO dto)
{
        // CAD, CEN, returnValue
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;
        DuenyoRegistradoDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoRegistradoRESTCAD);

                // Modify
                duenyoCEN.Modificar (idDuenyoRegistrado,
                        dto.Dni
                        ,
                        dto.Nombre
                        ,
                        dto.Apellido
                        ,
                        dto.Telefono
                        ,
                        dto.Pass
                        );

                // Return modified object
                returnValue = DuenyoRegistradoAssembler.Convert (duenyoRegistradoRESTCAD.ReadOIDDefault (idDuenyoRegistrado), session);

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


[Route ("~/api/DuenyoRegistrado/Eliminar")]

public HttpResponseMessage Eliminar (int p_duenyo_oid)
{
        // CAD, CEN
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;

        try
        {
                SessionInitializeTransaction ();


                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoRegistradoRESTCAD);

                duenyoCEN.Eliminar (p_duenyo_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_DuenyoRegistradoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
