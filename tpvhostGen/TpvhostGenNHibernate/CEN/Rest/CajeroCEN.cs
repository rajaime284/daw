

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
 *      Definition of the class CajeroCEN
 *
 */
public partial class CajeroCEN
{
private ICajeroCAD _ICajeroCAD;

public CajeroCEN()
{
        this._ICajeroCAD = new CajeroCAD ();
}

public CajeroCEN(ICajeroCAD _ICajeroCAD)
{
        this._ICajeroCAD = _ICajeroCAD;
}

public ICajeroCAD get_ICajeroCAD ()
{
        return this._ICajeroCAD;
}

public int Nuevo (System.Collections.Generic.IList<int> p_caja)
{
        CajeroEN cajeroEN = null;
        int oid;

        //Initialized CajeroEN
        cajeroEN = new CajeroEN ();

        cajeroEN.Caja = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CajaEN>();
        if (p_caja != null) {
                foreach (int item in p_caja) {
                        TpvhostGenNHibernate.EN.Rest.CajaEN en = new TpvhostGenNHibernate.EN.Rest.CajaEN ();
                        en.Id = item;
                        cajeroEN.Caja.Add (en);
                }
        }

        else{
                cajeroEN.Caja = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CajaEN>();
        }

        //Call to CajeroCAD

        oid = _ICajeroCAD.Nuevo (cajeroEN);
        return oid;
}

public void Modificar (int p_Cajero_OID)
{
        CajeroEN cajeroEN = null;

        //Initialized CajeroEN
        cajeroEN = new CajeroEN ();
        cajeroEN.Id = p_Cajero_OID;
        //Call to CajeroCAD

        _ICajeroCAD.Modificar (cajeroEN);
}

public void Eliminar (int id
                      )
{
        _ICajeroCAD.Eliminar (id);
}

public CajeroEN ReadOID (int id
                         )
{
        CajeroEN cajeroEN = null;

        cajeroEN = _ICajeroCAD.ReadOID (id);
        return cajeroEN;
}

public System.Collections.Generic.IList<CajeroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CajeroEN> list = null;

        list = _ICajeroCAD.ReadAll (first, size);
        return list;
}
}
}
