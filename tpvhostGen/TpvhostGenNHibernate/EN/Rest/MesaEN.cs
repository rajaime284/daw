
using System;
// Definición clase MesaEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class MesaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo comanda
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ComandaEN> comanda;



/**
 *	Atributo negocio
 */
private TpvhostGenNHibernate.EN.Rest.NegocioEN negocio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ComandaEN> Comanda {
        get { return comanda; } set { comanda = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}





public MesaEN()
{
        comanda = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.ComandaEN>();
}



public MesaEN(int id, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ComandaEN> comanda, TpvhostGenNHibernate.EN.Rest.NegocioEN negocio
              )
{
        this.init (Id, comanda, negocio);
}


public MesaEN(MesaEN mesa)
{
        this.init (Id, mesa.Comanda, mesa.Negocio);
}

private void init (int id
                   , System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ComandaEN> comanda, TpvhostGenNHibernate.EN.Rest.NegocioEN negocio)
{
        this.Id = id;


        this.Comanda = comanda;

        this.Negocio = negocio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MesaEN t = obj as MesaEN;
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
