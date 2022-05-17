
using System;
// Definición clase ClienteEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class ClienteEN
{
/**
 *	Atributo dni
 */
private string dni;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo factura
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.FacturaEN> factura;



/**
 *	Atributo cobro
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> cobro;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo negocio
 */
private TpvhostGenNHibernate.EN.Rest.NegocioEN negocio;






public virtual string Dni {
        get { return dni; } set { dni = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.FacturaEN> Factura {
        get { return factura; } set { factura = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> Cobro {
        get { return cobro; } set { cobro = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}





public ClienteEN()
{
        factura = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.FacturaEN>();
        cobro = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CobroEN>();
}



public ClienteEN(int id, string dni, string nombre, string apellidos, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.FacturaEN> factura, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> cobro, TpvhostGenNHibernate.EN.Rest.NegocioEN negocio
                 )
{
        this.init (Id, dni, nombre, apellidos, factura, cobro, negocio);
}


public ClienteEN(ClienteEN cliente)
{
        this.init (Id, cliente.Dni, cliente.Nombre, cliente.Apellidos, cliente.Factura, cliente.Cobro, cliente.Negocio);
}

private void init (int id
                   , string dni, string nombre, string apellidos, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.FacturaEN> factura, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> cobro, TpvhostGenNHibernate.EN.Rest.NegocioEN negocio)
{
        this.Id = id;


        this.Dni = dni;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Factura = factura;

        this.Cobro = cobro;

        this.Negocio = negocio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ClienteEN t = obj as ClienteEN;
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
