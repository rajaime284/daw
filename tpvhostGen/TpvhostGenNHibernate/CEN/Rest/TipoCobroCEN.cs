

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
 *      Definition of the class TipoCobroCEN
 *
 */
public partial class TipoCobroCEN
{
private ITipoCobroCAD _ITipoCobroCAD;

public TipoCobroCEN()
{
        this._ITipoCobroCAD = new TipoCobroCAD ();
}

public TipoCobroCEN(ITipoCobroCAD _ITipoCobroCAD)
{
        this._ITipoCobroCAD = _ITipoCobroCAD;
}

public ITipoCobroCAD get_ITipoCobroCAD ()
{
        return this._ITipoCobroCAD;
}

public int Nuevo (string p_descripcion)
{
        TipoCobroEN tipoCobroEN = null;
        int oid;

        //Initialized TipoCobroEN
        tipoCobroEN = new TipoCobroEN ();
        tipoCobroEN.Descripcion = p_descripcion;

        //Call to TipoCobroCAD

        oid = _ITipoCobroCAD.Nuevo (tipoCobroEN);
        return oid;
}

public void Modificar (int p_TipoCobro_OID, string p_descripcion)
{
        TipoCobroEN tipoCobroEN = null;

        //Initialized TipoCobroEN
        tipoCobroEN = new TipoCobroEN ();
        tipoCobroEN.Id = p_TipoCobro_OID;
        tipoCobroEN.Descripcion = p_descripcion;
        //Call to TipoCobroCAD

        _ITipoCobroCAD.Modificar (tipoCobroEN);
}

public void Eliminar (int id
                      )
{
        _ITipoCobroCAD.Eliminar (id);
}

public TipoCobroEN ReadOID (int id
                            )
{
        TipoCobroEN tipoCobroEN = null;

        tipoCobroEN = _ITipoCobroCAD.ReadOID (id);
        return tipoCobroEN;
}

public System.Collections.Generic.IList<TipoCobroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TipoCobroEN> list = null;

        list = _ITipoCobroCAD.ReadAll (first, size);
        return list;
}
}
}
