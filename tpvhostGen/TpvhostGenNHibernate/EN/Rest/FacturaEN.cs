
using System;
// Definición clase FacturaEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class FacturaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo numero
 */
private string numero;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo comanda
 */
private TpvhostGenNHibernate.EN.Rest.ComandaEN comanda;



/**
 *	Atributo cliente
 */
private TpvhostGenNHibernate.EN.Rest.ClienteEN cliente;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Numero {
        get { return numero; } set { numero = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.ComandaEN Comanda {
        get { return comanda; } set { comanda = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}





public FacturaEN()
{
}



public FacturaEN(int id, string numero, Nullable<DateTime> fecha, double precio, string descripcion, TpvhostGenNHibernate.EN.Rest.ComandaEN comanda, TpvhostGenNHibernate.EN.Rest.ClienteEN cliente
                 )
{
        this.init (Id, numero, fecha, precio, descripcion, comanda, cliente);
}


public FacturaEN(FacturaEN factura)
{
        this.init (Id, factura.Numero, factura.Fecha, factura.Precio, factura.Descripcion, factura.Comanda, factura.Cliente);
}

private void init (int id
                   , string numero, Nullable<DateTime> fecha, double precio, string descripcion, TpvhostGenNHibernate.EN.Rest.ComandaEN comanda, TpvhostGenNHibernate.EN.Rest.ClienteEN cliente)
{
        this.Id = id;


        this.Numero = numero;

        this.Fecha = fecha;

        this.Precio = precio;

        this.Descripcion = descripcion;

        this.Comanda = comanda;

        this.Cliente = cliente;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FacturaEN t = obj as FacturaEN;
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
