using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenEmpleadoRESTAzure.DTO
{
public partial class PlatoDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private System.Collections.Generic.IList<int> lineaComanda_oid;
public System.Collections.Generic.IList<int> LineaComanda_oid {
        get { return lineaComanda_oid; } set { lineaComanda_oid = value;  }
}



private System.Collections.Generic.IList<int> lineaPlato_oid;
public System.Collections.Generic.IList<int> LineaPlato_oid {
        get { return lineaPlato_oid; } set { lineaPlato_oid = value;  }
}

private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private double stock;
public double Stock {
        get { return stock; } set { stock = value;  }
}
private double precio;
public double Precio {
        get { return precio; } set { precio = value;  }
}


private System.Collections.Generic.IList<int> lineaMenu_oid;
public System.Collections.Generic.IList<int> LineaMenu_oid {
        get { return lineaMenu_oid; } set { lineaMenu_oid = value;  }
}
}
}
