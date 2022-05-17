

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
 *      Definition of the class LineaComandaCEN
 *
 */
public partial class LineaComandaCEN
{
private ILineaComandaCAD _ILineaComandaCAD;

public LineaComandaCEN()
{
        this._ILineaComandaCAD = new LineaComandaCAD ();
}

public LineaComandaCEN(ILineaComandaCAD _ILineaComandaCAD)
{
        this._ILineaComandaCAD = _ILineaComandaCAD;
}

public ILineaComandaCAD get_ILineaComandaCAD ()
{
        return this._ILineaComandaCAD;
}

public void Modificar (int p_LineaComanda_OID, int p_cantidad)
{
        LineaComandaEN lineaComandaEN = null;

        //Initialized LineaComandaEN
        lineaComandaEN = new LineaComandaEN ();
        lineaComandaEN.Id = p_LineaComanda_OID;
        lineaComandaEN.Cantidad = p_cantidad;
        //Call to LineaComandaCAD

        _ILineaComandaCAD.Modificar (lineaComandaEN);
}

public void Eliminar (int id
                      )
{
        _ILineaComandaCAD.Eliminar (id);
}

public int NuevaLineaPlato (int p_comanda, int p_cantidad)
{
        LineaComandaEN lineaComandaEN = null;
        int oid;

        //Initialized LineaComandaEN
        lineaComandaEN = new LineaComandaEN ();

        if (p_comanda != -1) {
                // El argumento p_comanda -> Property comanda es oid = false
                // Lista de oids id
                lineaComandaEN.Comanda = new TpvhostGenNHibernate.EN.Rest.ComandaEN ();
                lineaComandaEN.Comanda.Id = p_comanda;
        }

        lineaComandaEN.Cantidad = p_cantidad;

        //Call to LineaComandaCAD

        oid = _ILineaComandaCAD.NuevaLineaPlato (lineaComandaEN);
        return oid;
}

public LineaComandaEN ReadOID (int id
                               )
{
        LineaComandaEN lineaComandaEN = null;

        lineaComandaEN = _ILineaComandaCAD.ReadOID (id);
        return lineaComandaEN;
}

public System.Collections.Generic.IList<LineaComandaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaComandaEN> list = null;

        list = _ILineaComandaCAD.ReadAll (first, size);
        return list;
}
public int NuevaLineaMenu (int p_comanda, int p_cantidad)
{
        LineaComandaEN lineaComandaEN = null;
        int oid;

        //Initialized LineaComandaEN
        lineaComandaEN = new LineaComandaEN ();

        if (p_comanda != -1) {
                // El argumento p_comanda -> Property comanda es oid = false
                // Lista de oids id
                lineaComandaEN.Comanda = new TpvhostGenNHibernate.EN.Rest.ComandaEN ();
                lineaComandaEN.Comanda.Id = p_comanda;
        }

        lineaComandaEN.Cantidad = p_cantidad;

        //Call to LineaComandaCAD

        oid = _ILineaComandaCAD.NuevaLineaMenu (lineaComandaEN);
        return oid;
}
}
}
