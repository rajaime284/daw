
using System;
// Definición clase UnidadMedidaEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class UnidadMedidaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo producto
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ProductoEN> producto;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ProductoEN> Producto {
        get { return producto; } set { producto = value;  }
}





public UnidadMedidaEN()
{
        producto = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.ProductoEN>();
}



public UnidadMedidaEN(int id, string descripcion, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ProductoEN> producto
                      )
{
        this.init (Id, descripcion, producto);
}


public UnidadMedidaEN(UnidadMedidaEN unidadMedida)
{
        this.init (Id, unidadMedida.Descripcion, unidadMedida.Producto);
}

private void init (int id
                   , string descripcion, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ProductoEN> producto)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UnidadMedidaEN t = obj as UnidadMedidaEN;
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
