using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace tpvhostGenEmpleadoRESTAzure.DTOA
{
public class LineaPedidoDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private int cantidad;
public int Cantidad
{
        get { return cantidad; }
        set { cantidad = value; }
}


/* Rol: LineaPedido o--> Plato */
private PlatoDTOA platos;
public PlatoDTOA Platos
{
        get { return platos; }
        set { platos = value; }
}
}
}
