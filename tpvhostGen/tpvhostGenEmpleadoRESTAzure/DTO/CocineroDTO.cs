using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenEmpleadoRESTAzure.DTO
{
public partial class CocineroDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private System.Collections.Generic.IList<int> rol_oid;
public System.Collections.Generic.IList<int> Rol_oid {
        get { return rol_oid; } set { rol_oid = value;  }
}
}
}
