

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
 *      Definition of the class ComandaCEN
 *
 */
public partial class ComandaCEN
{
private IComandaCAD _IComandaCAD;

public ComandaCEN()
{
        this._IComandaCAD = new ComandaCAD ();
}

public ComandaCEN(IComandaCAD _IComandaCAD)
{
        this._IComandaCAD = _IComandaCAD;
}

public IComandaCAD get_IComandaCAD ()
{
        return this._IComandaCAD;
}

public int Nuevo (TpvhostGenNHibernate.Enumerated.Rest.EstadoComandaEnum p_estadoPedido, int p_camarero, int p_mesa, Nullable<DateTime> p_fecha)
{
        ComandaEN comandaEN = null;
        int oid;

        //Initialized ComandaEN
        comandaEN = new ComandaEN ();
        comandaEN.EstadoPedido = p_estadoPedido;


        if (p_camarero != -1) {
                // El argumento p_camarero -> Property camarero es oid = false
                // Lista de oids id
                comandaEN.Camarero = new TpvhostGenNHibernate.EN.Rest.CamareroEN ();
                comandaEN.Camarero.Id = p_camarero;
        }


        if (p_mesa != -1) {
                // El argumento p_mesa -> Property mesa es oid = false
                // Lista de oids id
                comandaEN.Mesa = new TpvhostGenNHibernate.EN.Rest.MesaEN ();
                comandaEN.Mesa.Id = p_mesa;
        }

        comandaEN.Fecha = p_fecha;

        //Call to ComandaCAD

        oid = _IComandaCAD.Nuevo (comandaEN);
        return oid;
}

public void Modificar (int p_Comanda_OID, TpvhostGenNHibernate.Enumerated.Rest.EstadoComandaEnum p_estadoPedido, Nullable<DateTime> p_fecha)
{
        ComandaEN comandaEN = null;

        //Initialized ComandaEN
        comandaEN = new ComandaEN ();
        comandaEN.Id = p_Comanda_OID;
        comandaEN.EstadoPedido = p_estadoPedido;
        comandaEN.Fecha = p_fecha;
        //Call to ComandaCAD

        _IComandaCAD.Modificar (comandaEN);
}

public void Eliminar (int id
                      )
{
        _IComandaCAD.Eliminar (id);
}

public ComandaEN ReadOID (int id
                          )
{
        ComandaEN comandaEN = null;

        comandaEN = _IComandaCAD.ReadOID (id);
        return comandaEN;
}

public System.Collections.Generic.IList<ComandaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComandaEN> list = null;

        list = _IComandaCAD.ReadAll (first, size);
        return list;
}
}
}
