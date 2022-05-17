
using System;
// Definición clase CategoriaServicioEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class CategoriaServicioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo servicio
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ServicioEN> servicio;



/**
 *	Atributo descripcion
 */
private string descripcion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ServicioEN> Servicio {
        get { return servicio; } set { servicio = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}





public CategoriaServicioEN()
{
        servicio = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.ServicioEN>();
}



public CategoriaServicioEN(int id, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ServicioEN> servicio, string descripcion
                           )
{
        this.init (Id, servicio, descripcion);
}


public CategoriaServicioEN(CategoriaServicioEN categoriaServicio)
{
        this.init (Id, categoriaServicio.Servicio, categoriaServicio.Descripcion);
}

private void init (int id
                   , System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ServicioEN> servicio, string descripcion)
{
        this.Id = id;


        this.Servicio = servicio;

        this.Descripcion = descripcion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CategoriaServicioEN t = obj as CategoriaServicioEN;
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
