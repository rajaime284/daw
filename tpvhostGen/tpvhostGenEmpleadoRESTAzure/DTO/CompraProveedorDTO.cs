using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenEmpleadoRESTAzure.DTO
{
public partial class CompraProveedorDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private System.Collections.Generic.IList<LineaCompraProveedorDTO> lineaProveedor;
public System.Collections.Generic.IList<LineaCompraProveedorDTO> LineaProveedor {
        get { return lineaProveedor; } set { lineaProveedor = value;  }
}


private int proveedor_oid;
public int Proveedor_oid {
        get { return proveedor_oid; } set { proveedor_oid = value;  }
}



private int negocio_oid;
public int Negocio_oid {
        get { return negocio_oid; } set { negocio_oid = value;  }
}



private System.Collections.Generic.IList<int> pago_oid;
public System.Collections.Generic.IList<int> Pago_oid {
        get { return pago_oid; } set { pago_oid = value;  }
}

private double saldo;
public double Saldo {
        get { return saldo; } set { saldo = value;  }
}
private TpvhostGenNHibernate.Enumerated.Rest.EstadoCompraProveedorEnum estadoPedido;
public TpvhostGenNHibernate.Enumerated.Rest.EstadoCompraProveedorEnum EstadoPedido {
        get { return estadoPedido; } set { estadoPedido = value;  }
}
private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}
private double total;
public double Total {
        get { return total; } set { total = value;  }
}
}
}
