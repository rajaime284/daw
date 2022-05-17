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
public static class DuenyoRegistradoAssembler
{
public static DuenyoRegistradoDTOA Convert (DuenyoEN en, NHibernate.ISession session = null)
{
        DuenyoRegistradoDTOA dto = null;
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;
        DuenyoCP duenyoCP = null;

        if (en != null) {
                dto = new DuenyoRegistradoDTOA ();
                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoRegistradoRESTCAD);
                duenyoCP = new DuenyoCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Apellido = en.Apellido;


                dto.Dni = en.Dni;


                dto.Telefono = en.Telefono;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
