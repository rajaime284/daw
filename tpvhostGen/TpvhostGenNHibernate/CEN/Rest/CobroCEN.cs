

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
 *      Definition of the class CobroCEN
 *
 */
public partial class CobroCEN
{
private ICobroCAD _ICobroCAD;

public CobroCEN()
{
        this._ICobroCAD = new CobroCAD ();
}

public CobroCEN(ICobroCAD _ICobroCAD)
{
        this._ICobroCAD = _ICobroCAD;
}

public ICobroCAD get_ICobroCAD ()
{
        return this._ICobroCAD;
}

public int Nuevo (float p_monto, int p_comanda, int p_cliente, string p_tipoDeCobro, int p_tipoCobro, string p_numeroTransaccion)
{
        CobroEN cobroEN = null;
        int oid;

        //Initialized CobroEN
        cobroEN = new CobroEN ();
        cobroEN.Monto = p_monto;


        if (p_comanda != -1) {
                // El argumento p_comanda -> Property comanda es oid = false
                // Lista de oids id
                cobroEN.Comanda = new TpvhostGenNHibernate.EN.Rest.ComandaEN ();
                cobroEN.Comanda.Id = p_comanda;
        }


        if (p_cliente != -1) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids id
                cobroEN.Cliente = new TpvhostGenNHibernate.EN.Rest.ClienteEN ();
                cobroEN.Cliente.Id = p_cliente;
        }

        cobroEN.TipoDeCobro = p_tipoDeCobro;


        if (p_tipoCobro != -1) {
                // El argumento p_tipoCobro -> Property tipoCobro es oid = false
                // Lista de oids id
                cobroEN.TipoCobro = new TpvhostGenNHibernate.EN.Rest.TipoCobroEN ();
                cobroEN.TipoCobro.Id = p_tipoCobro;
        }

        cobroEN.NumeroTransaccion = p_numeroTransaccion;

        //Call to CobroCAD

        oid = _ICobroCAD.Nuevo (cobroEN);
        return oid;
}

public void Modificar (int p_Cobro_OID, float p_monto, string p_tipoDeCobro, string p_numeroTransaccion)
{
        CobroEN cobroEN = null;

        //Initialized CobroEN
        cobroEN = new CobroEN ();
        cobroEN.Id = p_Cobro_OID;
        cobroEN.Monto = p_monto;
        cobroEN.TipoDeCobro = p_tipoDeCobro;
        cobroEN.NumeroTransaccion = p_numeroTransaccion;
        //Call to CobroCAD

        _ICobroCAD.Modificar (cobroEN);
}

public void Eliminar (int id
                      )
{
        _ICobroCAD.Eliminar (id);
}

public CobroEN ReadOID (int id
                        )
{
        CobroEN cobroEN = null;

        cobroEN = _ICobroCAD.ReadOID (id);
        return cobroEN;
}

public System.Collections.Generic.IList<CobroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CobroEN> list = null;

        list = _ICobroCAD.ReadAll (first, size);
        return list;
}
}
}
