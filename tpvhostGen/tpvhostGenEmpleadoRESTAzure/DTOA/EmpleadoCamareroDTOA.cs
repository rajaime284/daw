using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace tpvhostGenEmpleadoRESTAzure.DTOA
{
public class EmpleadoCamareroDTOA
{
private int dNI;
public int DNI
{
        get { return dNI; }
        set { dNI = value; }
}

private string nombre;
public string Nombre
{
        get { return nombre; }
        set { nombre = value; }
}

private string apellidos;
public string Apellidos
{
        get { return apellidos; }
        set { apellidos = value; }
}
}
}
