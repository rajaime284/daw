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
public static class LineaCompraProveedorAssembler
{
public static LineaCompraProveedorDTOA Convert (LineaCompraProveedorEN en, NHibernate.ISession session = null)
{
        LineaCompraProveedorDTOA dto = null;
        LineaCompraProveedorRESTCAD lineaCompraProveedorRESTCAD = null;
        LineaCompraProveedorCEN lineaCompraProveedorCEN = null;
        LineaCompraProveedorCP lineaCompraProveedorCP = null;

        if (en != null) {
                dto = new LineaCompraProveedorDTOA ();
                lineaCompraProveedorRESTCAD = new LineaCompraProveedorRESTCAD (session);
                lineaCompraProveedorCEN = new LineaCompraProveedorCEN (lineaCompraProveedorRESTCAD);
                lineaCompraProveedorCP = new LineaCompraProveedorCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Cantidad = en.Cantidad;


                dto.Costo = en.Costo;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
