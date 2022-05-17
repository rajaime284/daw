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
public static class ProveedorAssembler
{
public static ProveedorDTOA Convert (ProveedorEN en, NHibernate.ISession session = null)
{
        ProveedorDTOA dto = null;
        ProveedorRESTCAD proveedorRESTCAD = null;
        ProveedorCEN proveedorCEN = null;
        ProveedorCP proveedorCP = null;

        if (en != null) {
                dto = new ProveedorDTOA ();
                proveedorRESTCAD = new ProveedorRESTCAD (session);
                proveedorCEN = new ProveedorCEN (proveedorRESTCAD);
                proveedorCP = new ProveedorCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.NumeroTelefono = en.NumeroTelefono;


                dto.Email = en.Email;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
