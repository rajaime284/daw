
using System;
// Definición clase LineaComandaEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class LineaComandaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo comanda
 */
private TpvhostGenNHibernate.EN.Rest.ComandaEN comanda;



/**
 *	Atributo plato
 */
private TpvhostGenNHibernate.EN.Rest.PlatoEN plato;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo menu
 */
private TpvhostGenNHibernate.EN.Rest.MenuEN menu;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.ComandaEN Comanda {
        get { return comanda; } set { comanda = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.PlatoEN Plato {
        get { return plato; } set { plato = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.MenuEN Menu {
        get { return menu; } set { menu = value;  }
}





public LineaComandaEN()
{
}



public LineaComandaEN(int id, TpvhostGenNHibernate.EN.Rest.ComandaEN comanda, TpvhostGenNHibernate.EN.Rest.PlatoEN plato, int cantidad, TpvhostGenNHibernate.EN.Rest.MenuEN menu
                      )
{
        this.init (Id, comanda, plato, cantidad, menu);
}


public LineaComandaEN(LineaComandaEN lineaComanda)
{
        this.init (Id, lineaComanda.Comanda, lineaComanda.Plato, lineaComanda.Cantidad, lineaComanda.Menu);
}

private void init (int id
                   , TpvhostGenNHibernate.EN.Rest.ComandaEN comanda, TpvhostGenNHibernate.EN.Rest.PlatoEN plato, int cantidad, TpvhostGenNHibernate.EN.Rest.MenuEN menu)
{
        this.Id = id;


        this.Comanda = comanda;

        this.Plato = plato;

        this.Cantidad = cantidad;

        this.Menu = menu;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaComandaEN t = obj as LineaComandaEN;
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
