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
public static class DuenyoAnonimoAssembler
{
public static DuenyoAnonimoDTOA Convert (DuenyoEN en, NHibernate.ISession session = null)
{
        DuenyoAnonimoDTOA dto = null;
        DuenyoAnonimoRESTCAD duenyoAnonimoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;
        DuenyoCP duenyoCP = null;

        if (en != null) {
                dto = new DuenyoAnonimoDTOA ();
                duenyoAnonimoRESTCAD = new DuenyoAnonimoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoAnonimoRESTCAD);
                duenyoCP = new DuenyoCP (session);





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
