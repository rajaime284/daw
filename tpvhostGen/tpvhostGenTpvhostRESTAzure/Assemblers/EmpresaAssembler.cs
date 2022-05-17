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
public static class EmpresaAssembler
{
public static EmpresaDTOA Convert (EmpresaEN en, NHibernate.ISession session = null)
{
        EmpresaDTOA dto = null;
        EmpresaRESTCAD empresaRESTCAD = null;
        EmpresaCEN empresaCEN = null;
        EmpresaCP empresaCP = null;

        if (en != null) {
                dto = new EmpresaDTOA ();
                empresaRESTCAD = new EmpresaRESTCAD (session);
                empresaCEN = new EmpresaCEN (empresaRESTCAD);
                empresaCP = new EmpresaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Direccion = en.Direccion;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
