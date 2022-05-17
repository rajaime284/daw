using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class ServicioDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private int negocio_oid;
public int Negocio_oid {
        get { return negocio_oid; } set { negocio_oid = value;  }
}

private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private double costo;
public double Costo {
        get { return costo; } set { costo = value;  }
}
private System.Collections.Generic.IList<LineaCompraProveedorDTO> lineaProveedor;
public System.Collections.Generic.IList<LineaCompraProveedorDTO> LineaProveedor {
        get { return lineaProveedor; } set { lineaProveedor = value;  }
}
private string codigoContrato;
public string CodigoContrato {
        get { return codigoContrato; } set { codigoContrato = value;  }
}


private int categoriaServicio_oid;
public int CategoriaServicio_oid {
        get { return categoriaServicio_oid; } set { categoriaServicio_oid = value;  }
}
}
}
