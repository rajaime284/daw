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
public static class LineaPlatoAssembler
{
public static LineaPlatoDTOA Convert (LineaPlatoEN en, NHibernate.ISession session = null)
{
        LineaPlatoDTOA dto = null;
        LineaPlatoRESTCAD lineaPlatoRESTCAD = null;
        LineaPlatoCEN lineaPlatoCEN = null;
        LineaPlatoCP lineaPlatoCP = null;

        if (en != null) {
                dto = new LineaPlatoDTOA ();
                lineaPlatoRESTCAD = new LineaPlatoRESTCAD (session);
                lineaPlatoCEN = new LineaPlatoCEN (lineaPlatoRESTCAD);
                lineaPlatoCP = new LineaPlatoCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Cantidad = en.Cantidad;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
