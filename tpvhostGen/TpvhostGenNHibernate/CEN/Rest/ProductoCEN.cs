

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
 *      Definition of the class ProductoCEN
 *
 */
public partial class ProductoCEN
{
private IProductoCAD _IProductoCAD;

public ProductoCEN()
{
        this._IProductoCAD = new ProductoCAD ();
}

public ProductoCEN(IProductoCAD _IProductoCAD)
{
        this._IProductoCAD = _IProductoCAD;
}

public IProductoCAD get_IProductoCAD ()
{
        return this._IProductoCAD;
}

public int Nuevo (int p_unidadMedida, int p_negocio, string p_descripcion)
{
        ProductoEN productoEN = null;
        int oid;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();

        if (p_unidadMedida != -1) {
                // El argumento p_unidadMedida -> Property unidadMedida es oid = false
                // Lista de oids id
                productoEN.UnidadMedida = new TpvhostGenNHibernate.EN.Rest.UnidadMedidaEN ();
                productoEN.UnidadMedida.Id = p_unidadMedida;
        }


        if (p_negocio != -1) {
                // El argumento p_negocio -> Property negocio es oid = false
                // Lista de oids id
                productoEN.Negocio = new TpvhostGenNHibernate.EN.Rest.NegocioEN ();
                productoEN.Negocio.Id = p_negocio;
        }

        productoEN.Descripcion = p_descripcion;

        //Call to ProductoCAD

        oid = _IProductoCAD.Nuevo (productoEN);
        return oid;
}

public void Modificar (int p_Producto_OID, string p_descripcion)
{
        ProductoEN productoEN = null;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Id = p_Producto_OID;
        productoEN.Descripcion = p_descripcion;
        //Call to ProductoCAD

        _IProductoCAD.Modificar (productoEN);
}

public void Eliminar (int id
                      )
{
        _IProductoCAD.Eliminar (id);
}

public ProductoEN ReadOID (int id
                           )
{
        ProductoEN productoEN = null;

        productoEN = _IProductoCAD.ReadOID (id);
        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> list = null;

        list = _IProductoCAD.ReadAll (first, size);
        return list;
}
}
}
