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


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
