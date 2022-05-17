

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
 *      Definition of the class CocineroCEN
 *
 */
public partial class CocineroCEN
{
private ICocineroCAD _ICocineroCAD;

public CocineroCEN()
{
        this._ICocineroCAD = new CocineroCAD ();
}

public CocineroCEN(ICocineroCAD _ICocineroCAD)
{
        this._ICocineroCAD = _ICocineroCAD;
}

public ICocineroCAD get_ICocineroCAD ()
{
        return this._ICocineroCAD;
}

public int Nuevo ()
{
        CocineroEN cocineroEN = null;
        int oid;

        //Initialized CocineroEN
        cocineroEN = new CocineroEN ();
        //Call to CocineroCAD

        oid = _ICocineroCAD.Nuevo (cocineroEN);
        return oid;
}

public void Modificar (int p_Cocinero_OID)
{
        CocineroEN cocineroEN = null;

        //Initialized CocineroEN
        cocineroEN = new CocineroEN ();
        cocineroEN.Id = p_Cocinero_OID;
        //Call to CocineroCAD

        _ICocineroCAD.Modificar (cocineroEN);
}

public void Eliminar (int id
                      )
{
        _ICocineroCAD.Eliminar (id);
}

public CocineroEN ReadOID (int id
                           )
{
        CocineroEN cocineroEN = null;

        cocineroEN = _ICocineroCAD.ReadOID (id);
        return cocineroEN;
}

public System.Collections.Generic.IList<CocineroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CocineroEN> list = null;

        list = _ICocineroCAD.ReadAll (first, size);
        return list;
}
}
}
