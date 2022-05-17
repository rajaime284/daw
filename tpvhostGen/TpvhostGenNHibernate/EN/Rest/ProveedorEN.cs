
using System;
// Definición clase ProveedorEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class ProveedorEN
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
 *	Atributo numeroTelefono
 */
private string numeroTelefono;



/**
 *	Atributo compraProveedor
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor;



/**
 *	Atributo email
 */
private string email;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string NumeroTelefono {
        get { return numeroTelefono; } set { numeroTelefono = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN> CompraProveedor {
        get { return compraProveedor; } set { compraProveedor = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}





public ProveedorEN()
{
        compraProveedor = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN>();
}



public ProveedorEN(int id, string nombre, string numeroTelefono, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor, string email
                   )
{
        this.init (Id, nombre, numeroTelefono, compraProveedor, email);
}


public ProveedorEN(ProveedorEN proveedor)
{
        this.init (Id, proveedor.Nombre, proveedor.NumeroTelefono, proveedor.CompraProveedor, proveedor.Email);
}

private void init (int id
                   , string nombre, string numeroTelefono, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor, string email)
{
        this.Id = id;


        this.Nombre = nombre;

        this.NumeroTelefono = numeroTelefono;

        this.CompraProveedor = compraProveedor;

        this.Email = email;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProveedorEN t = obj as ProveedorEN;
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
