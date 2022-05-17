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
public static class RolCajeroAssembler
{
public static RolCajeroDTOA Convert (RolEN en, NHibernate.ISession session = null)
{
        RolCajeroDTOA dto = null;
        RolCajeroRESTCAD rolCajeroRESTCAD = null;
        RolCEN rolCEN = null;
        RolCP rolCP = null;

        if (en != null) {
                dto = new RolCajeroDTOA ();
                rolCajeroRESTCAD = new RolCajeroRESTCAD (session);
                rolCEN = new RolCEN (rolCajeroRESTCAD);
                rolCP = new RolCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                //
                // TravesalLink

                /* Rol: RolCajero o--> Cajero */
                dto.Cajero = CajeroAssembler.Convert ((CajeroEN)en.Cajero, session);


                //
                // Service
        }

        return dto;
}
}
}
