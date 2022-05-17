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
public static class CompraProveedorAssembler
{
public static CompraProveedorDTOA Convert (CompraProveedorEN en, NHibernate.ISession session = null)
{
        CompraProveedorDTOA dto = null;
        CompraProveedorRESTCAD compraProveedorRESTCAD = null;
        CompraProveedorCEN compraProveedorCEN = null;
        CompraProveedorCP compraProveedorCP = null;

        if (en != null) {
                dto = new CompraProveedorDTOA ();
                compraProveedorRESTCAD = new CompraProveedorRESTCAD (session);
                compraProveedorCEN = new CompraProveedorCEN (compraProveedorRESTCAD);
                compraProveedorCP = new CompraProveedorCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Saldo = en.Saldo;


                dto.EstadoCompra = en.EstadoCompra;


                dto.Fecha = en.Fecha;


                dto.Total = en.Total;


                //
                // TravesalLink

                /* Rol: CompraProveedor o--> LineaCompraProveedor */
                dto.LineasCompraProveedor = null;
                List<LineaCompraProveedorEN> LineasCompraProveedor = compraProveedorRESTCAD.LineasCompraProveedor (en.Id).ToList ();
                if (LineasCompraProveedor != null) {
                        dto.LineasCompraProveedor = new List<LineaCompraProveedorDTOA>();
                        foreach (LineaCompraProveedorEN entry in LineasCompraProveedor)
                                dto.LineasCompraProveedor.Add (LineaCompraProveedorAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
