using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenEmpleadoRESTAzure.DTO
{
public partial class PagoDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private System.Collections.Generic.IList<int> idPedidoProveedor;
public System.Collections.Generic.IList<int> IdPedidoProveedor {
        get { return idPedidoProveedor; } set { idPedidoProveedor = value;  }
}
private double monto;
public double Monto {
        get { return monto; } set { monto = value;  }
}


private System.Collections.Generic.IList<int> pedidoProveedor_oid;
public System.Collections.Generic.IList<int> PedidoProveedor_oid {
        get { return pedidoProveedor_oid; } set { pedidoProveedor_oid = value;  }
}

private Nullable<DateTime> fechaPago;
public Nullable<DateTime> FechaPago {
        get { return fechaPago; } set { fechaPago = value;  }
}


private int tipoPago_oid;
public int TipoPago_oid {
        get { return tipoPago_oid; } set { tipoPago_oid = value;  }
}

private int numeroDocumento;
public int NumeroDocumento {
        get { return numeroDocumento; } set { numeroDocumento = value;  }
}


private System.Collections.Generic.IList<int> caja_oid;
public System.Collections.Generic.IList<int> Caja_oid {
        get { return caja_oid; } set { caja_oid = value;  }
}
}
}
