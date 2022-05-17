

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
 *      Definition of the class PlatoCEN
 *
 */
public partial class PlatoCEN
{
private IPlatoCAD _IPlatoCAD;

public PlatoCEN()
{
        this._IPlatoCAD = new PlatoCAD ();
}

public PlatoCEN(IPlatoCAD _IPlatoCAD)
{
        this._IPlatoCAD = _IPlatoCAD;
}

public IPlatoCAD get_IPlatoCAD ()
{
        return this._IPlatoCAD;
}

public int Nuevo (string p_nombre, double p_precio, System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaPlatoEN> p_lineaPlato)
{
        PlatoEN platoEN = null;
        int oid;

        //Initialized PlatoEN
        platoEN = new PlatoEN ();
        platoEN.Nombre = p_nombre;

        platoEN.Precio = p_precio;

        platoEN.LineaPlato = p_lineaPlato;

        //Call to PlatoCAD

        oid = _IPlatoCAD.Nuevo (platoEN);
        return oid;
}

public void Modificar (int p_Plato_OID, string p_nombre, double p_precio)
{
        PlatoEN platoEN = null;

        //Initialized PlatoEN
        platoEN = new PlatoEN ();
        platoEN.Id = p_Plato_OID;
        platoEN.Nombre = p_nombre;
        platoEN.Precio = p_precio;
        //Call to PlatoCAD

        _IPlatoCAD.Modificar (platoEN);
}

public void Eliminar (int id
                      )
{
        _IPlatoCAD.Eliminar (id);
}

public PlatoEN ReadOID (int id
                        )
{
        PlatoEN platoEN = null;

        platoEN = _IPlatoCAD.ReadOID (id);
        return platoEN;
}

public System.Collections.Generic.IList<PlatoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PlatoEN> list = null;

        list = _IPlatoCAD.ReadAll (first, size);
        return list;
}
}
}
