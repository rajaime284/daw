

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
 *      Definition of the class MetodoPagoCEN
 *
 */
public partial class MetodoPagoCEN
{
private IMetodoPagoCAD _IMetodoPagoCAD;

public MetodoPagoCEN()
{
        this._IMetodoPagoCAD = new MetodoPagoCAD ();
}

public MetodoPagoCEN(IMetodoPagoCAD _IMetodoPagoCAD)
{
        this._IMetodoPagoCAD = _IMetodoPagoCAD;
}

public IMetodoPagoCAD get_IMetodoPagoCAD ()
{
        return this._IMetodoPagoCAD;
}

public int Nuevo (string p_descripcion)
{
        MetodoPagoEN metodoPagoEN = null;
        int oid;

        //Initialized MetodoPagoEN
        metodoPagoEN = new MetodoPagoEN ();
        metodoPagoEN.Descripcion = p_descripcion;

        //Call to MetodoPagoCAD

        oid = _IMetodoPagoCAD.Nuevo (metodoPagoEN);
        return oid;
}

public void Modificar (int p_metodoPago_OID, string p_descripcion)
{
        MetodoPagoEN metodoPagoEN = null;

        //Initialized MetodoPagoEN
        metodoPagoEN = new MetodoPagoEN ();
        metodoPagoEN.Id = p_metodoPago_OID;
        metodoPagoEN.Descripcion = p_descripcion;
        //Call to MetodoPagoCAD

        _IMetodoPagoCAD.Modificar (metodoPagoEN);
}

public void Eliminar (int id
                      )
{
        _IMetodoPagoCAD.Eliminar (id);
}
}
}
