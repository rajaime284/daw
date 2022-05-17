using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace tpvhostGenEmpleadoRESTAzure.DTOA
{
public class PedidoDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha
{
        get { return fecha; }
        set { fecha = value; }
}

private TpvhostGenNHibernate.Enumerated.Rest.EstadoComandaEnum estadoPedido;
public TpvhostGenNHibernate.Enumerated.Rest.EstadoComandaEnum EstadoPedido
{
        get { return estadoPedido; }
        set { estadoPedido = value; }
}


/* Rol: Pedido o--> LineaPedido */
private IList<LineaPedidoDTOA> lineas;
public IList<LineaPedidoDTOA> Lineas
{
        get { return lineas; }
        set { lineas = value; }
}

/* Rol: Pedido o--> Pago */
private IList<PagoDTOA> pagoDePedido;
public IList<PagoDTOA> PagoDePedido
{
        get { return pagoDePedido; }
        set { pagoDePedido = value; }
}
}
}
