using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace tpvhostGenEmpleadoRESTAzure.DTOA
{
public class RolCocineroDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}



/* Rol: RolCocinero o--> Cocinero */
private CocineroDTOA cocinero;
public CocineroDTOA Cocinero
{
        get { return cocinero; }
        set { cocinero = value; }
}
}
}
