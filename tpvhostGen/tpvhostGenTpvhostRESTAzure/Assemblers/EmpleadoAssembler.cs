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
public static class EmpleadoAssembler
{
public static EmpleadoDTOA Convert (EmpleadoEN en, NHibernate.ISession session = null)
{
        EmpleadoDTOA dto = null;
        EmpleadoRESTCAD empleadoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoCP empleadoCP = null;

        if (en != null) {
                dto = new EmpleadoDTOA ();
                empleadoRESTCAD = new EmpleadoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoRESTCAD);
                empleadoCP = new EmpleadoCP (session);





                //
                // Attributes

                dto.DNI = en.DNI;

                dto.Nombre = en.Nombre;


                dto.Apellidos = en.Apellidos;


                dto.Pass = en.Pass;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
