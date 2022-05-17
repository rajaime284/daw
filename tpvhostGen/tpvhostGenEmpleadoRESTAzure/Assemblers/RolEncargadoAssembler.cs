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
public static class RolEncargadoAssembler
{
public static RolEncargadoDTOA Convert (RolEN en, NHibernate.ISession session = null)
{
        RolEncargadoDTOA dto = null;
        RolEncargadoRESTCAD rolEncargadoRESTCAD = null;
        RolCEN rolCEN = null;
        RolCP rolCP = null;

        if (en != null) {
                dto = new RolEncargadoDTOA ();
                rolEncargadoRESTCAD = new RolEncargadoRESTCAD (session);
                rolCEN = new RolCEN (rolEncargadoRESTCAD);
                rolCP = new RolCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                //
                // TravesalLink

                /* Rol: RolEncargado o--> Encargado */
                dto.Encargado = EncargadoAssembler.Convert ((EncargadoEN)en.Encargado, session);


                //
                // Service
        }

        return dto;
}
}
}
