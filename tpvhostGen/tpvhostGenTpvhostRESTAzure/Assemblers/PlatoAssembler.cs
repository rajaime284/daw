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
public static class PlatoAssembler
{
public static PlatoDTOA Convert (PlatoEN en, NHibernate.ISession session = null)
{
        PlatoDTOA dto = null;
        PlatoRESTCAD platoRESTCAD = null;
        PlatoCEN platoCEN = null;
        PlatoCP platoCP = null;

        if (en != null) {
                dto = new PlatoDTOA ();
                platoRESTCAD = new PlatoRESTCAD (session);
                platoCEN = new PlatoCEN (platoRESTCAD);
                platoCP = new PlatoCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Precio = en.Precio;


                //
                // TravesalLink

                /* Rol: Plato o--> LineaPlato */
                dto.LineasPlato = null;
                List<LineaPlatoEN> LineasPlato = platoRESTCAD.LineasPlato (en.Id).ToList ();
                if (LineasPlato != null) {
                        dto.LineasPlato = new List<LineaPlatoDTOA>();
                        foreach (LineaPlatoEN entry in LineasPlato)
                                dto.LineasPlato.Add (LineaPlatoAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
