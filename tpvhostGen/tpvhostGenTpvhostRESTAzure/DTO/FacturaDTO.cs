using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class FacturaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string numero;
public string Numero {
        get { return numero; } set { numero = value;  }
}
private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}
private double precio;
public double Precio {
        get { return precio; } set { precio = value;  }
}
private string descripcion;
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


private int comanda_oid;
public int Comanda_oid {
        get { return comanda_oid; } set { comanda_oid = value;  }
}



private int cliente_oid;
public int Cliente_oid {
        get { return cliente_oid; } set { cliente_oid = value;  }
}
}
}
