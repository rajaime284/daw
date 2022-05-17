
using System;
// Definición clase CajeroEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class CajeroEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo rol
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.RolEN> rol;



/**
 *	Atributo caja
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> caja;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.RolEN> Rol {
        get { return rol; } set { rol = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> Caja {
        get { return caja; } set { caja = value;  }
}





public CajeroEN()
{
        rol = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.RolEN>();
        caja = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CajaEN>();
}



public CajeroEN(int id, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.RolEN> rol, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> caja
                )
{
        this.init (Id, rol, caja);
}


public CajeroEN(CajeroEN cajero)
{
        this.init (Id, cajero.Rol, cajero.Caja);
}

private void init (int id
                   , System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.RolEN> rol, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.CajaEN> caja)
{
        this.Id = id;


        this.Rol = rol;

        this.Caja = caja;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CajeroEN t = obj as CajeroEN;
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
