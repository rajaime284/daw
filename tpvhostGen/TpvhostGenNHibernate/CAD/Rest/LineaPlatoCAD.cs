
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
 * Clase LineaPlato:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class LineaPlatoCAD : BasicCAD, ILineaPlatoCAD
{
public LineaPlatoCAD() : base ()
{
}

public LineaPlatoCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaPlatoEN ReadOIDDefault (int id
                                    )
{
        LineaPlatoEN lineaPlatoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPlatoEN = (LineaPlatoEN)session.Get (typeof(LineaPlatoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaPlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPlatoEN;
}

public System.Collections.Generic.IList<LineaPlatoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaPlatoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaPlatoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaPlatoEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaPlatoEN)).List<LineaPlatoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaPlatoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaPlatoEN lineaPlato)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPlatoEN lineaPlatoEN = (LineaPlatoEN)session.Load (typeof(LineaPlatoEN), lineaPlato.Id);

                lineaPlatoEN.Cantidad = lineaPlato.Cantidad;



                session.Update (lineaPlatoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaPlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (LineaPlatoEN lineaPlato)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaPlato.Producto != null) {
                        // Argumento OID y no colección.
                        lineaPlato.Producto = (TpvhostGenNHibernate.EN.Rest.ProductoEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.ProductoEN), lineaPlato.Producto.Id);

                        lineaPlato.Producto.LineaPlato
                        .Add (lineaPlato);
                }
                if (lineaPlato.Plato != null) {
                        // Argumento OID y no colección.
                        lineaPlato.Plato = (TpvhostGenNHibernate.EN.Rest.PlatoEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.PlatoEN), lineaPlato.Plato.Id);

                        lineaPlato.Plato.LineaPlato
                        .Add (lineaPlato);
                }

                session.Save (lineaPlato);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaPlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPlato.Id;
}

public void Modificar (LineaPlatoEN lineaPlato)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPlatoEN lineaPlatoEN = (LineaPlatoEN)session.Load (typeof(LineaPlatoEN), lineaPlato.Id);

                lineaPlatoEN.Cantidad = lineaPlato.Cantidad;

                session.Update (lineaPlatoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaPlatoCAD.", ex);
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
                LineaPlatoEN lineaPlatoEN = (LineaPlatoEN)session.Load (typeof(LineaPlatoEN), id);
                session.Delete (lineaPlatoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaPlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: LineaPlatoEN
public LineaPlatoEN ReadOID (int id
                             )
{
        LineaPlatoEN lineaPlatoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPlatoEN = (LineaPlatoEN)session.Get (typeof(LineaPlatoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaPlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPlatoEN;
}

public System.Collections.Generic.IList<LineaPlatoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaPlatoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LineaPlatoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LineaPlatoEN>();
                else
                        result = session.CreateCriteria (typeof(LineaPlatoEN)).List<LineaPlatoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaPlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
