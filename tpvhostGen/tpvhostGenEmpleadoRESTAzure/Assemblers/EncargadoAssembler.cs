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
public static class EncargadoAssembler
{
public static EncargadoDTOA Convert (EncargadoEN en, NHibernate.ISession session = null)
{
        EncargadoDTOA dto = null;
        EncargadoRESTCAD encargadoRESTCAD = null;
        EncargadoCEN encargadoCEN = null;
        EncargadoCP encargadoCP = null;

        if (en != null) {
                dto = new EncargadoDTOA ();
                encargadoRESTCAD = new EncargadoRESTCAD (session);
                encargadoCEN = new EncargadoCEN (encargadoRESTCAD);
                encargadoCP = new EncargadoCP (session);





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
