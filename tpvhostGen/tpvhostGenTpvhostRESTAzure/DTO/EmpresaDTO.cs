using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class EmpresaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string direccion;
public string Direccion {
        get { return direccion; } set { direccion = value;  }
}


private int due�o_oid;
public int Due�o_oid {
        get { return due�o_oid; } set { due�o_oid = value;  }
}



private System.Collections.Generic.IList<int> negocio_oid;
public System.Collections.Generic.IList<int> Negocio_oid {
        get { return negocio_oid; } set { negocio_oid = value;  }
}
}
}
