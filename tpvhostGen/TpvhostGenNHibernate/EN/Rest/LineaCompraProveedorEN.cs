
using System;
// Definición clase LineaCompraProveedorEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class LineaCompraProveedorEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo servicio
 */
private TpvhostGenNHibernate.EN.Rest.ServicioEN servicio;



/**
 *	Atributo compraProveedor
 */
private TpvhostGenNHibernate.EN.Rest.CompraProveedorEN compraProveedor;



/**
 *	Atributo producto
 */
private TpvhostGenNHibernate.EN.Rest.ProductoEN producto;



/**
 *	Atributo costo
 */
private double costo;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.ServicioEN Servicio {
        get { return servicio; } set { servicio = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.CompraProveedorEN CompraProveedor {
        get { return compraProveedor; } set { compraProveedor = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}



public virtual double Costo {
        get { return costo; } set { costo = value;  }
}





public LineaCompraProveedorEN()
{
}



public LineaCompraProveedorEN(int id, int cantidad, TpvhostGenNHibernate.EN.Rest.ServicioEN servicio, TpvhostGenNHibernate.EN.Rest.CompraProveedorEN compraProveedor, TpvhostGenNHibernate.EN.Rest.ProductoEN producto, double costo
                              )
{
        this.init (Id, cantidad, servicio, compraProveedor, producto, costo);
}


public LineaCompraProveedorEN(LineaCompraProveedorEN lineaCompraProveedor)
{
        this.init (Id, lineaCompraProveedor.Cantidad, lineaCompraProveedor.Servicio, lineaCompraProveedor.CompraProveedor, lineaCompraProveedor.Producto, lineaCompraProveedor.Costo);
}

private void init (int id
                   , int cantidad, TpvhostGenNHibernate.EN.Rest.ServicioEN servicio, TpvhostGenNHibernate.EN.Rest.CompraProveedorEN compraProveedor, TpvhostGenNHibernate.EN.Rest.ProductoEN producto, double costo)
{
        this.Id = id;


        this.Cantidad = cantidad;

        this.Servicio = servicio;

        this.CompraProveedor = compraProveedor;

        this.Producto = producto;

        this.Costo = costo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaCompraProveedorEN t = obj as LineaCompraProveedorEN;
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
