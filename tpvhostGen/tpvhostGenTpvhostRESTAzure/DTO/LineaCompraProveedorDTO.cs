using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
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



private int compraProveedor_oid;
public int CompraProveedor_oid {
        get { return compraProveedor_oid; } set { compraProveedor_oid = value;  }
}



private int producto_oid;
public int Producto_oid {
        get { return producto_oid; } set { producto_oid = value;  }
}

private double costo;
public double Costo {
        get { return costo; } set { costo = value;  }
}
}
}
