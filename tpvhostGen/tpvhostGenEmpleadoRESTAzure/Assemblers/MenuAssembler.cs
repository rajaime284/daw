using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using tpvhostGenEmpleadoRESTAzure.DTOA;
using tpvhostGenEmpleadoRESTAzure.CAD;
using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CEN.Rest;
using TpvhostGenNHibernate.CAD.Rest;
using TpvhostGenNHibernate.CP.Rest;

namespace tpvhostGenEmpleadoRESTAzure.Assemblers
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


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
