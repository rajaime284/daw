
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
 * Clase LineaComanda:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class LineaComandaCAD : BasicCAD, ILineaComandaCAD
{
public LineaComandaCAD() : base ()
{
}

public LineaComandaCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaComandaEN ReadOIDDefault (int id
                                      )
{
        LineaComandaEN lineaComandaEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaComandaEN = (LineaComandaEN)session.Get (typeof(LineaComandaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaComandaEN;
}

public System.Collections.Generic.IList<LineaComandaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaComandaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaComandaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaComandaEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaComandaEN)).List<LineaComandaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaComandaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaComandaEN lineaComanda)
{
        try
        {
                SessionInitializeTransaction ();
                LineaComandaEN lineaComandaEN = (LineaComandaEN)session.Load (typeof(LineaComandaEN), lineaComanda.Id);



                lineaComandaEN.Cantidad = lineaComanda.Cantidad;


                session.Update (lineaComandaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modificar (LineaComandaEN lineaComanda)
{
        try
        {
                SessionInitializeTransaction ();
                LineaComandaEN lineaComandaEN = (LineaComandaEN)session.Load (typeof(LineaComandaEN), lineaComanda.Id);

                lineaComandaEN.Cantidad = lineaComanda.Cantidad;

                session.Update (lineaComandaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaComandaCAD.", ex);
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
                LineaComandaEN lineaComandaEN = (LineaComandaEN)session.Load (typeof(LineaComandaEN), id);
                session.Delete (lineaComandaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int NuevaLineaPlato (LineaComandaEN lineaComanda)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaComanda.Comanda != null) {
                        // Argumento OID y no colección.
                        lineaComanda.Comanda = (TpvhostGenNHibernate.EN.Rest.ComandaEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.ComandaEN), lineaComanda.Comanda.Id);

                        lineaComanda.Comanda.LineaComanda
                        .Add (lineaComanda);
                }

                session.Save (lineaComanda);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaComanda.Id;
}

//Sin e: ReadOID
//Con e: LineaComandaEN
public LineaComandaEN ReadOID (int id
                               )
{
        LineaComandaEN lineaComandaEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaComandaEN = (LineaComandaEN)session.Get (typeof(LineaComandaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaComandaEN;
}

public System.Collections.Generic.IList<LineaComandaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaComandaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LineaComandaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LineaComandaEN>();
                else
                        result = session.CreateCriteria (typeof(LineaComandaEN)).List<LineaComandaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int NuevaLineaMenu (LineaComandaEN lineaComanda)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaComanda.Comanda != null) {
                        // Argumento OID y no colección.
                        lineaComanda.Comanda = (TpvhostGenNHibernate.EN.Rest.ComandaEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.ComandaEN), lineaComanda.Comanda.Id);

                        lineaComanda.Comanda.LineaComanda
                        .Add (lineaComanda);
                }

                session.Save (lineaComanda);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in LineaComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaComanda.Id;
}
}
}
