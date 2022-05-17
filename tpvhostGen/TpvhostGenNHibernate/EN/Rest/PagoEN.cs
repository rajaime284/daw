
using System;
// Definición clase PagoEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class PagoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo idPedidoProveedor
 */
private System.Collections.Generic.IList<int> idPedidoProveedor;



/**
 *	Atributo monto
 */
private double monto;



/**
 *	Atributo compraProveedor
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor;



/**
 *	Atributo fechaPago
 */
private Nullable<DateTime> fechaPago;



/**
 *	Atributo tipoPago
 */
private TpvhostGenNHibernate.EN.Rest.TipoPagoEN tipoPago;



/**
 *	Atributo numeroDocumento
 */
private int numeroDocumento;



/**
 *	Atributo caja
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> caja;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<int> IdPedidoProveedor {
        get { return idPedidoProveedor; } set { idPedidoProveedor = value;  }
}



public virtual double Monto {
        get { return monto; } set { monto = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN> CompraProveedor {
        get { return compraProveedor; } set { compraProveedor = value;  }
}



public virtual Nullable<DateTime> FechaPago {
        get { return fechaPago; } set { fechaPago = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.TipoPagoEN TipoPago {
        get { return tipoPago; } set { tipoPago = value;  }
}



public virtual int NumeroDocumento {
        get { return numeroDocumento; } set { numeroDocumento = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> Caja {
        get { return caja; } set { caja = value;  }
}





public PagoEN()
{
        compraProveedor = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN>();
        caja = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CajaEN>();
}



public PagoEN(int id, System.Collections.Generic.IList<int> idPedidoProveedor, double monto, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor, Nullable<DateTime> fechaPago, TpvhostGenNHibernate.EN.Rest.TipoPagoEN tipoPago, int numeroDocumento, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> caja
              )
{
        this.init (Id, idPedidoProveedor, monto, compraProveedor, fechaPago, tipoPago, numeroDocumento, caja);
}


public PagoEN(PagoEN pago)
{
        this.init (Id, pago.IdPedidoProveedor, pago.Monto, pago.CompraProveedor, pago.FechaPago, pago.TipoPago, pago.NumeroDocumento, pago.Caja);
}

private void init (int id
                   , System.Collections.Generic.IList<int> idPedidoProveedor, double monto, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor, Nullable<DateTime> fechaPago, TpvhostGenNHibernate.EN.Rest.TipoPagoEN tipoPago, int numeroDocumento, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> caja)
{
        this.Id = id;


        this.IdPedidoProveedor = idPedidoProveedor;

        this.Monto = monto;

        this.CompraProveedor = compraProveedor;

        this.FechaPago = fechaPago;

        this.TipoPago = tipoPago;

        this.NumeroDocumento = numeroDocumento;

        this.Caja = caja;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PagoEN t = obj as PagoEN;
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
