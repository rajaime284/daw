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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_MenuControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Menu")]
public class MenuController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Menu/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        MenuRESTCAD menuRESTCAD = null;
        MenuCEN menuCEN = null;

        List<MenuEN> menuEN = null;
        List<MenuDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                menuRESTCAD = new MenuRESTCAD (session);
                menuCEN = new MenuCEN (menuRESTCAD);

                // Data
                // TODO: paginación

                menuEN = menuCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (menuEN != null) {
                        returnValue = new List<MenuDTOA>();
                        foreach (MenuEN entry in menuEN)
                                returnValue.Add (MenuAssembler.Convert (entry, session));
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
// [Route("{idMenu}", Name="GetOIDMenu")]

[Route ("~/api/Menu/{idMenu}")]

public HttpResponseMessage ReadOID (int idMenu)
{
        // CAD, CEN, EN, returnValue
        MenuRESTCAD menuRESTCAD = null;
        MenuCEN menuCEN = null;
        MenuEN menuEN = null;
        MenuDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                menuRESTCAD = new MenuRESTCAD (session);
                menuCEN = new MenuCEN (menuRESTCAD);

                // Data
                menuEN = menuCEN.ReadOID (idMenu);

                // Convert return
                if (menuEN != null) {
                        returnValue = MenuAssembler.Convert (menuEN, session);
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


[Route ("~/api/Menu/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] MenuDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        MenuRESTCAD menuRESTCAD = null;
        MenuCEN menuCEN = null;
        MenuDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                menuRESTCAD = new MenuRESTCAD (session);
                menuCEN = new MenuCEN (menuRESTCAD);

                // Create
                returnOID = menuCEN.Nuevo (
                        dto.Nombre                                                                               //Atributo Primitivo: p_nombre
                        , LineaMenuAssemblerDTO.ConvertList (dto.LineaMenu)
                        //Atributo Object: p_lineaMenu
                        );
                SessionCommit ();

                // Convert return
                returnValue = MenuAssembler.Convert (menuRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDMenu", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/Menu/Modificar")]

public HttpResponseMessage Modificar (int idMenu, [FromBody] MenuDTO dto)
{
        // CAD, CEN, returnValue
        MenuRESTCAD menuRESTCAD = null;
        MenuCEN menuCEN = null;
        MenuDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                menuRESTCAD = new MenuRESTCAD (session);
                menuCEN = new MenuCEN (menuRESTCAD);

                // Modify
                menuCEN.Modificar (idMenu,
                        dto.Nombre
                        );

                // Return modified object
                returnValue = MenuAssembler.Convert (menuRESTCAD.ReadOIDDefault (idMenu), session);

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


[Route ("~/api/Menu/Eliminar")]

public HttpResponseMessage Eliminar (int p_menu_oid)
{
        // CAD, CEN
        MenuRESTCAD menuRESTCAD = null;
        MenuCEN menuCEN = null;

        try
        {
                SessionInitializeTransaction ();


                menuRESTCAD = new MenuRESTCAD (session);
                menuCEN = new MenuCEN (menuRESTCAD);

                menuCEN.Eliminar (p_menu_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_MenuControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
