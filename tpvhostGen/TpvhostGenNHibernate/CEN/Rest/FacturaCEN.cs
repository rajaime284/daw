

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
 *      Definition of the class FacturaCEN
 *
 */
public partial class FacturaCEN
{
private IFacturaCAD _IFacturaCAD;

public FacturaCEN()
{
        this._IFacturaCAD = new FacturaCAD ();
}

public FacturaCEN(IFacturaCAD _IFacturaCAD)
{
        this._IFacturaCAD = _IFacturaCAD;
}

public IFacturaCAD get_IFacturaCAD ()
{
        return this._IFacturaCAD;
}

public int Nuevo (string p_numero, Nullable<DateTime> p_fecha, double p_precio, string p_descripcion, int p_comanda, int p_cliente)
{
        FacturaEN facturaEN = null;
        int oid;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Numero = p_numero;

        facturaEN.Fecha = p_fecha;

        facturaEN.Precio = p_precio;

        facturaEN.Descripcion = p_descripcion;


        if (p_comanda != -1) {
                // El argumento p_comanda -> Property comanda es oid = false
                // Lista de oids id
                facturaEN.Comanda = new TpvhostGenNHibernate.EN.Rest.ComandaEN ();
                facturaEN.Comanda.Id = p_comanda;
        }


        if (p_cliente != -1) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids id
                facturaEN.Cliente = new TpvhostGenNHibernate.EN.Rest.ClienteEN ();
                facturaEN.Cliente.Id = p_cliente;
        }

        //Call to FacturaCAD

        oid = _IFacturaCAD.Nuevo (facturaEN);
        return oid;
}

public void Modificar (int p_Factura_OID, string p_numero, Nullable<DateTime> p_fecha, double p_precio, string p_descripcion)
{
        FacturaEN facturaEN = null;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Id = p_Factura_OID;
        facturaEN.Numero = p_numero;
        facturaEN.Fecha = p_fecha;
        facturaEN.Precio = p_precio;
        facturaEN.Descripcion = p_descripcion;
        //Call to FacturaCAD

        _IFacturaCAD.Modificar (facturaEN);
}

public void Eliminar (int id
                      )
{
        _IFacturaCAD.Eliminar (id);
}

public FacturaEN ReadOID (int id
                          )
{
        FacturaEN facturaEN = null;

        facturaEN = _IFacturaCAD.ReadOID (id);
        return facturaEN;
}

public System.Collections.Generic.IList<FacturaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FacturaEN> list = null;

        list = _IFacturaCAD.ReadAll (first, size);
        return list;
}
}
}
