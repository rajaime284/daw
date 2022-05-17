using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace tpvhostGenTpvhostRESTAzure.DTOA
{
public class CompraProveedorDTOA
{
private double saldo;
public double Saldo
{
        get { return saldo; }
        set { saldo = value; }
}

private TpvhostGenNHibernate.Enumerated.Rest.EstadoCompraProveedorEnum estadoCompra;
public TpvhostGenNHibernate.Enumerated.Rest.EstadoCompraProveedorEnum EstadoCompra
{
        get { return estadoCompra; }
        set { estadoCompra = value; }
}

private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha
{
        get { return fecha; }
        set { fecha = value; }
}

private double total;
public double Total
{
        get { return total; }
        set { total = value; }
}

private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


/* Rol: CompraProveedor o--> LineaCompraProveedor */
private IList<LineaCompraProveedorDTOA> lineasCompraProveedor;
public IList<LineaCompraProveedorDTOA> LineasCompraProveedor
{
        get { return lineasCompraProveedor; }
        set { lineasCompraProveedor = value; }
}
}
}
