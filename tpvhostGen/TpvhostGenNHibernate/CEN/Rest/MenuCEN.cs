

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using TpvhostGenNHibernate.Exceptions;

using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CAD.Rest;


namespace TpvhostGenNHibernate.CEN.Rest
{
/*
 *      Definition of the class MenuCEN
 *
 */
public partial class MenuCEN
{
private IMenuCAD _IMenuCAD;

public MenuCEN()
{
        this._IMenuCAD = new MenuCAD ();
}

public MenuCEN(IMenuCAD _IMenuCAD)
{
        this._IMenuCAD = _IMenuCAD;
}

public IMenuCAD get_IMenuCAD ()
{
        return this._IMenuCAD;
}

public int Nuevo (string p_nombre, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaMenuEN> p_lineaMenu)
{
        MenuEN menuEN = null;
        int oid;

        //Initialized MenuEN
        menuEN = new MenuEN ();
        menuEN.Nombre = p_nombre;

        menuEN.LineaMenu = p_lineaMenu;

        //Call to MenuCAD

        oid = _IMenuCAD.Nuevo (menuEN);
        return oid;
}

public void Modificar (int p_Menu_OID, string p_nombre)
{
        MenuEN menuEN = null;

        //Initialized MenuEN
        menuEN = new MenuEN ();
        menuEN.Id = p_Menu_OID;
        menuEN.Nombre = p_nombre;
        //Call to MenuCAD

        _IMenuCAD.Modificar (menuEN);
}

public void Eliminar (int id
                      )
{
        _IMenuCAD.Eliminar (id);
}

public MenuEN ReadOID (int id
                       )
{
        MenuEN menuEN = null;

        menuEN = _IMenuCAD.ReadOID (id);
        return menuEN;
}

public System.Collections.Generic.IList<MenuEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MenuEN> list = null;

        list = _IMenuCAD.ReadAll (first, size);
        return list;
}
}
}
