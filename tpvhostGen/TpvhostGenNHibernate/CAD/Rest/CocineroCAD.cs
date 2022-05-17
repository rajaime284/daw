
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
 * Clase Cocinero:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class CocineroCAD : BasicCAD, ICocineroCAD
{
public CocineroCAD() : base ()
{
}

public CocineroCAD(ISession sessionAux) : base (sessionAux)
{
}



public CocineroEN ReadOIDDefault (int id
                                  )
{
        CocineroEN cocineroEN = null;

        try
        {
                SessionInitializeTransaction ();
                cocineroEN = (CocineroEN)session.Get (typeof(CocineroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CocineroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cocineroEN;
}

public System.Collections.Generic.IList<CocineroEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CocineroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CocineroEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CocineroEN>();
                        else
                                result = session.CreateCriteria (typeof(CocineroEN)).List<CocineroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CocineroCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CocineroEN cocinero)
{
        try
        {
                SessionInitializeTransaction ();
                CocineroEN cocineroEN = (CocineroEN)session.Load (typeof(CocineroEN), cocinero.Id);

                session.Update (cocineroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CocineroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (CocineroEN cocinero)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (cocinero);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CocineroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cocinero.Id;
}

public void Modificar (CocineroEN cocinero)
{
        try
        {
                SessionInitializeTransaction ();
                CocineroEN cocineroEN = (CocineroEN)session.Load (typeof(CocineroEN), cocinero.Id);
                session.Update (cocineroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CocineroCAD.", ex);
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
                CocineroEN cocineroEN = (CocineroEN)session.Load (typeof(CocineroEN), id);
                session.Delete (cocineroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CocineroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CocineroEN
public CocineroEN ReadOID (int id
                           )
{
        CocineroEN cocineroEN = null;

        try
        {
                SessionInitializeTransaction ();
                cocineroEN = (CocineroEN)session.Get (typeof(CocineroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CocineroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cocineroEN;
}

public System.Collections.Generic.IList<CocineroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CocineroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CocineroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CocineroEN>();
                else
                        result = session.CreateCriteria (typeof(CocineroEN)).List<CocineroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CocineroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
