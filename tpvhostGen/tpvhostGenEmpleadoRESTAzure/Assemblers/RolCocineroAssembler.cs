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
public static class RolCocineroAssembler
{
public static RolCocineroDTOA Convert (RolEN en, NHibernate.ISession session = null)
{
        RolCocineroDTOA dto = null;
        RolCocineroRESTCAD rolCocineroRESTCAD = null;
        RolCEN rolCEN = null;
        RolCP rolCP = null;

        if (en != null) {
                dto = new RolCocineroDTOA ();
                rolCocineroRESTCAD = new RolCocineroRESTCAD (session);
                rolCEN = new RolCEN (rolCocineroRESTCAD);
                rolCP = new RolCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                //
                // TravesalLink

                /* Rol: RolCocinero o--> Cocinero */
                dto.Cocinero = CocineroAssembler.Convert ((CocineroEN)en.Cocinero, session);


                //
                // Service
        }

        return dto;
}
}
}
