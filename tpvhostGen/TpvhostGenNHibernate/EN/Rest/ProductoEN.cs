
using System;
// Definición clase ProductoEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class ProductoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo stock
 */
private double stock;



/**
 *	Atributo unidadMedida
 */
private TpvhostGenNHibernate.EN.Rest.UnidadMedidaEN unidadMedida;



/**
 *	Atributo lineaCompraProveedor
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN> lineaCompraProveedor;



/**
 *	Atributo lineaPlato
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaPlatoEN> lineaPlato;



/**
 *	Atributo negocio
 */
private TpvhostGenNHibernate.EN.Rest.NegocioEN negocio;



/**
 *	Atributo descripcion
 */
private string descripcion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual double Stock {
        get { return stock; } set { stock = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.UnidadMedidaEN UnidadMedida {
        get { return unidadMedida; } set { unidadMedida = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN> LineaCompraProveedor {
        get { return lineaCompraProveedor; } set { lineaCompraProveedor = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaPlatoEN> LineaPlato {
        get { return lineaPlato; } set { lineaPlato = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}





public ProductoEN()
{
        lineaCompraProveedor = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN>();
        lineaPlato = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaPlatoEN>();
}



public ProductoEN(int id, double stock, TpvhostGenNHibernate.EN.Rest.UnidadMedidaEN unidadMedida, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN> lineaCompraProveedor, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaPlatoEN> lineaPlato, TpvhostGenNHibernate.EN.Rest.NegocioEN negocio, string descripcion
                  )
{
        this.init (Id, stock, unidadMedida, lineaCompraProveedor, lineaPlato, negocio, descripcion);
}


public ProductoEN(ProductoEN producto)
{
        this.init (Id, producto.Stock, producto.UnidadMedida, producto.LineaCompraProveedor, producto.LineaPlato, producto.Negocio, producto.Descripcion);
}

private void init (int id
                   , double stock, TpvhostGenNHibernate.EN.Rest.UnidadMedidaEN unidadMedida, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN> lineaCompraProveedor, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaPlatoEN> lineaPlato, TpvhostGenNHibernate.EN.Rest.NegocioEN negocio, string descripcion)
{
        this.Id = id;


        this.Stock = stock;

        this.UnidadMedida = unidadMedida;

        this.LineaCompraProveedor = lineaCompraProveedor;

        this.LineaPlato = lineaPlato;

        this.Negocio = negocio;

        this.Descripcion = descripcion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
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
