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
public static class CajaAssembler
{
public static CajaDTOA Convert (CajaEN en, NHibernate.ISession session = null)
{
        CajaDTOA dto = null;
        CajaRESTCAD cajaRESTCAD = null;
        CajaCEN cajaCEN = null;
        CajaCP cajaCP = null;

        if (en != null) {
                dto = new CajaDTOA ();
                cajaRESTCAD = new CajaRESTCAD (session);
                cajaCEN = new CajaCEN (cajaRESTCAD);
                cajaCP = new CajaCP (session);





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
