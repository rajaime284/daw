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
public static class EmpleadoAnonimoAssembler
{
public static EmpleadoAnonimoDTOA Convert (EmpleadoEN en, NHibernate.ISession session = null)
{
        EmpleadoAnonimoDTOA dto = null;
        EmpleadoAnonimoRESTCAD empleadoAnonimoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoCP empleadoCP = null;

        if (en != null) {
                dto = new EmpleadoAnonimoDTOA ();
                empleadoAnonimoRESTCAD = new EmpleadoAnonimoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoAnonimoRESTCAD);
                empleadoCP = new EmpleadoCP (session);





                //
                // Attributes

                dto.DNI = en.DNI;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
