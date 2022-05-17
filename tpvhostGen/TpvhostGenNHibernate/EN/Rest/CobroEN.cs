
using System;
// Definición clase CobroEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class CobroEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo monto
 */
private float monto;



/**
 *	Atributo comanda
 */
private TpvhostGenNHibernate.EN.Rest.ComandaEN comanda;



/**
 *	Atributo cliente
 */
private TpvhostGenNHibernate.EN.Rest.ClienteEN cliente;



/**
 *	Atributo tipoDeCobro
 */
private string tipoDeCobro;



/**
 *	Atributo tipoCobro
 */
private TpvhostGenNHibernate.EN.Rest.TipoCobroEN tipoCobro;



/**
 *	Atributo caja
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> caja;



/**
 *	Atributo numeroTransaccion
 */
private string numeroTransaccion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual float Monto {
        get { return monto; } set { monto = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.ComandaEN Comanda {
        get { return comanda; } set { comanda = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual string TipoDeCobro {
        get { return tipoDeCobro; } set { tipoDeCobro = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.TipoCobroEN TipoCobro {
        get { return tipoCobro; } set { tipoCobro = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> Caja {
        get { return caja; } set { caja = value;  }
}



public virtual string NumeroTransaccion {
        get { return numeroTransaccion; } set { numeroTransaccion = value;  }
}





public CobroEN()
{
        caja = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CajaEN>();
}



public CobroEN(int id, float monto, TpvhostGenNHibernate.EN.Rest.ComandaEN comanda, TpvhostGenNHibernate.EN.Rest.ClienteEN cliente, string tipoDeCobro, TpvhostGenNHibernate.EN.Rest.TipoCobroEN tipoCobro, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> caja, string numeroTransaccion
               )
{
        this.init (Id, monto, comanda, cliente, tipoDeCobro, tipoCobro, caja, numeroTransaccion);
}


public CobroEN(CobroEN cobro)
{
        this.init (Id, cobro.Monto, cobro.Comanda, cobro.Cliente, cobro.TipoDeCobro, cobro.TipoCobro, cobro.Caja, cobro.NumeroTransaccion);
}

private void init (int id
                   , float monto, TpvhostGenNHibernate.EN.Rest.ComandaEN comanda, TpvhostGenNHibernate.EN.Rest.ClienteEN cliente, string tipoDeCobro, TpvhostGenNHibernate.EN.Rest.TipoCobroEN tipoCobro, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> caja, string numeroTransaccion)
{
        this.Id = id;


        this.Monto = monto;

        this.Comanda = comanda;

        this.Cliente = cliente;

        this.TipoDeCobro = tipoDeCobro;

        this.TipoCobro = tipoCobro;

        this.Caja = caja;

        this.NumeroTransaccion = numeroTransaccion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CobroEN t = obj as CobroEN;
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
