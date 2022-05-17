using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace tpvhostGenEmpleadoRESTAzure.DTOA
{
public class RolEncargadoDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}



/* Rol: RolEncargado o--> Encargado */
private EncargadoDTOA encargado;
public EncargadoDTOA Encargado
{
        get { return encargado; }
        set { encargado = value; }
}
}
}
