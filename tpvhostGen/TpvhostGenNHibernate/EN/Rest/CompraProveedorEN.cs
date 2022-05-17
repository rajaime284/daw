
using System;
// Definición clase CompraProveedorEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class CompraProveedorEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo lineaCompraProveedor
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN> lineaCompraProveedor;



/**
 *	Atributo proveedor
 */
private TpvhostGenNHibernate.EN.Rest.ProveedorEN proveedor;



/**
 *	Atributo negocio
 */
private TpvhostGenNHibernate.EN.Rest.NegocioEN negocio;



/**
 *	Atributo pago
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.PagoEN> pago;



/**
 *	Atributo saldo
 */
private double saldo;



/**
 *	Atributo estadoCompra
 */
private TpvhostGenNHibernate.Enumerated.Rest.EstadoCompraProveedorEnum estadoCompra;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo total
 */
private double total;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN> LineaCompraProveedor {
        get { return lineaCompraProveedor; } set { lineaCompraProveedor = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.ProveedorEN Proveedor {
        get { return proveedor; } set { proveedor = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.PagoEN> Pago {
        get { return pago; } set { pago = value;  }
}



public virtual double Saldo {
        get { return saldo; } set { saldo = value;  }
}



public virtual TpvhostGenNHibernate.Enumerated.Rest.EstadoCompraProveedorEnum EstadoCompra {
        get { return estadoCompra; } set { estadoCompra = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual double Total {
        get { return total; } set { total = value;  }
}





public CompraProveedorEN()
{
        lineaCompraProveedor = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN>();
        pago = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.PagoEN>();
}



public CompraProveedorEN(int id, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN> lineaCompraProveedor, TpvhostGenNHibernate.EN.Rest.ProveedorEN proveedor, TpvhostGenNHibernate.EN.Rest.NegocioEN negocio, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.PagoEN> pago, double saldo, TpvhostGenNHibernate.Enumerated.Rest.EstadoCompraProveedorEnum estadoCompra, Nullable<DateTime> fecha, double total
                         )
{
        this.init (Id, lineaCompraProveedor, proveedor, negocio, pago, saldo, estadoCompra, fecha, total);
}


public CompraProveedorEN(CompraProveedorEN compraProveedor)
{
        this.init (Id, compraProveedor.LineaCompraProveedor, compraProveedor.Proveedor, compraProveedor.Negocio, compraProveedor.Pago, compraProveedor.Saldo, compraProveedor.EstadoCompra, compraProveedor.Fecha, compraProveedor.Total);
}

private void init (int id
                   , System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN> lineaCompraProveedor, TpvhostGenNHibernate.EN.Rest.ProveedorEN proveedor, TpvhostGenNHibernate.EN.Rest.NegocioEN negocio, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.PagoEN> pago, double saldo, TpvhostGenNHibernate.Enumerated.Rest.EstadoCompraProveedorEnum estadoCompra, Nullable<DateTime> fecha, double total)
{
        this.Id = id;


        this.LineaCompraProveedor = lineaCompraProveedor;

        this.Proveedor = proveedor;

        this.Negocio = negocio;

        this.Pago = pago;

        this.Saldo = saldo;

        this.EstadoCompra = estadoCompra;

        this.Fecha = fecha;

        this.Total = total;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CompraProveedorEN t = obj as CompraProveedorEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
