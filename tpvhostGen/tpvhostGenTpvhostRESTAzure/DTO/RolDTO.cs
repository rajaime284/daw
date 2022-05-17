using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class RolDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private int cajero_oid;
public int Cajero_oid {
        get { return cajero_oid; } set { cajero_oid = value;  }
}



private int cocinero_oid;
public int Cocinero_oid {
        get { return cocinero_oid; } set { cocinero_oid = value;  }
}



private int encargado_oid;
public int Encargado_oid {
        get { return encargado_oid; } set { encargado_oid = value;  }
}



private int camarero_oid;
public int Camarero_oid {
        get { return camarero_oid; } set { camarero_oid = value;  }
}

private TpvhostGenNHibernate.Enumerated.Rest.EmpleoEnum empleo;
public TpvhostGenNHibernate.Enumerated.Rest.EmpleoEnum Empleo {
        get { return empleo; } set { empleo = value;  }
}


private int empleado_oid;
public int Empleado_oid {
        get { return empleado_oid; } set { empleado_oid = value;  }
}
}
}
