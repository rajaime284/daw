

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
 *      Definition of the class CategoriaServicioCEN
 *
 */
public partial class CategoriaServicioCEN
{
private ICategoriaServicioCAD _ICategoriaServicioCAD;

public CategoriaServicioCEN()
{
        this._ICategoriaServicioCAD = new CategoriaServicioCAD ();
}

public CategoriaServicioCEN(ICategoriaServicioCAD _ICategoriaServicioCAD)
{
        this._ICategoriaServicioCAD = _ICategoriaServicioCAD;
}

public ICategoriaServicioCAD get_ICategoriaServicioCAD ()
{
        return this._ICategoriaServicioCAD;
}

public int Nuevo (string p_descripcion)
{
        CategoriaServicioEN categoriaServicioEN = null;
        int oid;

        //Initialized CategoriaServicioEN
        categoriaServicioEN = new CategoriaServicioEN ();
        categoriaServicioEN.Descripcion = p_descripcion;

        //Call to CategoriaServicioCAD

        oid = _ICategoriaServicioCAD.Nuevo (categoriaServicioEN);
        return oid;
}

public void Modificar (int p_CategoriaServicio_OID, string p_descripcion)
{
        CategoriaServicioEN categoriaServicioEN = null;

        //Initialized CategoriaServicioEN
        categoriaServicioEN = new CategoriaServicioEN ();
        categoriaServicioEN.Id = p_CategoriaServicio_OID;
        categoriaServicioEN.Descripcion = p_descripcion;
        //Call to CategoriaServicioCAD

        _ICategoriaServicioCAD.Modificar (categoriaServicioEN);
}

public void Eliminar (int id
                      )
{
        _ICategoriaServicioCAD.Eliminar (id);
}

public CategoriaServicioEN ReadOID (int id
                                    )
{
        CategoriaServicioEN categoriaServicioEN = null;

        categoriaServicioEN = _ICategoriaServicioCAD.ReadOID (id);
        return categoriaServicioEN;
}

public System.Collections.Generic.IList<CategoriaServicioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CategoriaServicioEN> list = null;

        list = _ICategoriaServicioCAD.ReadAll (first, size);
        return list;
}
}
}
