

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
 *      Definition of the class ClienteCEN
 *
 */
public partial class ClienteCEN
{
private IClienteCAD _IClienteCAD;

public ClienteCEN()
{
        this._IClienteCAD = new ClienteCAD ();
}

public ClienteCEN(IClienteCAD _IClienteCAD)
{
        this._IClienteCAD = _IClienteCAD;
}

public IClienteCAD get_IClienteCAD ()
{
        return this._IClienteCAD;
}

public int Nuevo (string p_dni, string p_nombre, string p_apellidos, int p_negocio)
{
        ClienteEN clienteEN = null;
        int oid;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.Dni = p_dni;

        clienteEN.Nombre = p_nombre;

        clienteEN.Apellidos = p_apellidos;


        if (p_negocio != -1) {
                // El argumento p_negocio -> Property negocio es oid = false
                // Lista de oids id
                clienteEN.Negocio = new TpvhostGenNHibernate.EN.Rest.NegocioEN ();
                clienteEN.Negocio.Id = p_negocio;
        }

        //Call to ClienteCAD

        oid = _IClienteCAD.Nuevo (clienteEN);
        return oid;
}

public void Modificar (int p_Cliente_OID, string p_dni, string p_nombre, string p_apellidos)
{
        ClienteEN clienteEN = null;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.Id = p_Cliente_OID;
        clienteEN.Dni = p_dni;
        clienteEN.Nombre = p_nombre;
        clienteEN.Apellidos = p_apellidos;
        //Call to ClienteCAD

        _IClienteCAD.Modificar (clienteEN);
}

public void Eliminar (int id
                      )
{
        _IClienteCAD.Eliminar (id);
}

public ClienteEN ReadOID (int id
                          )
{
        ClienteEN clienteEN = null;

        clienteEN = _IClienteCAD.ReadOID (id);
        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> list = null;

        list = _IClienteCAD.ReadAll (first, size);
        return list;
}
}
}
