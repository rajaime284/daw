
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
 * Clase Camarero:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class CamareroCAD : BasicCAD, ICamareroCAD
{
public CamareroCAD() : base ()
{
}

public CamareroCAD(ISession sessionAux) : base (sessionAux)
{
}



public CamareroEN ReadOIDDefault (int id
                                  )
{
        CamareroEN camareroEN = null;

        try
        {
                SessionInitializeTransaction ();
                camareroEN = (CamareroEN)session.Get (typeof(CamareroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CamareroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return camareroEN;
}

public System.Collections.Generic.IList<CamareroEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CamareroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CamareroEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CamareroEN>();
                        else
                                result = session.CreateCriteria (typeof(CamareroEN)).List<CamareroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CamareroCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CamareroEN camarero)
{
        try
        {
                SessionInitializeTransaction ();
                CamareroEN camareroEN = (CamareroEN)session.Load (typeof(CamareroEN), camarero.Id);


                session.Update (camareroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CamareroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (CamareroEN camarero)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (camarero);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CamareroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return camarero.Id;
}

public void Modificar (CamareroEN camarero)
{
        try
        {
                SessionInitializeTransaction ();
                CamareroEN camareroEN = (CamareroEN)session.Load (typeof(CamareroEN), camarero.Id);
                session.Update (camareroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CamareroCAD.", ex);
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
                CamareroEN camareroEN = (CamareroEN)session.Load (typeof(CamareroEN), id);
                session.Delete (camareroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CamareroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CamareroEN
public CamareroEN ReadOID (int id
                           )
{
        CamareroEN camareroEN = null;

        try
        {
                SessionInitializeTransaction ();
                camareroEN = (CamareroEN)session.Get (typeof(CamareroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CamareroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return camareroEN;
}

public System.Collections.Generic.IList<CamareroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CamareroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CamareroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CamareroEN>();
                else
                        result = session.CreateCriteria (typeof(CamareroEN)).List<CamareroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CamareroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
