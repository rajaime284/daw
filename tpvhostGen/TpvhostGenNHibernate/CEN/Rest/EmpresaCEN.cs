

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
 *      Definition of the class EmpresaCEN
 *
 */
public partial class EmpresaCEN
{
private IEmpresaCAD _IEmpresaCAD;

public EmpresaCEN()
{
        this._IEmpresaCAD = new EmpresaCAD ();
}

public EmpresaCEN(IEmpresaCAD _IEmpresaCAD)
{
        this._IEmpresaCAD = _IEmpresaCAD;
}

public IEmpresaCAD get_IEmpresaCAD ()
{
        return this._IEmpresaCAD;
}

public int Nuevo (string p_nombre, string p_direccion, int p_dueño)
{
        EmpresaEN empresaEN = null;
        int oid;

        //Initialized EmpresaEN
        empresaEN = new EmpresaEN ();
        empresaEN.Nombre = p_nombre;

        empresaEN.Direccion = p_direccion;


        if (p_dueño != -1) {
                // El argumento p_dueño -> Property dueño es oid = false
                // Lista de oids id
                empresaEN.Dueño = new TpvhostGenNHibernate.EN.Rest.DuenyoEN ();
                empresaEN.Dueño.Id = p_dueño;
        }

        //Call to EmpresaCAD

        oid = _IEmpresaCAD.Nuevo (empresaEN);
        return oid;
}

public void Modificar (int p_Empresa_OID, string p_nombre, string p_direccion)
{
        EmpresaEN empresaEN = null;

        //Initialized EmpresaEN
        empresaEN = new EmpresaEN ();
        empresaEN.Id = p_Empresa_OID;
        empresaEN.Nombre = p_nombre;
        empresaEN.Direccion = p_direccion;
        //Call to EmpresaCAD

        _IEmpresaCAD.Modificar (empresaEN);
}

public void Eliminar (int id
                      )
{
        _IEmpresaCAD.Eliminar (id);
}

public EmpresaEN ReadOID (int id
                          )
{
        EmpresaEN empresaEN = null;

        empresaEN = _IEmpresaCAD.ReadOID (id);
        return empresaEN;
}

public System.Collections.Generic.IList<EmpresaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EmpresaEN> list = null;

        list = _IEmpresaCAD.ReadAll (first, size);
        return list;
}
}
}
