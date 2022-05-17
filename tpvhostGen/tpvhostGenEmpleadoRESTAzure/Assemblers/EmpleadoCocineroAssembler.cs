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
public static class EmpleadoCocineroAssembler
{
public static EmpleadoCocineroDTOA Convert (EmpleadoEN en, NHibernate.ISession session = null)
{
        EmpleadoCocineroDTOA dto = null;
        EmpleadoCocineroRESTCAD empleadoCocineroRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoCP empleadoCP = null;

        if (en != null) {
                dto = new EmpleadoCocineroDTOA ();
                empleadoCocineroRESTCAD = new EmpleadoCocineroRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoCocineroRESTCAD);
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
