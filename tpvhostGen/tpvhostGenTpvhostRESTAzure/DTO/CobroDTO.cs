using System;
using System.Runtime.Serialization;
using TpvhostGenNHibernate.EN.Rest;

namespace tpvhostGenTpvhostRESTAzure.DTO
{
public partial class CobroDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private float monto;
public float Monto {
        get { return monto; } set { monto = value;  }
}


private int comanda_oid;
public int Comanda_oid {
        get { return comanda_oid; } set { comanda_oid = value;  }
}



private int cliente_oid;
public int Cliente_oid {
        get { return cliente_oid; } set { cliente_oid = value;  }
}

private string tipoDeCobro;
public string TipoDeCobro {
        get { return tipoDeCobro; } set { tipoDeCobro = value;  }
}


private int tipoCobro_oid;
public int TipoCobro_oid {
        get { return tipoCobro_oid; } set { tipoCobro_oid = value;  }
}



private System.Collections.Generic.IList<int> caja_oid;
public System.Collections.Generic.IList<int> Caja_oid {
        get { return caja_oid; } set { caja_oid = value;  }
}

private string numeroTransaccion;
public string NumeroTransaccion {
        get { return numeroTransaccion; } set { numeroTransaccion = value;  }
}
}
}
