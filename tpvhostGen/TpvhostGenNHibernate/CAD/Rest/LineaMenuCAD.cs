
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
 * Clase LineaMenu:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class LineaMenuCAD : BasicCAD, ILineaMenuCAD
{
public LineaMenuCAD() : base ()
{
}

public LineaMenuCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaMenuEN ReadOIDDefault (int id
                                   )
{
        LineaMenuEN lineaMenuEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaMenuEN = (LineaMenuEN)session.Get (typeof(LineaMenuEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaMenuCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaMenuEN;
}

public System.Collections.Generic.IList<LineaMenuEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaMenuEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaMenuEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaMenuEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaMenuEN)).List<LineaMenuEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaMenuCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaMenuEN lineaMenu)
{
        try
        {
                SessionInitializeTransaction ();
                LineaMenuEN lineaMenuEN = (LineaMenuEN)session.Load (typeof(LineaMenuEN), lineaMenu.Id);

                lineaMenuEN.Cantidad = lineaMenu.Cantidad;



                session.Update (lineaMenuEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaMenuCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (LineaMenuEN lineaMenu)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaMenu.Plato != null) {
                        // Argumento OID y no colección.
                        lineaMenu.Plato = (TpvhostGenNHibernate.EN.Rest.PlatoEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.PlatoEN), lineaMenu.Plato.Id);

                        lineaMenu.Plato.LineaMenu
                        .Add (lineaMenu);
                }
                if (lineaMenu.Menu != null) {
                        // Argumento OID y no colección.
                        lineaMenu.Menu = (TpvhostGenNHibernate.EN.Rest.MenuEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.MenuEN), lineaMenu.Menu.Id);

                        lineaMenu.Menu.LineaMenu
                        .Add (lineaMenu);
                }

                session.Save (lineaMenu);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaMenuCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaMenu.Id;
}

public void Modificar (LineaMenuEN lineaMenu)
{
        try
        {
                SessionInitializeTransaction ();
                LineaMenuEN lineaMenuEN = (LineaMenuEN)session.Load (typeof(LineaMenuEN), lineaMenu.Id);

                lineaMenuEN.Cantidad = lineaMenu.Cantidad;

                session.Update (lineaMenuEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaMenuCAD.", ex);
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
                LineaMenuEN lineaMenuEN = (LineaMenuEN)session.Load (typeof(LineaMenuEN), id);
                session.Delete (lineaMenuEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaMenuCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: LineaMenuEN
public LineaMenuEN ReadOID (int id
                            )
{
        LineaMenuEN lineaMenuEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaMenuEN = (LineaMenuEN)session.Get (typeof(LineaMenuEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaMenuCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaMenuEN;
}

public System.Collections.Generic.IList<LineaMenuEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaMenuEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LineaMenuEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LineaMenuEN>();
                else
                        result = session.CreateCriteria (typeof(LineaMenuEN)).List<LineaMenuEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaMenuCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
