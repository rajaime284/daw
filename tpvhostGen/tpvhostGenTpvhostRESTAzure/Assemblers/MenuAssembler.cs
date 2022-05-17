using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using tpvhostGenTpvhostRESTAzure.DTOA;
using tpvhostGenTpvhostRESTAzure.CAD;
using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CEN.Rest;
using TpvhostGenNHibernate.CAD.Rest;
using TpvhostGenNHibernate.CP.Rest;

namespace tpvhostGenTpvhostRESTAzure.Assemblers
{
public static class MenuAssembler
{
public static MenuDTOA Convert (MenuEN en, NHibernate.ISession session = null)
{
        MenuDTOA dto = null;
        MenuRESTCAD menuRESTCAD = null;
        MenuCEN menuCEN = null;
        MenuCP menuCP = null;

        if (en != null) {
                dto = new MenuDTOA ();
                menuRESTCAD = new MenuRESTCAD (session);
                menuCEN = new MenuCEN (menuRESTCAD);
                menuCP = new MenuCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Stock = en.Stock;


                //
                // TravesalLink

                /* Rol: Menu o--> LineaMenu */
                dto.LineasMenu = null;
                List<LineaMenuEN> LineasMenu = menuRESTCAD.LineasMenu (en.Id).ToList ();
                if (LineasMenu != null) {
                        dto.LineasMenu = new List<LineaMenuDTOA>();
                        foreach (LineaMenuEN entry in LineasMenu)
                                dto.LineasMenu.Add (LineaMenuAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
