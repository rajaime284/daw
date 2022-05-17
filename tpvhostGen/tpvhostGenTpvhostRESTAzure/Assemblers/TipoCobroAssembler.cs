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
public static class TipoCobroAssembler
{
public static TipoCobroDTOA Convert (TipoCobroEN en, NHibernate.ISession session = null)
{
        TipoCobroDTOA dto = null;
        TipoCobroRESTCAD tipoCobroRESTCAD = null;
        TipoCobroCEN tipoCobroCEN = null;
        TipoCobroCP tipoCobroCP = null;

        if (en != null) {
                dto = new TipoCobroDTOA ();
                tipoCobroRESTCAD = new TipoCobroRESTCAD (session);
                tipoCobroCEN = new TipoCobroCEN (tipoCobroRESTCAD);
                tipoCobroCP = new TipoCobroCP (session);





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
