
using System;
// Definición clase CajaEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class CajaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fondo
 */
private double fondo;



/**
 *	Atributo negocio
 */
private TpvhostGenNHibernate.EN.Rest.NegocioEN negocio;



/**
 *	Atributo cajero
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajeroEN> cajero;



/**
 *	Atributo pago
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.PagoEN> pago;



/**
 *	Atributo saldo
 */
private double saldo;



/**
 *	Atributo cobro
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> cobro;



/**
 *	Atributo descripcion
 */
private string descripcion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual double Fondo {
        get { return fondo; } set { fondo = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajeroEN> Cajero {
        get { return cajero; } set { cajero = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.PagoEN> Pago {
        get { return pago; } set { pago = value;  }
}



public virtual double Saldo {
        get { return saldo; } set { saldo = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> Cobro {
        get { return cobro; } set { cobro = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}





public CajaEN()
{
        cajero = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CajeroEN>();
        pago = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.PagoEN>();
        cobro = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CobroEN>();
}



public CajaEN(int id, double fondo, TpvhostGenNHibernate.EN.Rest.NegocioEN negocio, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajeroEN> cajero, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.PagoEN> pago, double saldo, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> cobro, string descripcion
              )
{
        this.init (Id, fondo, negocio, cajero, pago, saldo, cobro, descripcion);
}


public CajaEN(CajaEN caja)
{
        this.init (Id, caja.Fondo, caja.Negocio, caja.Cajero, caja.Pago, caja.Saldo, caja.Cobro, caja.Descripcion);
}

private void init (int id
                   , double fondo, TpvhostGenNHibernate.EN.Rest.NegocioEN negocio, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajeroEN> cajero, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.PagoEN> pago, double saldo, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> cobro, string descripcion)
{
        this.Id = id;


        this.Fondo = fondo;

        this.Negocio = negocio;

        this.Cajero = cajero;

        this.Pago = pago;

        this.Saldo = saldo;

        this.Cobro = cobro;

        this.Descripcion = descripcion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CajaEN t = obj as CajaEN;
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
