using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class ComandaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private TpvhostGenNHibernate.Enumerated.Rest.EstadoComandaEnum estadoPedido;
public TpvhostGenNHibernate.Enumerated.Rest.EstadoComandaEnum EstadoPedido {
        get { return estadoPedido; } set { estadoPedido = value;  }
}


private int camarero_oid;
public int Camarero_oid {
        get { return camarero_oid; } set { camarero_oid = value;  }
}

private System.Collections.Generic.IList<LineaComandaDTO> lineaComanda;
public System.Collections.Generic.IList<LineaComandaDTO> LineaComanda {
        get { return lineaComanda; } set { lineaComanda = value;  }
}


private System.Collections.Generic.IList<int> pago_oid;
public System.Collections.Generic.IList<int> Pago_oid {
        get { return pago_oid; } set { pago_oid = value;  }
}



private int mesa_oid;
public int Mesa_oid {
        get { return mesa_oid; } set { mesa_oid = value;  }
}



private int factura_oid;
public int Factura_oid {
        get { return factura_oid; } set { factura_oid = value;  }
}

private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}
}
}
