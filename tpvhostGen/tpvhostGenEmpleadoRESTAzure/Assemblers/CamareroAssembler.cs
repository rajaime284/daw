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
public static class CamareroAssembler
{
public static CamareroDTOA Convert (CamareroEN en, NHibernate.ISession session = null)
{
        CamareroDTOA dto = null;
        CamareroRESTCAD camareroRESTCAD = null;
        CamareroCEN camareroCEN = null;
        CamareroCP camareroCP = null;

        if (en != null) {
                dto = new CamareroDTOA ();
                camareroRESTCAD = new CamareroRESTCAD (session);
                camareroCEN = new CamareroCEN (camareroRESTCAD);
                camareroCP = new CamareroCP (session);





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
