

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
 *      Definition of the class NegocioCEN
 *
 */
public partial class NegocioCEN
{
private INegocioCAD _INegocioCAD;

public NegocioCEN()
{
        this._INegocioCAD = new NegocioCAD ();
}

public NegocioCEN(INegocioCAD _INegocioCAD)
{
        this._INegocioCAD = _INegocioCAD;
}

public INegocioCAD get_INegocioCAD ()
{
        return this._INegocioCAD;
}

public int Nuevo (string p_nombre, string p_direccion, string p_ciudad, string p_cp, string p_provincia, string p_pais, int p_empresa)
{
        NegocioEN negocioEN = null;
        int oid;

        //Initialized NegocioEN
        negocioEN = new NegocioEN ();
        negocioEN.Nombre = p_nombre;

        negocioEN.Direccion = p_direccion;

        negocioEN.Ciudad = p_ciudad;

        negocioEN.Cp = p_cp;

        negocioEN.Provincia = p_provincia;

        negocioEN.Pais = p_pais;


        if (p_empresa != -1) {
                // El argumento p_empresa -> Property empresa es oid = false
                // Lista de oids id
                negocioEN.Empresa = new TpvhostGenNHibernate.EN.Rest.EmpresaEN ();
                negocioEN.Empresa.Id = p_empresa;
        }

        //Call to NegocioCAD

        oid = _INegocioCAD.Nuevo (negocioEN);
        return oid;
}

public void Modificar (int p_Negocio_OID, string p_nombre, string p_direccion, string p_ciudad, string p_cp, string p_provincia, string p_pais)
{
        NegocioEN negocioEN = null;

        //Initialized NegocioEN
        negocioEN = new NegocioEN ();
        negocioEN.Id = p_Negocio_OID;
        negocioEN.Nombre = p_nombre;
        negocioEN.Direccion = p_direccion;
        negocioEN.Ciudad = p_ciudad;
        negocioEN.Cp = p_cp;
        negocioEN.Provincia = p_provincia;
        negocioEN.Pais = p_pais;
        //Call to NegocioCAD

        _INegocioCAD.Modificar (negocioEN);
}

public void Eliminar (int id
                      )
{
        _INegocioCAD.Eliminar (id);
}

public NegocioEN ReadOID (int id
                          )
{
        NegocioEN negocioEN = null;

        negocioEN = _INegocioCAD.ReadOID (id);
        return negocioEN;
}

public System.Collections.Generic.IList<NegocioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NegocioEN> list = null;

        list = _INegocioCAD.ReadAll (first, size);
        return list;
}
}
}
