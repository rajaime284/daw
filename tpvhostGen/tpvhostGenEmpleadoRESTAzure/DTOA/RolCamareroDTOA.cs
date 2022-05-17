using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace tpvhostGenEmpleadoRESTAzure.DTOA
{
public class RolCamareroDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}



/* Rol: RolCamarero o--> Camarero */
private CamareroDTOA camarero;
public CamareroDTOA Camarero
{
        get { return camarero; }
        set { camarero = value; }
}
}
}
