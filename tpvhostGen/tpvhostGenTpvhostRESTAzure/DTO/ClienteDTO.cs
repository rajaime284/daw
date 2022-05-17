using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class ClienteDTO
{
private string dni;
public string Dni {
        get { return dni; } set { dni = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string apellidos;
public string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}


private System.Collections.Generic.IList<int> factura_oid;
public System.Collections.Generic.IList<int> Factura_oid {
        get { return factura_oid; } set { factura_oid = value;  }
}



private System.Collections.Generic.IList<int> cobro_oid;
public System.Collections.Generic.IList<int> Cobro_oid {
        get { return cobro_oid; } set { cobro_oid = value;  }
}

private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private int negocio_oid;
public int Negocio_oid {
        get { return negocio_oid; } set { negocio_oid = value;  }
}
}
}
