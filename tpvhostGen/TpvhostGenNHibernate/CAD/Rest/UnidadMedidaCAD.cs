
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
 * Clase UnidadMedida:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class UnidadMedidaCAD : BasicCAD, IUnidadMedidaCAD
{
public UnidadMedidaCAD() : base ()
{
}

public UnidadMedidaCAD(ISession sessionAux) : base (sessionAux)
{
}



public UnidadMedidaEN ReadOIDDefault (int id
                                      )
{
        UnidadMedidaEN unidadMedidaEN = null;

        try
        {
                SessionInitializeTransaction ();
                unidadMedidaEN = (UnidadMedidaEN)session.Get (typeof(UnidadMedidaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in UnidadMedidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return unidadMedidaEN;
}

public System.Collections.Generic.IList<UnidadMedidaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UnidadMedidaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UnidadMedidaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UnidadMedidaEN>();
                        else
                                result = session.CreateCriteria (typeof(UnidadMedidaEN)).List<UnidadMedidaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in UnidadMedidaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UnidadMedidaEN unidadMedida)
{
        try
        {
                SessionInitializeTransaction ();
                UnidadMedidaEN unidadMedidaEN = (UnidadMedidaEN)session.Load (typeof(UnidadMedidaEN), unidadMedida.Id);

                unidadMedidaEN.Descripcion = unidadMedida.Descripcion;


                session.Update (unidadMedidaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in UnidadMedidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (UnidadMedidaEN unidadMedida)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (unidadMedida);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in UnidadMedidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return unidadMedida.Id;
}

public void Modificar (UnidadMedidaEN unidadMedida)
{
        try
        {
                SessionInitializeTransaction ();
                UnidadMedidaEN unidadMedidaEN = (UnidadMedidaEN)session.Load (typeof(UnidadMedidaEN), unidadMedida.Id);

                unidadMedidaEN.Descripcion = unidadMedida.Descripcion;

                session.Update (unidadMedidaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in UnidadMedidaCAD.", ex);
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
                UnidadMedidaEN unidadMedidaEN = (UnidadMedidaEN)session.Load (typeof(UnidadMedidaEN), id);
                session.Delete (unidadMedidaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in UnidadMedidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: UnidadMedidaEN
public UnidadMedidaEN ReadOID (int id
                               )
{
        UnidadMedidaEN unidadMedidaEN = null;

        try
        {
                SessionInitializeTransaction ();
                unidadMedidaEN = (UnidadMedidaEN)session.Get (typeof(UnidadMedidaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in UnidadMedidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return unidadMedidaEN;
}

public System.Collections.Generic.IList<UnidadMedidaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UnidadMedidaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UnidadMedidaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UnidadMedidaEN>();
                else
                        result = session.CreateCriteria (typeof(UnidadMedidaEN)).List<UnidadMedidaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in UnidadMedidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
