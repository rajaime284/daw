

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
 *      Definition of the class TipoPagoCEN
 *
 */
public partial class TipoPagoCEN
{
private ITipoPagoCAD _ITipoPagoCAD;

public TipoPagoCEN()
{
        this._ITipoPagoCAD = new TipoPagoCAD ();
}

public TipoPagoCEN(ITipoPagoCAD _ITipoPagoCAD)
{
        this._ITipoPagoCAD = _ITipoPagoCAD;
}

public ITipoPagoCAD get_ITipoPagoCAD ()
{
        return this._ITipoPagoCAD;
}

public int Nuevo (string p_descripcion)
{
        TipoPagoEN tipoPagoEN = null;
        int oid;

        //Initialized TipoPagoEN
        tipoPagoEN = new TipoPagoEN ();
        tipoPagoEN.Descripcion = p_descripcion;

        //Call to TipoPagoCAD

        oid = _ITipoPagoCAD.Nuevo (tipoPagoEN);
        return oid;
}

public void Modificar (int p_tipoPago_OID, string p_descripcion)
{
        TipoPagoEN tipoPagoEN = null;

        //Initialized TipoPagoEN
        tipoPagoEN = new TipoPagoEN ();
        tipoPagoEN.Id = p_tipoPago_OID;
        tipoPagoEN.Descripcion = p_descripcion;
        //Call to TipoPagoCAD

        _ITipoPagoCAD.Modificar (tipoPagoEN);
}

public void Eliminar (int id
                      )
{
        _ITipoPagoCAD.Eliminar (id);
}

public TipoPagoEN ReadOID (int id
                           )
{
        TipoPagoEN tipoPagoEN = null;

        tipoPagoEN = _ITipoPagoCAD.ReadOID (id);
        return tipoPagoEN;
}

public System.Collections.Generic.IList<TipoPagoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TipoPagoEN> list = null;

        list = _ITipoPagoCAD.ReadAll (first, size);
        return list;
}
}
}
