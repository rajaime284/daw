
using System;
// Definición clase TipoCobroEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class TipoCobroEN
{
/**
 *	Atributo id
 */
private int id;



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



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> Cobro {
        get { return cobro; } set { cobro = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}





public TipoCobroEN()
{
        cobro = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CobroEN>();
}



public TipoCobroEN(int id, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> cobro, string descripcion
                   )
{
        this.init (Id, cobro, descripcion);
}


public TipoCobroEN(TipoCobroEN tipoCobro)
{
        this.init (Id, tipoCobro.Cobro, tipoCobro.Descripcion);
}

private void init (int id
                   , System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> cobro, string descripcion)
{
        this.Id = id;


        this.Cobro = cobro;

        this.Descripcion = descripcion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TipoCobroEN t = obj as TipoCobroEN;
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
