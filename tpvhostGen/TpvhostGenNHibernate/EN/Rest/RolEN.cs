
using System;
// Definición clase RolEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class RolEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cajero
 */
private TpvhostGenNHibernate.EN.Rest.CajeroEN cajero;



/**
 *	Atributo cocinero
 */
private TpvhostGenNHibernate.EN.Rest.CocineroEN cocinero;



/**
 *	Atributo encargado
 */
private TpvhostGenNHibernate.EN.Rest.EncargadoEN encargado;



/**
 *	Atributo camarero
 */
private TpvhostGenNHibernate.EN.Rest.CamareroEN camarero;



/**
 *	Atributo empleo
 */
private TpvhostGenNHibernate.Enumerated.Rest.EmpleoEnum empleo;



/**
 *	Atributo empleado
 */
private TpvhostGenNHibernate.EN.Rest.EmpleadoEN empleado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.CajeroEN Cajero {
        get { return cajero; } set { cajero = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.CocineroEN Cocinero {
        get { return cocinero; } set { cocinero = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.EncargadoEN Encargado {
        get { return encargado; } set { encargado = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.CamareroEN Camarero {
        get { return camarero; } set { camarero = value;  }
}



public virtual TpvhostGenNHibernate.Enumerated.Rest.EmpleoEnum Empleo {
        get { return empleo; } set { empleo = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.EmpleadoEN Empleado {
        get { return empleado; } set { empleado = value;  }
}





public RolEN()
{
}



public RolEN(int id, TpvhostGenNHibernate.EN.Rest.CajeroEN cajero, TpvhostGenNHibernate.EN.Rest.CocineroEN cocinero, TpvhostGenNHibernate.EN.Rest.EncargadoEN encargado, TpvhostGenNHibernate.EN.Rest.CamareroEN camarero, TpvhostGenNHibernate.Enumerated.Rest.EmpleoEnum empleo, TpvhostGenNHibernate.EN.Rest.EmpleadoEN empleado
             )
{
        this.init (Id, cajero, cocinero, encargado, camarero, empleo, empleado);
}


public RolEN(RolEN rol)
{
        this.init (Id, rol.Cajero, rol.Cocinero, rol.Encargado, rol.Camarero, rol.Empleo, rol.Empleado);
}

private void init (int id
                   , TpvhostGenNHibernate.EN.Rest.CajeroEN cajero, TpvhostGenNHibernate.EN.Rest.CocineroEN cocinero, TpvhostGenNHibernate.EN.Rest.EncargadoEN encargado, TpvhostGenNHibernate.EN.Rest.CamareroEN camarero, TpvhostGenNHibernate.Enumerated.Rest.EmpleoEnum empleo, TpvhostGenNHibernate.EN.Rest.EmpleadoEN empleado)
{
        this.Id = id;


        this.Cajero = cajero;

        this.Cocinero = cocinero;

        this.Encargado = encargado;

        this.Camarero = camarero;

        this.Empleo = empleo;

        this.Empleado = empleado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RolEN t = obj as RolEN;
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
