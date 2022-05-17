using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class EmpleadoDTO
{
private System.Collections.Generic.IList<int> rol_oid;
public System.Collections.Generic.IList<int> Rol_oid {
        get { return rol_oid; } set { rol_oid = value;  }
}



private int negocio_oid;
public int Negocio_oid {
        get { return negocio_oid; } set { negocio_oid = value;  }
}

private int dNI;
public int DNI {
        get { return dNI; } set { dNI = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string apellidos;
public string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}
private String pass;
public String Pass {
        get { return pass; } set { pass = value;  }
}
}
}
