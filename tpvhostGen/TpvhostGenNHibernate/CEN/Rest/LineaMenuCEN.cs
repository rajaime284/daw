

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
 *      Definition of the class LineaMenuCEN
 *
 */
public partial class LineaMenuCEN
{
private ILineaMenuCAD _ILineaMenuCAD;

public LineaMenuCEN()
{
        this._ILineaMenuCAD = new LineaMenuCAD ();
}

public LineaMenuCEN(ILineaMenuCAD _ILineaMenuCAD)
{
        this._ILineaMenuCAD = _ILineaMenuCAD;
}

public ILineaMenuCAD get_ILineaMenuCAD ()
{
        return this._ILineaMenuCAD;
}

public int Nuevo (int p_cantidad, int p_plato, int p_menu)
{
        LineaMenuEN lineaMenuEN = null;
        int oid;

        //Initialized LineaMenuEN
        lineaMenuEN = new LineaMenuEN ();
        lineaMenuEN.Cantidad = p_cantidad;


        if (p_plato != -1) {
                // El argumento p_plato -> Property plato es oid = false
                // Lista de oids id
                lineaMenuEN.Plato = new TpvhostGenNHibernate.EN.Rest.PlatoEN ();
                lineaMenuEN.Plato.Id = p_plato;
        }


        if (p_menu != -1) {
                // El argumento p_menu -> Property menu es oid = false
                // Lista de oids id
                lineaMenuEN.Menu = new TpvhostGenNHibernate.EN.Rest.MenuEN ();
                lineaMenuEN.Menu.Id = p_menu;
        }

        //Call to LineaMenuCAD

        oid = _ILineaMenuCAD.Nuevo (lineaMenuEN);
        return oid;
}

public void Modificar (int p_LineaMenu_OID, int p_cantidad)
{
        LineaMenuEN lineaMenuEN = null;

        //Initialized LineaMenuEN
        lineaMenuEN = new LineaMenuEN ();
        lineaMenuEN.Id = p_LineaMenu_OID;
        lineaMenuEN.Cantidad = p_cantidad;
        //Call to LineaMenuCAD

        _ILineaMenuCAD.Modificar (lineaMenuEN);
}

public void Eliminar (int id
                      )
{
        _ILineaMenuCAD.Eliminar (id);
}

public LineaMenuEN ReadOID (int id
                            )
{
        LineaMenuEN lineaMenuEN = null;

        lineaMenuEN = _ILineaMenuCAD.ReadOID (id);
        return lineaMenuEN;
}

public System.Collections.Generic.IList<LineaMenuEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaMenuEN> list = null;

        list = _ILineaMenuCAD.ReadAll (first, size);
        return list;
}
}
}
