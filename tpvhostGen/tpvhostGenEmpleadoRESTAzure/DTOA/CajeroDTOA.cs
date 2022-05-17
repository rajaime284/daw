using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace tpvhostGenEmpleadoRESTAzure.DTOA
{
public class CajeroDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}



/* Rol: Cajero o--> Caja */
private IList<CajaDTOA> cajas;
public IList<CajaDTOA> Cajas
{
        get { return cajas; }
        set { cajas = value; }
}
}
}
