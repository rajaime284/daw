

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
 *      Definition of the class CamareroCEN
 *
 */
public partial class CamareroCEN
{
private ICamareroCAD _ICamareroCAD;

public CamareroCEN()
{
        this._ICamareroCAD = new CamareroCAD ();
}

public CamareroCEN(ICamareroCAD _ICamareroCAD)
{
        this._ICamareroCAD = _ICamareroCAD;
}

public ICamareroCAD get_ICamareroCAD ()
{
        return this._ICamareroCAD;
}

public int Nuevo ()
{
        CamareroEN camareroEN = null;
        int oid;

        //Initialized CamareroEN
        camareroEN = new CamareroEN ();
        //Call to CamareroCAD

        oid = _ICamareroCAD.Nuevo (camareroEN);
        return oid;
}

public void Modificar (int p_Camarero_OID)
{
        CamareroEN camareroEN = null;

        //Initialized CamareroEN
        camareroEN = new CamareroEN ();
        camareroEN.Id = p_Camarero_OID;
        //Call to CamareroCAD

        _ICamareroCAD.Modificar (camareroEN);
}

public void Eliminar (int id
                      )
{
        _ICamareroCAD.Eliminar (id);
}

public CamareroEN ReadOID (int id
                           )
{
        CamareroEN camareroEN = null;

        camareroEN = _ICamareroCAD.ReadOID (id);
        return camareroEN;
}

public System.Collections.Generic.IList<CamareroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CamareroEN> list = null;

        list = _ICamareroCAD.ReadAll (first, size);
        return list;
}
}
}
