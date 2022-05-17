using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace tpvhostGenEmpleadoRESTAzure.DTOA
{
public class RolCajeroDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}



/* Rol: RolCajero o--> Cajero */
private CajeroDTOA cajero;
public CajeroDTOA Cajero
{
        get { return cajero; }
        set { cajero = value; }
}
}
}
