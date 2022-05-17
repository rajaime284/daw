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
public static class PedidoAssembler
{
public static PedidoDTOA Convert (ComandaEN en, NHibernate.ISession session = null)
{
        PedidoDTOA dto = null;
        PedidoRESTCAD pedidoRESTCAD = null;
        ComandaCEN comandaCEN = null;
        ComandaCP comandaCP = null;

        if (en != null) {
                dto = new PedidoDTOA ();
                pedidoRESTCAD = new PedidoRESTCAD (session);
                comandaCEN = new ComandaCEN (pedidoRESTCAD);
                comandaCP = new ComandaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Fecha = en.Fecha;


                dto.EstadoPedido = en.EstadoPedido;


                //
                // TravesalLink

                /* Rol: Pedido o--> LineaPedido */
                dto.Lineas = null;
                List<LineaComandaEN> Lineas = pedidoRESTCAD.Lineas (en.Id).ToList ();
                if (Lineas != null) {
                        dto.Lineas = new List<LineaPedidoDTOA>();
                        foreach (LineaComandaEN entry in Lineas)
                                dto.Lineas.Add (LineaPedidoAssembler.Convert (entry, session));
                }

                /* Rol: Pedido o--> Pago */
                dto.PagoDePedido = null;
                List<CobroEN> PagoDePedido = pedidoRESTCAD.PagoDePedido (en.Id).ToList ();
                if (PagoDePedido != null) {
                        dto.PagoDePedido = new List<PagoDTOA>();
                        foreach (CobroEN entry in PagoDePedido)
                                dto.PagoDePedido.Add (PagoAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
