using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class ProveedorDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string numeroTelefono;
public string NumeroTelefono {
        get { return numeroTelefono; } set { numeroTelefono = value;  }
}


private System.Collections.Generic.IList<int> compraProveedor_oid;
public System.Collections.Generic.IList<int> CompraProveedor_oid {
        get { return compraProveedor_oid; } set { compraProveedor_oid = value;  }
}

private string email;
public string Email {
        get { return email; } set { email = value;  }
}
}
}
