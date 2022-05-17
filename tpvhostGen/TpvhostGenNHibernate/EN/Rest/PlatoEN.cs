
using System;
// Definición clase PlatoEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class PlatoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo lineaComanda
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo stock
 */
private double stock;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo lineaPlato
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaPlatoEN> lineaPlato;



/**
 *	Atributo lineaMenu
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaMenuEN> lineaMenu;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaComandaEN> LineaComanda {
        get { return lineaComanda; } set { lineaComanda = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual double Stock {
        get { return stock; } set { stock = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaPlatoEN> LineaPlato {
        get { return lineaPlato; } set { lineaPlato = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaMenuEN> LineaMenu {
        get { return lineaMenu; } set { lineaMenu = value;  }
}





public PlatoEN()
{
        lineaComanda = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaComandaEN>();
        lineaPlato = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaPlatoEN>();
        lineaMenu = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaMenuEN>();
}



public PlatoEN(int id, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda, string nombre, double stock, double precio, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaPlatoEN> lineaPlato, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaMenuEN> lineaMenu
               )
{
        this.init (Id, lineaComanda, nombre, stock, precio, lineaPlato, lineaMenu);
}


public PlatoEN(PlatoEN plato)
{
        this.init (Id, plato.LineaComanda, plato.Nombre, plato.Stock, plato.Precio, plato.LineaPlato, plato.LineaMenu);
}

private void init (int id
                   , System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda, string nombre, double stock, double precio, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaPlatoEN> lineaPlato, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaMenuEN> lineaMenu)
{
        this.Id = id;


        this.LineaComanda = lineaComanda;

        this.Nombre = nombre;

        this.Stock = stock;

        this.Precio = precio;

        this.LineaPlato = lineaPlato;

        this.LineaMenu = lineaMenu;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PlatoEN t = obj as PlatoEN;
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
