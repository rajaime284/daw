using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace tpvhostGenTpvhostRESTAzure.DTOA
{
public class PlatoDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private string nombre;
public string Nombre
{
        get { return nombre; }
        set { nombre = value; }
}

private double precio;
public double Precio
{
        get { return precio; }
        set { precio = value; }
}


/* Rol: Plato o--> LineaPlato */
private IList<LineaPlatoDTOA> lineasPlato;
public IList<LineaPlatoDTOA> LineasPlato
{
        get { return lineasPlato; }
        set { lineasPlato = value; }
}
}
}
