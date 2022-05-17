
using System;
// Definición clase EmpresaEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class EmpresaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo dueño
 */
private TpvhostGenNHibernate.EN.Rest.DuenyoEN dueño;



/**
 *	Atributo negocio
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.NegocioEN> negocio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.DuenyoEN Dueño {
        get { return dueño; } set { dueño = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.NegocioEN> Negocio {
        get { return negocio; } set { negocio = value;  }
}





public EmpresaEN()
{
        negocio = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.NegocioEN>();
}



public EmpresaEN(int id, string nombre, string direccion, TpvhostGenNHibernate.EN.Rest.DuenyoEN dueño, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.NegocioEN> negocio
                 )
{
        this.init (Id, nombre, direccion, dueño, negocio);
}


public EmpresaEN(EmpresaEN empresa)
{
        this.init (Id, empresa.Nombre, empresa.Direccion, empresa.Dueño, empresa.Negocio);
}

private void init (int id
                   , string nombre, string direccion, TpvhostGenNHibernate.EN.Rest.DuenyoEN dueño, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.NegocioEN> negocio)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Direccion = direccion;

        this.Dueño = dueño;

        this.Negocio = negocio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EmpresaEN t = obj as EmpresaEN;
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
