using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class LineaComandaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private int comanda_oid;
public int Comanda_oid {
        get { return comanda_oid; } set { comanda_oid = value;  }
}



private int plato_oid;
public int Plato_oid {
        get { return plato_oid; } set { plato_oid = value;  }
}

private int cantidad;
public int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}


private int menu_oid;
public int Menu_oid {
        get { return menu_oid; } set { menu_oid = value;  }
}
}
}
