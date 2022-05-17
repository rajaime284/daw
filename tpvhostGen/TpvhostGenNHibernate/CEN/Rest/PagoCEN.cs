

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
 *      Definition of the class PagoCEN
 *
 */
public partial class PagoCEN
{
private IPagoCAD _IPagoCAD;

public PagoCEN()
{
        this._IPagoCAD = new PagoCAD ();
}

public PagoCEN(IPagoCAD _IPagoCAD)
{
        this._IPagoCAD = _IPagoCAD;
}

public IPagoCAD get_IPagoCAD ()
{
        return this._IPagoCAD;
}

public int Nuevo (double p_monto, Nullable<DateTime> p_fechaPago, int p_tipoPago, int p_numeroDocumento)
{
        PagoEN pagoEN = null;
        int oid;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.Monto = p_monto;

        pagoEN.FechaPago = p_fechaPago;


        if (p_tipoPago != -1) {
                // El argumento p_tipoPago -> Property tipoPago es oid = false
                // Lista de oids id
                pagoEN.TipoPago = new TpvhostGenNHibernate.EN.Rest.TipoPagoEN ();
                pagoEN.TipoPago.Id = p_tipoPago;
        }

        pagoEN.NumeroDocumento = p_numeroDocumento;

        //Call to PagoCAD

        oid = _IPagoCAD.Nuevo (pagoEN);
        return oid;
}

public void Modificar (int p_Pago_OID, double p_monto, Nullable<DateTime> p_fechaPago, int p_numeroDocumento)
{
        PagoEN pagoEN = null;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.Id = p_Pago_OID;
        pagoEN.Monto = p_monto;
        pagoEN.FechaPago = p_fechaPago;
        pagoEN.NumeroDocumento = p_numeroDocumento;
        //Call to PagoCAD

        _IPagoCAD.Modificar (pagoEN);
}

public void Eliminar (int id
                      )
{
        _IPagoCAD.Eliminar (id);
}
}
}
