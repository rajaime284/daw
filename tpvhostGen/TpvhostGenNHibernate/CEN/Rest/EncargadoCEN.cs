

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
 *      Definition of the class EncargadoCEN
 *
 */
public partial class EncargadoCEN
{
private IEncargadoCAD _IEncargadoCAD;

public EncargadoCEN()
{
        this._IEncargadoCAD = new EncargadoCAD ();
}

public EncargadoCEN(IEncargadoCAD _IEncargadoCAD)
{
        this._IEncargadoCAD = _IEncargadoCAD;
}

public IEncargadoCAD get_IEncargadoCAD ()
{
        return this._IEncargadoCAD;
}

public int Nuevo ()
{
        EncargadoEN encargadoEN = null;
        int oid;

        //Initialized EncargadoEN
        encargadoEN = new EncargadoEN ();
        //Call to EncargadoCAD

        oid = _IEncargadoCAD.Nuevo (encargadoEN);
        return oid;
}

public void Modificar (int p_Encargado_OID)
{
        EncargadoEN encargadoEN = null;

        //Initialized EncargadoEN
        encargadoEN = new EncargadoEN ();
        encargadoEN.Id = p_Encargado_OID;
        //Call to EncargadoCAD

        _IEncargadoCAD.Modificar (encargadoEN);
}

public void Eliminar (int id
                      )
{
        _IEncargadoCAD.Eliminar (id);
}

public EncargadoEN ReadOID (int id
                            )
{
        EncargadoEN encargadoEN = null;

        encargadoEN = _IEncargadoCAD.ReadOID (id);
        return encargadoEN;
}

public System.Collections.Generic.IList<EncargadoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EncargadoEN> list = null;

        list = _IEncargadoCAD.ReadAll (first, size);
        return list;
}
}
}
