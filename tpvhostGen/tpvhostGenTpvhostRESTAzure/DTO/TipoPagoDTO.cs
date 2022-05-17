using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class TipoPagoDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string descripcion;
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


private System.Collections.Generic.IList<int> pago_oid;
public System.Collections.Generic.IList<int> Pago_oid {
        get { return pago_oid; } set { pago_oid = value;  }
}
}
}
