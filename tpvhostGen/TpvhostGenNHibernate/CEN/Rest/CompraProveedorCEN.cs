

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
 *      Definition of the class CompraProveedorCEN
 *
 */
public partial class CompraProveedorCEN
{
private ICompraProveedorCAD _ICompraProveedorCAD;

public CompraProveedorCEN()
{
        this._ICompraProveedorCAD = new CompraProveedorCAD ();
}

public CompraProveedorCEN(ICompraProveedorCAD _ICompraProveedorCAD)
{
        this._ICompraProveedorCAD = _ICompraProveedorCAD;
}

public ICompraProveedorCAD get_ICompraProveedorCAD ()
{
        return this._ICompraProveedorCAD;
}

public int Nuevo (System.Collections.Generic.IList<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN> p_lineaCompraProveedor, int p_proveedor, int p_negocio, TpvhostGenNHibernate.Enumerated.Rest.EstadoCompraProveedorEnum p_estadoCompra, Nullable<DateTime> p_fecha)
{
        CompraProveedorEN compraProveedorEN = null;
        int oid;

        //Initialized CompraProveedorEN
        compraProveedorEN = new CompraProveedorEN ();
        compraProveedorEN.LineaCompraProveedor = p_lineaCompraProveedor;


        if (p_proveedor != -1) {
                // El argumento p_proveedor -> Property proveedor es oid = false
                // Lista de oids id
                compraProveedorEN.Proveedor = new TpvhostGenNHibernate.EN.Rest.ProveedorEN ();
                compraProveedorEN.Proveedor.Id = p_proveedor;
        }


        if (p_negocio != -1) {
                // El argumento p_negocio -> Property negocio es oid = false
                // Lista de oids id
                compraProveedorEN.Negocio = new TpvhostGenNHibernate.EN.Rest.NegocioEN ();
                compraProveedorEN.Negocio.Id = p_negocio;
        }

        compraProveedorEN.EstadoCompra = p_estadoCompra;

        compraProveedorEN.Fecha = p_fecha;

        //Call to CompraProveedorCAD

        oid = _ICompraProveedorCAD.Nuevo (compraProveedorEN);
        return oid;
}

public void Modificar (int p_CompraProveedor_OID, TpvhostGenNHibernate.Enumerated.Rest.EstadoCompraProveedorEnum p_estadoCompra, Nullable<DateTime> p_fecha)
{
        CompraProveedorEN compraProveedorEN = null;

        //Initialized CompraProveedorEN
        compraProveedorEN = new CompraProveedorEN ();
        compraProveedorEN.Id = p_CompraProveedor_OID;
        compraProveedorEN.EstadoCompra = p_estadoCompra;
        compraProveedorEN.Fecha = p_fecha;
        //Call to CompraProveedorCAD

        _ICompraProveedorCAD.Modificar (compraProveedorEN);
}

public void Eliminar (int id
                      )
{
        _ICompraProveedorCAD.Eliminar (id);
}

public CompraProveedorEN ReadOID (int id
                                  )
{
        CompraProveedorEN compraProveedorEN = null;

        compraProveedorEN = _ICompraProveedorCAD.ReadOID (id);
        return compraProveedorEN;
}

public System.Collections.Generic.IList<CompraProveedorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CompraProveedorEN> list = null;

        list = _ICompraProveedorCAD.ReadAll (first, size);
        return list;
}
}
}
