using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class DuenyoDTO
{
private string dni;
public string Dni {
        get { return dni; } set { dni = value;  }
}


private System.Collections.Generic.IList<int> empresa_oid;
public System.Collections.Generic.IList<int> Empresa_oid {
        get { return empresa_oid; } set { empresa_oid = value;  }
}

private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string apellido;
public string Apellido {
        get { return apellido; } set { apellido = value;  }
}
private string telefono;
public string Telefono {
        get { return telefono; } set { telefono = value;  }
}
private String pass;
public String Pass {
        get { return pass; } set { pass = value;  }
}
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
}
}
