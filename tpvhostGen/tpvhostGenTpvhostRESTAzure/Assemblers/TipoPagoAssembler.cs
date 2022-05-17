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
public static class TipoPagoAssembler
{
public static TipoPagoDTOA Convert (TipoPagoEN en, NHibernate.ISession session = null)
{
        TipoPagoDTOA dto = null;
        TipoPagoRESTCAD tipoPagoRESTCAD = null;
        TipoPagoCEN tipoPagoCEN = null;
        TipoPagoCP tipoPagoCP = null;

        if (en != null) {
                dto = new TipoPagoDTOA ();
                tipoPagoRESTCAD = new TipoPagoRESTCAD (session);
                tipoPagoCEN = new TipoPagoCEN (tipoPagoRESTCAD);
                tipoPagoCP = new TipoPagoCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Descripcion = en.Descripcion;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
