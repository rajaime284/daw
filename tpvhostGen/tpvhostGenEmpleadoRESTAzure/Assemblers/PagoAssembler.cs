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
public static class PagoAssembler
{
public static PagoDTOA Convert (CobroEN en, NHibernate.ISession session = null)
{
        PagoDTOA dto = null;
        PagoRESTCAD pagoRESTCAD = null;
        CobroCEN cobroCEN = null;
        CobroCP cobroCP = null;

        if (en != null) {
                dto = new PagoDTOA ();
                pagoRESTCAD = new PagoRESTCAD (session);
                cobroCEN = new CobroCEN (pagoRESTCAD);
                cobroCP = new CobroCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Monto = en.Monto;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
