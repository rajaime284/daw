using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class TipoCobroDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private System.Collections.Generic.IList<int> cobro_oid;
public System.Collections.Generic.IList<int> Cobro_oid {
        get { return cobro_oid; } set { cobro_oid = value;  }
}

private string descripcion;
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}
}
}
