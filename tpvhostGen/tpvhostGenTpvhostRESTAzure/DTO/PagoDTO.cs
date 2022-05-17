using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
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


private System.Collections.Generic.IList<int> compraProveedor_oid;
public System.Collections.Generic.IList<int> CompraProveedor_oid {
        get { return compraProveedor_oid; } set { compraProveedor_oid = value;  }
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
