using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class LineaPlatoDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private double cantidad;
public double Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}


private int producto_oid;
public int Producto_oid {
        get { return producto_oid; } set { producto_oid = value;  }
}



private int plato_oid;
public int Plato_oid {
        get { return plato_oid; } set { plato_oid = value;  }
}
}
}
