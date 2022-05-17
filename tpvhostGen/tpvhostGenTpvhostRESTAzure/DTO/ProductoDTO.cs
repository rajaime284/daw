using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class ProductoDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private double stock;
public double Stock {
        get { return stock; } set { stock = value;  }
}


private int unidadMedida_oid;
public int UnidadMedida_oid {
        get { return unidadMedida_oid; } set { unidadMedida_oid = value;  }
}

private System.Collections.Generic.IList<LineaCompraProveedorDTO> lineaCompraProveedor;
public System.Collections.Generic.IList<LineaCompraProveedorDTO> LineaCompraProveedor {
        get { return lineaCompraProveedor; } set { lineaCompraProveedor = value;  }
}


private System.Collections.Generic.IList<int> lineaPlato_oid;
public System.Collections.Generic.IList<int> LineaPlato_oid {
        get { return lineaPlato_oid; } set { lineaPlato_oid = value;  }
}



private int negocio_oid;
public int Negocio_oid {
        get { return negocio_oid; } set { negocio_oid = value;  }
}

private string descripcion;
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}
}
}
