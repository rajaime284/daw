
using System;
// Definición clase EmpleadoEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class EmpleadoEN
{
/**
 *	Atributo rol
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.RolEN> rol;



/**
 *	Atributo negocio
 */
private TpvhostGenNHibernate.EN.Rest.NegocioEN negocio;



/**
 *	Atributo dNI
 */
private int dNI;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo pass
 */
private String pass;






public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.RolEN> Rol {
        get { return rol; } set { rol = value;  }
}



public virtual TpvhostGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}



public virtual int DNI {
        get { return dNI; } set { dNI = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}





public EmpleadoEN()
{
        rol = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.RolEN>();
}



public EmpleadoEN(int dNI, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.RolEN> rol, TpvhostGenNHibernate.EN.Rest.NegocioEN negocio, string nombre, string apellidos, String pass
                  )
{
        this.init (DNI, rol, negocio, nombre, apellidos, pass);
}


public EmpleadoEN(EmpleadoEN empleado)
{
        this.init (DNI, empleado.Rol, empleado.Negocio, empleado.Nombre, empleado.Apellidos, empleado.Pass);
}

private void init (int DNI
                   , System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.RolEN> rol, TpvhostGenNHibernate.EN.Rest.NegocioEN negocio, string nombre, string apellidos, String pass)
{
        this.DNI = DNI;


        this.Rol = rol;

        this.Negocio = negocio;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EmpleadoEN t = obj as EmpleadoEN;
        if (t == null)
                return false;
        if (DNI.Equals (t.DNI))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.DNI.GetHashCode ();
        return hash;
}
}
}
