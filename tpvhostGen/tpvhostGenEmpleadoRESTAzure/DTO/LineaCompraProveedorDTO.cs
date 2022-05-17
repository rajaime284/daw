using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenEmpleadoRESTAzure.DTO
{
public partial class LineaCompraProveedorDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private int cantidad;
public int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}


private int servicio_oid;
public int Servicio_oid {
        get { return servicio_oid; } set { servicio_oid = value;  }
}



private int pedidoProveedor_oid;
public int PedidoProveedor_oid {
        get { return pedidoProveedor_oid; } set { pedidoProveedor_oid = value;  }
}



private int producto_oid;
public int Producto_oid {
        get { return producto_oid; } set { producto_oid = value;  }
}
}
}
