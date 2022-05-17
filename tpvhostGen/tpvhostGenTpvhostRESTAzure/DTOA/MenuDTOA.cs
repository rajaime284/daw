using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace tpvhostGenTpvhostRESTAzure.DTOA
{
public class MenuDTOA
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

private double stock;
public double Stock
{
        get { return stock; }
        set { stock = value; }
}


/* Rol: Menu o--> LineaMenu */
private IList<LineaMenuDTOA> lineasMenu;
public IList<LineaMenuDTOA> LineasMenu
{
        get { return lineasMenu; }
        set { lineasMenu = value; }
}
}
}
