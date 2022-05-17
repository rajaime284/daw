using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class UnidadMedidaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string descripcion;
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


private System.Collections.Generic.IList<int> producto_oid;
public System.Collections.Generic.IList<int> Producto_oid {
        get { return producto_oid; } set { producto_oid = value;  }
}
}
}
