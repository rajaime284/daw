
using System;
// Definición clase MetodoPagoEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class MetodoPagoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo pago
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.PagoEN> pago;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.PagoEN> Pago {
        get { return pago; } set { pago = value;  }
}





public MetodoPagoEN()
{
        pago = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.PagoEN>();
}



public MetodoPagoEN(int id, string descripcion, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.PagoEN> pago
                    )
{
        this.init (Id, descripcion, pago);
}


public MetodoPagoEN(MetodoPagoEN metodoPago)
{
        this.init (Id, metodoPago.Descripcion, metodoPago.Pago);
}

private void init (int id
                   , string descripcion, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.PagoEN> pago)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Pago = pago;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MetodoPagoEN t = obj as MetodoPagoEN;
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
