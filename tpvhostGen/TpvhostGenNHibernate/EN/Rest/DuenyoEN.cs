
using System;
// Definición clase DuenyoEN
namespace TpvhostGenNHibernate.EN.Rest
{
public partial class DuenyoEN
{
/**
 *	Atributo dni
 */
private string dni;



/**
 *	Atributo empresa
 */
private System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.EmpresaEN> empresa;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellido
 */
private string apellido;



/**
 *	Atributo telefono
 */
private string telefono;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo id
 */
private int id;






public virtual string Dni {
        get { return dni; } set { dni = value;  }
}



public virtual System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.EmpresaEN> Empresa {
        get { return empresa; } set { empresa = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellido {
        get { return apellido; } set { apellido = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public DuenyoEN()
{
        empresa = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.EmpresaEN>();
}



public DuenyoEN(int id, string dni, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.EmpresaEN> empresa, string nombre, string apellido, string telefono, String pass
                )
{
        this.init (Id, dni, empresa, nombre, apellido, telefono, pass);
}


public DuenyoEN(DuenyoEN duenyo)
{
        this.init (Id, duenyo.Dni, duenyo.Empresa, duenyo.Nombre, duenyo.Apellido, duenyo.Telefono, duenyo.Pass);
}

private void init (int id
                   , string dni, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.EmpresaEN> empresa, string nombre, string apellido, string telefono, String pass)
{
        this.Id = id;


        this.Dni = dni;

        this.Empresa = empresa;

        this.Nombre = nombre;

        this.Apellido = apellido;

        this.Telefono = telefono;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DuenyoEN t = obj as DuenyoEN;
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
