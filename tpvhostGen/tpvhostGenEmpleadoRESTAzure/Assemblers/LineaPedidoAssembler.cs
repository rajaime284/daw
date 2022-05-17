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
public static class LineaPedidoAssembler
{
public static LineaPedidoDTOA Convert (LineaComandaEN en, NHibernate.ISession session = null)
{
        LineaPedidoDTOA dto = null;
        LineaPedidoRESTCAD lineaPedidoRESTCAD = null;
        LineaComandaCEN lineaComandaCEN = null;
        LineaComandaCP lineaComandaCP = null;

        if (en != null) {
                dto = new LineaPedidoDTOA ();
                lineaPedidoRESTCAD = new LineaPedidoRESTCAD (session);
                lineaComandaCEN = new LineaComandaCEN (lineaPedidoRESTCAD);
                lineaComandaCP = new LineaComandaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Cantidad = en.Cantidad;


                //
                // TravesalLink

                /* Rol: LineaPedido o--> Plato */
                dto.Platos = PlatoAssembler.Convert ((PlatoEN)en.Plato, session);


                //
                // Service
        }

        return dto;
}
}
}
