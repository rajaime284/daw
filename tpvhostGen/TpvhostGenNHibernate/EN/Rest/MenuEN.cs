
using System;
// Definición clase MenuEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class MenuEN
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
 *	Atributo stock
 */
private double stock;



/**
 *	Atributo lineaComanda
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda;



/**
 *	Atributo lineaMenu
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaMenuEN> lineaMenu;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual double Stock {
        get { return stock; } set { stock = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaComandaEN> LineaComanda {
        get { return lineaComanda; } set { lineaComanda = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaMenuEN> LineaMenu {
        get { return lineaMenu; } set { lineaMenu = value;  }
}





public MenuEN()
{
        lineaComanda = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaComandaEN>();
        lineaMenu = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaMenuEN>();
}



public MenuEN(int id, string nombre, double stock, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaMenuEN> lineaMenu
              )
{
        this.init (Id, nombre, stock, lineaComanda, lineaMenu);
}


public MenuEN(MenuEN menu)
{
        this.init (Id, menu.Nombre, menu.Stock, menu.LineaComanda, menu.LineaMenu);
}

private void init (int id
                   , string nombre, double stock, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaMenuEN> lineaMenu)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Stock = stock;

        this.LineaComanda = lineaComanda;

        this.LineaMenu = lineaMenu;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MenuEN t = obj as MenuEN;
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
