

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
 *      Definition of the class LineaCompraProveedorCEN
 *
 */
public partial class LineaCompraProveedorCEN
{
private ILineaCompraProveedorCAD _ILineaCompraProveedorCAD;

public LineaCompraProveedorCEN()
{
        this._ILineaCompraProveedorCAD = new LineaCompraProveedorCAD ();
}

public LineaCompraProveedorCEN(ILineaCompraProveedorCAD _ILineaCompraProveedorCAD)
{
        this._ILineaCompraProveedorCAD = _ILineaCompraProveedorCAD;
}

public ILineaCompraProveedorCAD get_ILineaCompraProveedorCAD ()
{
        return this._ILineaCompraProveedorCAD;
}

public int NuevaLineaServicio (int p_cantidad, int p_servicio, int p_compraProveedor, int p_producto, double p_Costo)
{
        LineaCompraProveedorEN lineaCompraProveedorEN = null;
        int oid;

        //Initialized LineaCompraProveedorEN
        lineaCompraProveedorEN = new LineaCompraProveedorEN ();
        lineaCompraProveedorEN.Cantidad = p_cantidad;


        if (p_servicio != -1) {
                // El argumento p_servicio -> Property servicio es oid = false
                // Lista de oids id
                lineaCompraProveedorEN.Servicio = new TpvhostGenNHibernate.EN.Rest.ServicioEN ();
                lineaCompraProveedorEN.Servicio.Id = p_servicio;
        }


        if (p_compraProveedor != -1) {
                // El argumento p_compraProveedor -> Property compraProveedor es oid = false
                // Lista de oids id
                lineaCompraProveedorEN.CompraProveedor = new TpvhostGenNHibernate.EN.Rest.CompraProveedorEN ();
                lineaCompraProveedorEN.CompraProveedor.Id = p_compraProveedor;
        }


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id
                lineaCompraProveedorEN.Producto = new TpvhostGenNHibernate.EN.Rest.ProductoEN ();
                lineaCompraProveedorEN.Producto.Id = p_producto;
        }

        lineaCompraProveedorEN.Costo = p_Costo;

        //Call to LineaCompraProveedorCAD

        oid = _ILineaCompraProveedorCAD.NuevaLineaServicio (lineaCompraProveedorEN);
        return oid;
}

public void Modificar (int p_LineaCompraProveedor_OID, int p_cantidad, double p_Costo)
{
        LineaCompraProveedorEN lineaCompraProveedorEN = null;

        //Initialized LineaCompraProveedorEN
        lineaCompraProveedorEN = new LineaCompraProveedorEN ();
        lineaCompraProveedorEN.Id = p_LineaCompraProveedor_OID;
        lineaCompraProveedorEN.Cantidad = p_cantidad;
        lineaCompraProveedorEN.Costo = p_Costo;
        //Call to LineaCompraProveedorCAD

        _ILineaCompraProveedorCAD.Modificar (lineaCompraProveedorEN);
}

public void Eliminar (int id
                      )
{
        _ILineaCompraProveedorCAD.Eliminar (id);
}

public int NuevaLineaProducto (int p_cantidad, int p_servicio, int p_compraProveedor, int p_producto, double p_Costo)
{
        LineaCompraProveedorEN lineaCompraProveedorEN = null;
        int oid;

        //Initialized LineaCompraProveedorEN
        lineaCompraProveedorEN = new LineaCompraProveedorEN ();
        lineaCompraProveedorEN.Cantidad = p_cantidad;


        if (p_servicio != -1) {
                // El argumento p_servicio -> Property servicio es oid = false
                // Lista de oids id
                lineaCompraProveedorEN.Servicio = new TpvhostGenNHibernate.EN.Rest.ServicioEN ();
                lineaCompraProveedorEN.Servicio.Id = p_servicio;
        }


        if (p_compraProveedor != -1) {
                // El argumento p_compraProveedor -> Property compraProveedor es oid = false
                // Lista de oids id
                lineaCompraProveedorEN.CompraProveedor = new TpvhostGenNHibernate.EN.Rest.CompraProveedorEN ();
                lineaCompraProveedorEN.CompraProveedor.Id = p_compraProveedor;
        }


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id
                lineaCompraProveedorEN.Producto = new TpvhostGenNHibernate.EN.Rest.ProductoEN ();
                lineaCompraProveedorEN.Producto.Id = p_producto;
        }

        lineaCompraProveedorEN.Costo = p_Costo;

        //Call to LineaCompraProveedorCAD

        oid = _ILineaCompraProveedorCAD.NuevaLineaProducto (lineaCompraProveedorEN);
        return oid;
}

public LineaCompraProveedorEN ReadOID (int id
                                       )
{
        LineaCompraProveedorEN lineaCompraProveedorEN = null;

        lineaCompraProveedorEN = _ILineaCompraProveedorCAD.ReadOID (id);
        return lineaCompraProveedorEN;
}

public System.Collections.Generic.IList<LineaCompraProveedorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaCompraProveedorEN> list = null;

        list = _ILineaCompraProveedorCAD.ReadAll (first, size);
        return list;
}
}
}
