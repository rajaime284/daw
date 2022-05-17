

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
 *      Definition of the class LineaPlatoCEN
 *
 */
public partial class LineaPlatoCEN
{
private ILineaPlatoCAD _ILineaPlatoCAD;

public LineaPlatoCEN()
{
        this._ILineaPlatoCAD = new LineaPlatoCAD ();
}

public LineaPlatoCEN(ILineaPlatoCAD _ILineaPlatoCAD)
{
        this._ILineaPlatoCAD = _ILineaPlatoCAD;
}

public ILineaPlatoCAD get_ILineaPlatoCAD ()
{
        return this._ILineaPlatoCAD;
}

public int Nuevo (double p_cantidad, int p_producto, int p_plato)
{
        LineaPlatoEN lineaPlatoEN = null;
        int oid;

        //Initialized LineaPlatoEN
        lineaPlatoEN = new LineaPlatoEN ();
        lineaPlatoEN.Cantidad = p_cantidad;


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id
                lineaPlatoEN.Producto = new TpvhostGenNHibernate.EN.Rest.ProductoEN ();
                lineaPlatoEN.Producto.Id = p_producto;
        }


        if (p_plato != -1) {
                // El argumento p_plato -> Property plato es oid = false
                // Lista de oids id
                lineaPlatoEN.Plato = new TpvhostGenNHibernate.EN.Rest.PlatoEN ();
                lineaPlatoEN.Plato.Id = p_plato;
        }

        //Call to LineaPlatoCAD

        oid = _ILineaPlatoCAD.Nuevo (lineaPlatoEN);
        return oid;
}

public void Modificar (int p_LineaPlato_OID, double p_cantidad)
{
        LineaPlatoEN lineaPlatoEN = null;

        //Initialized LineaPlatoEN
        lineaPlatoEN = new LineaPlatoEN ();
        lineaPlatoEN.Id = p_LineaPlato_OID;
        lineaPlatoEN.Cantidad = p_cantidad;
        //Call to LineaPlatoCAD

        _ILineaPlatoCAD.Modificar (lineaPlatoEN);
}

public void Eliminar (int id
                      )
{
        _ILineaPlatoCAD.Eliminar (id);
}

public LineaPlatoEN ReadOID (int id
                             )
{
        LineaPlatoEN lineaPlatoEN = null;

        lineaPlatoEN = _ILineaPlatoCAD.ReadOID (id);
        return lineaPlatoEN;
}

public System.Collections.Generic.IList<LineaPlatoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaPlatoEN> list = null;

        list = _ILineaPlatoCAD.ReadAll (first, size);
        return list;
}
}
}
