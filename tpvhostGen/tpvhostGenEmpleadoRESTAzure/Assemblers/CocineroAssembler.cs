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
public static class CocineroAssembler
{
public static CocineroDTOA Convert (CocineroEN en, NHibernate.ISession session = null)
{
        CocineroDTOA dto = null;
        CocineroRESTCAD cocineroRESTCAD = null;
        CocineroCEN cocineroCEN = null;
        CocineroCP cocineroCP = null;

        if (en != null) {
                dto = new CocineroDTOA ();
                cocineroRESTCAD = new CocineroRESTCAD (session);
                cocineroCEN = new CocineroCEN (cocineroRESTCAD);
                cocineroCP = new CocineroCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
