

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
 *      Definition of the class UnidadMedidaCEN
 *
 */
public partial class UnidadMedidaCEN
{
private IUnidadMedidaCAD _IUnidadMedidaCAD;

public UnidadMedidaCEN()
{
        this._IUnidadMedidaCAD = new UnidadMedidaCAD ();
}

public UnidadMedidaCEN(IUnidadMedidaCAD _IUnidadMedidaCAD)
{
        this._IUnidadMedidaCAD = _IUnidadMedidaCAD;
}

public IUnidadMedidaCAD get_IUnidadMedidaCAD ()
{
        return this._IUnidadMedidaCAD;
}

public int Nuevo (string p_descripcion)
{
        UnidadMedidaEN unidadMedidaEN = null;
        int oid;

        //Initialized UnidadMedidaEN
        unidadMedidaEN = new UnidadMedidaEN ();
        unidadMedidaEN.Descripcion = p_descripcion;

        //Call to UnidadMedidaCAD

        oid = _IUnidadMedidaCAD.Nuevo (unidadMedidaEN);
        return oid;
}

public void Modificar (int p_UnidadMedida_OID, string p_descripcion)
{
        UnidadMedidaEN unidadMedidaEN = null;

        //Initialized UnidadMedidaEN
        unidadMedidaEN = new UnidadMedidaEN ();
        unidadMedidaEN.Id = p_UnidadMedida_OID;
        unidadMedidaEN.Descripcion = p_descripcion;
        //Call to UnidadMedidaCAD

        _IUnidadMedidaCAD.Modificar (unidadMedidaEN);
}

public void Eliminar (int id
                      )
{
        _IUnidadMedidaCAD.Eliminar (id);
}

public UnidadMedidaEN ReadOID (int id
                               )
{
        UnidadMedidaEN unidadMedidaEN = null;

        unidadMedidaEN = _IUnidadMedidaCAD.ReadOID (id);
        return unidadMedidaEN;
}

public System.Collections.Generic.IList<UnidadMedidaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UnidadMedidaEN> list = null;

        list = _IUnidadMedidaCAD.ReadAll (first, size);
        return list;
}
}
}
