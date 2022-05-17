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
public static class EmpleadoEncargadoAssembler
{
public static EmpleadoEncargadoDTOA Convert (EmpleadoEN en, NHibernate.ISession session = null)
{
        EmpleadoEncargadoDTOA dto = null;
        EmpleadoEncargadoRESTCAD empleadoEncargadoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoCP empleadoCP = null;

        if (en != null) {
                dto = new EmpleadoEncargadoDTOA ();
                empleadoEncargadoRESTCAD = new EmpleadoEncargadoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoEncargadoRESTCAD);
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
