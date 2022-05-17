
using System;
// Definición clase ComandaEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class ComandaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo estadoPedido
 */
private TpvhostGenNHibernate.Enumerated.Rest.EstadoComandaEnum estadoPedido;



/**
 *	Atributo camarero
 */
private TpvhostGenNHibernate.EN.Rest.CamareroEN camarero;



/**
 *	Atributo lineaComanda
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda;



/**
 *	Atributo pago
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> pago;



/**
 *	Atributo mesa
 */
private TpvhostGenNHibernate.EN.Rest.MesaEN mesa;



/**
 *	Atributo factura
 */
private TpvhostGenNHibernate.EN.Rest.FacturaEN factura;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TpvhostGenNHibernate.Enumerated.Rest.EstadoComandaEnum EstadoPedido {
        get { return estadoPedido; } set { estadoPedido = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.CamareroEN Camarero {
        get { return camarero; } set { camarero = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaComandaEN> LineaComanda {
        get { return lineaComanda; } set { lineaComanda = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> Pago {
        get { return pago; } set { pago = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.MesaEN Mesa {
        get { return mesa; } set { mesa = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.FacturaEN Factura {
        get { return factura; } set { factura = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public ComandaEN()
{
        lineaComanda = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaComandaEN>();
        pago = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CobroEN>();
}



public ComandaEN(int id, TpvhostGenNHibernate.Enumerated.Rest.EstadoComandaEnum estadoPedido, TpvhostGenNHibernate.EN.Rest.CamareroEN camarero, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> pago, TpvhostGenNHibernate.EN.Rest.MesaEN mesa, TpvhostGenNHibernate.EN.Rest.FacturaEN factura, Nullable<DateTime> fecha
                 )
{
        this.init (Id, estadoPedido, camarero, lineaComanda, pago, mesa, factura, fecha);
}


public ComandaEN(ComandaEN comanda)
{
        this.init (Id, comanda.EstadoPedido, comanda.Camarero, comanda.LineaComanda, comanda.Pago, comanda.Mesa, comanda.Factura, comanda.Fecha);
}

private void init (int id
                   , TpvhostGenNHibernate.Enumerated.Rest.EstadoComandaEnum estadoPedido, TpvhostGenNHibernate.EN.Rest.CamareroEN camarero, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CobroEN> pago, TpvhostGenNHibernate.EN.Rest.MesaEN mesa, TpvhostGenNHibernate.EN.Rest.FacturaEN factura, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.EstadoPedido = estadoPedido;

        this.Camarero = camarero;

        this.LineaComanda = lineaComanda;

        this.Pago = pago;

        this.Mesa = mesa;

        this.Factura = factura;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComandaEN t = obj as ComandaEN;
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
