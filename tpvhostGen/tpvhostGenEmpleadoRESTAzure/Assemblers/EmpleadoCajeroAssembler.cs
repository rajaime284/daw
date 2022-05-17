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
public static class EmpleadoCajeroAssembler
{
public static EmpleadoCajeroDTOA Convert (EmpleadoEN en, NHibernate.ISession session = null)
{
        EmpleadoCajeroDTOA dto = null;
        EmpleadoCajeroRESTCAD empleadoCajeroRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoCP empleadoCP = null;

        if (en != null) {
                dto = new EmpleadoCajeroDTOA ();
                empleadoCajeroRESTCAD = new EmpleadoCajeroRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoCajeroRESTCAD);
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
