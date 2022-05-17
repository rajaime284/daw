using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class MenuDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private double stock;
public double Stock {
        get { return stock; } set { stock = value;  }
}


private System.Collections.Generic.IList<int> lineaComanda_oid;
public System.Collections.Generic.IList<int> LineaComanda_oid {
        get { return lineaComanda_oid; } set { lineaComanda_oid = value;  }
}

private System.Collections.Generic.IList<LineaMenuDTO> lineaMenu;
public System.Collections.Generic.IList<LineaMenuDTO> LineaMenu {
        get { return lineaMenu; } set { lineaMenu = value;  }
}
}
}
