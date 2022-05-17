
using System;
using System.Text;
using TpvhostGenNHibernate.CEN.Rest;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.Exceptions;


/*
 * Clase LineaCompraProveedor:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class LineaCompraProveedorCAD : BasicCAD, ILineaCompraProveedorCAD
{
public LineaCompraProveedorCAD() : base ()
{
}

public LineaCompraProveedorCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaCompraProveedorEN ReadOIDDefault (int id
                                              )
{
        LineaCompraProveedorEN lineaCompraProveedorEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaCompraProveedorEN = (LineaCompraProveedorEN)session.Get (typeof(LineaCompraProveedorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaCompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaCompraProveedorEN;
}

public System.Collections.Generic.IList<LineaCompraProveedorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaCompraProveedorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaCompraProveedorEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaCompraProveedorEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaCompraProveedorEN)).List<LineaCompraProveedorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaCompraProveedorCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaCompraProveedorEN lineaCompraProveedor)
{
        try
        {
                SessionInitializeTransaction ();
                LineaCompraProveedorEN lineaCompraProveedorEN = (LineaCompraProveedorEN)session.Load (typeof(LineaCompraProveedorEN), lineaCompraProveedor.Id);

                lineaCompraProveedorEN.Cantidad = lineaCompraProveedor.Cantidad;





                lineaCompraProveedorEN.Costo = lineaCompraProveedor.Costo;

                session.Update (lineaCompraProveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaCompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NuevaLineaServicio (LineaCompraProveedorEN lineaCompraProveedor)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaCompraProveedor.Servicio != null) {
                        // Argumento OID y no colección.
                        lineaCompraProveedor.Servicio = (TpvhostGenNHibernate.EN.Rest.ServicioEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.ServicioEN), lineaCompraProveedor.Servicio.Id);

                        lineaCompraProveedor.Servicio.LineaProveedor
                        .Add (lineaCompraProveedor);
                }
                if (lineaCompraProveedor.CompraProveedor != null) {
                        // Argumento OID y no colección.
                        lineaCompraProveedor.CompraProveedor = (TpvhostGenNHibernate.EN.Rest.CompraProveedorEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.CompraProveedorEN), lineaCompraProveedor.CompraProveedor.Id);

                        lineaCompraProveedor.CompraProveedor.LineaCompraProveedor
                        .Add (lineaCompraProveedor);
                }
                if (lineaCompraProveedor.Producto != null) {
                        // Argumento OID y no colección.
                        lineaCompraProveedor.Producto = (TpvhostGenNHibernate.EN.Rest.ProductoEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.ProductoEN), lineaCompraProveedor.Producto.Id);

                        lineaCompraProveedor.Producto.LineaCompraProveedor
                        .Add (lineaCompraProveedor);
                }

                session.Save (lineaCompraProveedor);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaCompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaCompraProveedor.Id;
}

public void Modificar (LineaCompraProveedorEN lineaCompraProveedor)
{
        try
        {
                SessionInitializeTransaction ();
                LineaCompraProveedorEN lineaCompraProveedorEN = (LineaCompraProveedorEN)session.Load (typeof(LineaCompraProveedorEN), lineaCompraProveedor.Id);

                lineaCompraProveedorEN.Cantidad = lineaCompraProveedor.Cantidad;


                lineaCompraProveedorEN.Costo = lineaCompraProveedor.Costo;

                session.Update (lineaCompraProveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaCompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (int id
                      )
{
        try
        {
                SessionInitializeTransaction ();
                LineaCompraProveedorEN lineaCompraProveedorEN = (LineaCompraProveedorEN)session.Load (typeof(LineaCompraProveedorEN), id);
                session.Delete (lineaCompraProveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaCompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int NuevaLineaProducto (LineaCompraProveedorEN lineaCompraProveedor)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaCompraProveedor.Servicio != null) {
                        // Argumento OID y no colección.
                        lineaCompraProveedor.Servicio = (TpvhostGenNHibernate.EN.Rest.ServicioEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.ServicioEN), lineaCompraProveedor.Servicio.Id);

                        lineaCompraProveedor.Servicio.LineaProveedor
                        .Add (lineaCompraProveedor);
                }
                if (lineaCompraProveedor.CompraProveedor != null) {
                        // Argumento OID y no colección.
                        lineaCompraProveedor.CompraProveedor = (TpvhostGenNHibernate.EN.Rest.CompraProveedorEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.CompraProveedorEN), lineaCompraProveedor.CompraProveedor.Id);

                        lineaCompraProveedor.CompraProveedor.LineaCompraProveedor
                        .Add (lineaCompraProveedor);
                }
                if (lineaCompraProveedor.Producto != null) {
                        // Argumento OID y no colección.
                        lineaCompraProveedor.Producto = (TpvhostGenNHibernate.EN.Rest.ProductoEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.ProductoEN), lineaCompraProveedor.Producto.Id);

                        lineaCompraProveedor.Producto.LineaCompraProveedor
                        .Add (lineaCompraProveedor);
                }

                session.Save (lineaCompraProveedor);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaCompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaCompraProveedor.Id;
}

//Sin e: ReadOID
//Con e: LineaCompraProveedorEN
public LineaCompraProveedorEN ReadOID (int id
                                       )
{
        LineaCompraProveedorEN lineaCompraProveedorEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaCompraProveedorEN = (LineaCompraProveedorEN)session.Get (typeof(LineaCompraProveedorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaCompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaCompraProveedorEN;
}

public System.Collections.Generic.IList<LineaCompraProveedorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaCompraProveedorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LineaCompraProveedorEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LineaCompraProveedorEN>();
                else
                        result = session.CreateCriteria (typeof(LineaCompraProveedorEN)).List<LineaCompraProveedorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaCompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
