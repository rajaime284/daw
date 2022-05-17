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
public static class EmpleadoCamareroAssembler
{
public static EmpleadoCamareroDTOA Convert (EmpleadoEN en, NHibernate.ISession session = null)
{
        EmpleadoCamareroDTOA dto = null;
        EmpleadoCamareroRESTCAD empleadoCamareroRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoCP empleadoCP = null;

        if (en != null) {
                dto = new EmpleadoCamareroDTOA ();
                empleadoCamareroRESTCAD = new EmpleadoCamareroRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoCamareroRESTCAD);
                empleadoCP = new EmpleadoCP (session);





                //
                // Attributes

                dto.DNI = en.DNI;

                dto.Nombre = en.Nombre;


                dto.Apellidos = en.Apellidos;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
