using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class NegocioDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string direccion;
public string Direccion {
        get { return direccion; } set { direccion = value;  }
}
private string ciudad;
public string Ciudad {
        get { return ciudad; } set { ciudad = value;  }
}
private string cp;
public string Cp {
        get { return cp; } set { cp = value;  }
}
private string provincia;
public string Provincia {
        get { return provincia; } set { provincia = value;  }
}
private string pais;
public string Pais {
        get { return pais; } set { pais = value;  }
}


private System.Collections.Generic.IList<int> servicios_oid;
public System.Collections.Generic.IList<int> Servicios_oid {
        get { return servicios_oid; } set { servicios_oid = value;  }
}



private int empresa_oid;
public int Empresa_oid {
        get { return empresa_oid; } set { empresa_oid = value;  }
}



private System.Collections.Generic.IList<int> mesa_oid;
public System.Collections.Generic.IList<int> Mesa_oid {
        get { return mesa_oid; } set { mesa_oid = value;  }
}



private System.Collections.Generic.IList<int> caja_oid;
public System.Collections.Generic.IList<int> Caja_oid {
        get { return caja_oid; } set { caja_oid = value;  }
}



private System.Collections.Generic.IList<int> compraProveedor_oid;
public System.Collections.Generic.IList<int> CompraProveedor_oid {
        get { return compraProveedor_oid; } set { compraProveedor_oid = value;  }
}



private System.Collections.Generic.IList<int> producto_oid;
public System.Collections.Generic.IList<int> Producto_oid {
        get { return producto_oid; } set { producto_oid = value;  }
}



private System.Collections.Generic.IList<int> empleado_oid;
public System.Collections.Generic.IList<int> Empleado_oid {
        get { return empleado_oid; } set { empleado_oid = value;  }
}



private System.Collections.Generic.IList<int> cliente_oid;
public System.Collections.Generic.IList<int> Cliente_oid {
        get { return cliente_oid; } set { cliente_oid = value;  }
}
}
}
