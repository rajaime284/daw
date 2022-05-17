
using System;
// Definición clase EncargadoEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class EncargadoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo rol
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.RolEN> rol;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.RolEN> Rol {
        get { return rol; } set { rol = value;  }
}





public EncargadoEN()
{
        rol = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.RolEN>();
}



public EncargadoEN(int id, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.RolEN> rol
                   )
{
        this.init (Id, rol);
}


public EncargadoEN(EncargadoEN encargado)
{
        this.init (Id, encargado.Rol);
}

private void init (int id
                   , System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.RolEN> rol)
{
        this.Id = id;


        this.Rol = rol;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EncargadoEN t = obj as EncargadoEN;
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
