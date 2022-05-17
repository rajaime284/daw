
using System;
// Definición clase NegocioEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class NegocioEN
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
 *	Atributo ciudad
 */
private string ciudad;



/**
 *	Atributo cp
 */
private string cp;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo pais
 */
private string pais;



/**
 *	Atributo servicios
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ServicioEN> servicios;



/**
 *	Atributo empresa
 */
private TpvhostGenNHibernate.EN.Rest.EmpresaEN empresa;



/**
 *	Atributo mesa
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.MesaEN> mesa;



/**
 *	Atributo caja
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> caja;



/**
 *	Atributo compraProveedor
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor;



/**
 *	Atributo producto
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ProductoEN> producto;



/**
 *	Atributo empleado
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.EmpleadoEN> empleado;



/**
 *	Atributo cliente
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ClienteEN> cliente;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Ciudad {
        get { return ciudad; } set { ciudad = value;  }
}



public virtual string Cp {
        get { return cp; } set { cp = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual string Pais {
        get { return pais; } set { pais = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ServicioEN> Servicios {
        get { return servicios; } set { servicios = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.EmpresaEN Empresa {
        get { return empresa; } set { empresa = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.MesaEN> Mesa {
        get { return mesa; } set { mesa = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> Caja {
        get { return caja; } set { caja = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN> CompraProveedor {
        get { return compraProveedor; } set { compraProveedor = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ProductoEN> Producto {
        get { return producto; } set { producto = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.EmpleadoEN> Empleado {
        get { return empleado; } set { empleado = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ClienteEN> Cliente {
        get { return cliente; } set { cliente = value;  }
}





public NegocioEN()
{
        servicios = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.ServicioEN>();
        mesa = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.MesaEN>();
        caja = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CajaEN>();
        compraProveedor = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN>();
        producto = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.ProductoEN>();
        empleado = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.EmpleadoEN>();
        cliente = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.ClienteEN>();
}



public NegocioEN(int id, string nombre, string direccion, string ciudad, string cp, string provincia, string pais, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ServicioEN> servicios, TpvhostGenNHibernate.EN.Rest.EmpresaEN empresa, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.MesaEN> mesa, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> caja, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ProductoEN> producto, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.EmpleadoEN> empleado, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ClienteEN> cliente
                 )
{
        this.init (Id, nombre, direccion, ciudad, cp, provincia, pais, servicios, empresa, mesa, caja, compraProveedor, producto, empleado, cliente);
}


public NegocioEN(NegocioEN negocio)
{
        this.init (Id, negocio.Nombre, negocio.Direccion, negocio.Ciudad, negocio.Cp, negocio.Provincia, negocio.Pais, negocio.Servicios, negocio.Empresa, negocio.Mesa, negocio.Caja, negocio.CompraProveedor, negocio.Producto, negocio.Empleado, negocio.Cliente);
}

private void init (int id
                   , string nombre, string direccion, string ciudad, string cp, string provincia, string pais, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ServicioEN> servicios, TpvhostGenNHibernate.EN.Rest.EmpresaEN empresa, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.MesaEN> mesa, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> caja, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ProductoEN> producto, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.EmpleadoEN> empleado, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.ClienteEN> cliente)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Direccion = direccion;

        this.Ciudad = ciudad;

        this.Cp = cp;

        this.Provincia = provincia;

        this.Pais = pais;

        this.Servicios = servicios;

        this.Empresa = empresa;

        this.Mesa = mesa;

        this.Caja = caja;

        this.CompraProveedor = compraProveedor;

        this.Producto = producto;

        this.Empleado = empleado;

        this.Cliente = cliente;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NegocioEN t = obj as NegocioEN;
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
