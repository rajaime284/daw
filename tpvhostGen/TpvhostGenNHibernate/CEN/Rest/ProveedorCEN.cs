

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
 *      Definition of the class ProveedorCEN
 *
 */
public partial class ProveedorCEN
{
private IProveedorCAD _IProveedorCAD;

public ProveedorCEN()
{
        this._IProveedorCAD = new ProveedorCAD ();
}

public ProveedorCEN(IProveedorCAD _IProveedorCAD)
{
        this._IProveedorCAD = _IProveedorCAD;
}

public IProveedorCAD get_IProveedorCAD ()
{
        return this._IProveedorCAD;
}

public int Nuevo (string p_nombre, string p_numeroTelefono, string p_email)
{
        ProveedorEN proveedorEN = null;
        int oid;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        proveedorEN.Nombre = p_nombre;

        proveedorEN.NumeroTelefono = p_numeroTelefono;

        proveedorEN.Email = p_email;

        //Call to ProveedorCAD

        oid = _IProveedorCAD.Nuevo (proveedorEN);
        return oid;
}

public void Modificar (int p_Proveedor_OID, string p_nombre, string p_numeroTelefono, string p_email)
{
        ProveedorEN proveedorEN = null;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        proveedorEN.Id = p_Proveedor_OID;
        proveedorEN.Nombre = p_nombre;
        proveedorEN.NumeroTelefono = p_numeroTelefono;
        proveedorEN.Email = p_email;
        //Call to ProveedorCAD

        _IProveedorCAD.Modificar (proveedorEN);
}

public void Eliminar (int id
                      )
{
        _IProveedorCAD.Eliminar (id);
}

public ProveedorEN ReadOID (int id
                            )
{
        ProveedorEN proveedorEN = null;

        proveedorEN = _IProveedorCAD.ReadOID (id);
        return proveedorEN;
}

public System.Collections.Generic.IList<ProveedorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProveedorEN> list = null;

        list = _IProveedorCAD.ReadAll (first, size);
        return list;
}
}
}
