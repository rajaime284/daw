
using System;
// Definición clase LineaPlatoEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class LineaPlatoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cantidad
 */
private double cantidad;



/**
 *	Atributo producto
 */
private TpvhostGenNHibernate.EN.Rest.ProductoEN producto;



/**
 *	Atributo plato
 */
private TpvhostGenNHibernate.EN.Rest.PlatoEN plato;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual double Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.PlatoEN Plato {
        get { return plato; } set { plato = value;  }
}





public LineaPlatoEN()
{
}



public LineaPlatoEN(int id, double cantidad, TpvhostGenNHibernate.EN.Rest.ProductoEN producto, TpvhostGenNHibernate.EN.Rest.PlatoEN plato
                    )
{
        this.init (Id, cantidad, producto, plato);
}


public LineaPlatoEN(LineaPlatoEN lineaPlato)
{
        this.init (Id, lineaPlato.Cantidad, lineaPlato.Producto, lineaPlato.Plato);
}

private void init (int id
                   , double cantidad, TpvhostGenNHibernate.EN.Rest.ProductoEN producto, TpvhostGenNHibernate.EN.Rest.PlatoEN plato)
{
        this.Id = id;


        this.Cantidad = cantidad;

        this.Producto = producto;

        this.Plato = plato;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaPlatoEN t = obj as LineaPlatoEN;
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
