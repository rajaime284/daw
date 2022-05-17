
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
 * Clase Cajero:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class CajeroCAD : BasicCAD, ICajeroCAD
{
public CajeroCAD() : base ()
{
}

public CajeroCAD(ISession sessionAux) : base (sessionAux)
{
}



public CajeroEN ReadOIDDefault (int id
                                )
{
        CajeroEN cajeroEN = null;

        try
        {
                SessionInitializeTransaction ();
                cajeroEN = (CajeroEN)session.Get (typeof(CajeroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajeroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cajeroEN;
}

public System.Collections.Generic.IList<CajeroEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CajeroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CajeroEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CajeroEN>();
                        else
                                result = session.CreateCriteria (typeof(CajeroEN)).List<CajeroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajeroCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CajeroEN cajero)
{
        try
        {
                SessionInitializeTransaction ();
                CajeroEN cajeroEN = (CajeroEN)session.Load (typeof(CajeroEN), cajero.Id);


                session.Update (cajeroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajeroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (CajeroEN cajero)
{
        try
        {
                SessionInitializeTransaction ();
                if (cajero.Caja != null) {
                        for (int i = 0; i < cajero.Caja.Count; i++) {
                                cajero.Caja [i] = (TpvhostGenNHibernate.EN.Rest.CajaEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.CajaEN), cajero.Caja [i].Id);
                                cajero.Caja [i].Cajero.Add (cajero);
                        }
                }

                session.Save (cajero);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajeroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cajero.Id;
}

public void Modificar (CajeroEN cajero)
{
        try
        {
                SessionInitializeTransaction ();
                CajeroEN cajeroEN = (CajeroEN)session.Load (typeof(CajeroEN), cajero.Id);
                session.Update (cajeroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajeroCAD.", ex);
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
                CajeroEN cajeroEN = (CajeroEN)session.Load (typeof(CajeroEN), id);
                session.Delete (cajeroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajeroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CajeroEN
public CajeroEN ReadOID (int id
                         )
{
        CajeroEN cajeroEN = null;

        try
        {
                SessionInitializeTransaction ();
                cajeroEN = (CajeroEN)session.Get (typeof(CajeroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajeroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cajeroEN;
}

public System.Collections.Generic.IList<CajeroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CajeroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CajeroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CajeroEN>();
                else
                        result = session.CreateCriteria (typeof(CajeroEN)).List<CajeroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajeroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
