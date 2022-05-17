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


/*PROTECTED REGION ID(usingtpvhostGenTpvhostRESTAzure_LineaMenuControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace tpvhostGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/LineaMenu")]
public class LineaMenuController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/LineaMenu/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        LineaMenuRESTCAD lineaMenuRESTCAD = null;
        LineaMenuCEN lineaMenuCEN = null;

        List<LineaMenuEN> lineaMenuEN = null;
        List<LineaMenuDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                lineaMenuRESTCAD = new LineaMenuRESTCAD (session);
                lineaMenuCEN = new LineaMenuCEN (lineaMenuRESTCAD);

                // Data
                // TODO: paginación

                lineaMenuEN = lineaMenuCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (lineaMenuEN != null) {
                        returnValue = new List<LineaMenuDTOA>();
                        foreach (LineaMenuEN entry in lineaMenuEN)
                                returnValue.Add (LineaMenuAssembler.Convert (entry, session));
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





[Route ("~/api/LineaMenu/GetAllLineaMenuByMenu")]

public HttpResponseMessage GetAllLineaMenuByMenu (int idMenu)
{
        // CAD, EN
        MenuRESTCAD menuRESTCAD = null;
        MenuEN menuEN = null;

        // returnValue
        List<LineaMenuEN> en = null;
        List<LineaMenuDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                menuRESTCAD = new MenuRESTCAD (session);

                // Exists Menu
                menuEN = menuRESTCAD.ReadOIDDefault (idMenu);
                if (menuEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Menu#" + idMenu + " not found"));

                // Rol
                // TODO: paginación


                en = menuRESTCAD.GetAllLineaMenuByMenu (idMenu).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<LineaMenuDTOA>();
                        foreach (LineaMenuEN entry in en)
                                returnValue.Add (LineaMenuAssembler.Convert (entry, session));
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
// [Route("{idLineaMenu}", Name="GetOIDLineaMenu")]

[Route ("~/api/LineaMenu/{idLineaMenu}")]

public HttpResponseMessage ReadOID (int idLineaMenu)
{
        // CAD, CEN, EN, returnValue
        LineaMenuRESTCAD lineaMenuRESTCAD = null;
        LineaMenuCEN lineaMenuCEN = null;
        LineaMenuEN lineaMenuEN = null;
        LineaMenuDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                lineaMenuRESTCAD = new LineaMenuRESTCAD (session);
                lineaMenuCEN = new LineaMenuCEN (lineaMenuRESTCAD);

                // Data
                lineaMenuEN = lineaMenuCEN.ReadOID (idLineaMenu);

                // Convert return
                if (lineaMenuEN != null) {
                        returnValue = LineaMenuAssembler.Convert (lineaMenuEN, session);
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


[Route ("~/api/LineaMenu/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] LineaMenuDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        LineaMenuRESTCAD lineaMenuRESTCAD = null;
        LineaMenuCEN lineaMenuCEN = null;
        LineaMenuDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                lineaMenuRESTCAD = new LineaMenuRESTCAD (session);
                lineaMenuCEN = new LineaMenuCEN (lineaMenuRESTCAD);

                // Create
                returnOID = lineaMenuCEN.Nuevo (
                        dto.Cantidad                                                                             //Atributo Primitivo: p_cantidad
                        ,
                        //Atributo OID: p_plato
                        // attr.estaRelacionado: true
                        dto.Plato_oid                 // association role

                        ,
                        //Atributo OID: p_menu
                        // attr.estaRelacionado: true
                        dto.Menu_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = LineaMenuAssembler.Convert (lineaMenuRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDLineaMenu", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/LineaMenu/Modificar")]

public HttpResponseMessage Modificar (int idLineaMenu, [FromBody] LineaMenuDTO dto)
{
        // CAD, CEN, returnValue
        LineaMenuRESTCAD lineaMenuRESTCAD = null;
        LineaMenuCEN lineaMenuCEN = null;
        LineaMenuDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                lineaMenuRESTCAD = new LineaMenuRESTCAD (session);
                lineaMenuCEN = new LineaMenuCEN (lineaMenuRESTCAD);

                // Modify
                lineaMenuCEN.Modificar (idLineaMenu,
                        dto.Cantidad
                        );

                // Return modified object
                returnValue = LineaMenuAssembler.Convert (lineaMenuRESTCAD.ReadOIDDefault (idLineaMenu), session);

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


[Route ("~/api/LineaMenu/Eliminar")]

public HttpResponseMessage Eliminar (int p_lineamenu_oid)
{
        // CAD, CEN
        LineaMenuRESTCAD lineaMenuRESTCAD = null;
        LineaMenuCEN lineaMenuCEN = null;

        try
        {
                SessionInitializeTransaction ();


                lineaMenuRESTCAD = new LineaMenuRESTCAD (session);
                lineaMenuCEN = new LineaMenuCEN (lineaMenuRESTCAD);

                lineaMenuCEN.Eliminar (p_lineamenu_oid);
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









/*PROTECTED REGION ID(tpvhostGenTpvhostRESTAzure_LineaMenuControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
