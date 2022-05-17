
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
 * Clase tipoPago:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class TipoPagoCAD : BasicCAD, ITipoPagoCAD
{
public TipoPagoCAD() : base ()
{
}

public TipoPagoCAD(ISession sessionAux) : base (sessionAux)
{
}



public TipoPagoEN ReadOIDDefault (int id
                                  )
{
        TipoPagoEN tipoPagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipoPagoEN = (TipoPagoEN)session.Get (typeof(TipoPagoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoPagoEN;
}

public System.Collections.Generic.IList<TipoPagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TipoPagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TipoPagoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TipoPagoEN>();
                        else
                                result = session.CreateCriteria (typeof(TipoPagoEN)).List<TipoPagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoPagoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TipoPagoEN tipoPago)
{
        try
        {
                SessionInitializeTransaction ();
                TipoPagoEN tipoPagoEN = (TipoPagoEN)session.Load (typeof(TipoPagoEN), tipoPago.Id);

                tipoPagoEN.Descripcion = tipoPago.Descripcion;


                session.Update (tipoPagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (TipoPagoEN tipoPago)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tipoPago);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoPago.Id;
}

public void Modificar (TipoPagoEN tipoPago)
{
        try
        {
                SessionInitializeTransaction ();
                TipoPagoEN tipoPagoEN = (TipoPagoEN)session.Load (typeof(TipoPagoEN), tipoPago.Id);

                tipoPagoEN.Descripcion = tipoPago.Descripcion;

                session.Update (tipoPagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoPagoCAD.", ex);
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
                TipoPagoEN tipoPagoEN = (TipoPagoEN)session.Load (typeof(TipoPagoEN), id);
                session.Delete (tipoPagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: TipoPagoEN
public TipoPagoEN ReadOID (int id
                           )
{
        TipoPagoEN tipoPagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipoPagoEN = (TipoPagoEN)session.Get (typeof(TipoPagoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoPagoEN;
}

public System.Collections.Generic.IList<TipoPagoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TipoPagoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TipoPagoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TipoPagoEN>();
                else
                        result = session.CreateCriteria (typeof(TipoPagoEN)).List<TipoPagoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
