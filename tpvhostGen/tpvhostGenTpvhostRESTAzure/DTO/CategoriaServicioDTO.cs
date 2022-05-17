using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class CategoriaServicioDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private System.Collections.Generic.IList<int> servicio_oid;
public System.Collections.Generic.IList<int> Servicio_oid {
        get { return servicio_oid; } set { servicio_oid = value;  }
}

private string descripcion;
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}
}
}
