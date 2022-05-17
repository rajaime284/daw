
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
 * Clase TipoCobro:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class TipoCobroCAD : BasicCAD, ITipoCobroCAD
{
public TipoCobroCAD() : base ()
{
}

public TipoCobroCAD(ISession sessionAux) : base (sessionAux)
{
}



public TipoCobroEN ReadOIDDefault (int id
                                   )
{
        TipoCobroEN tipoCobroEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipoCobroEN = (TipoCobroEN)session.Get (typeof(TipoCobroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoCobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoCobroEN;
}

public System.Collections.Generic.IList<TipoCobroEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TipoCobroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TipoCobroEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TipoCobroEN>();
                        else
                                result = session.CreateCriteria (typeof(TipoCobroEN)).List<TipoCobroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoCobroCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TipoCobroEN tipoCobro)
{
        try
        {
                SessionInitializeTransaction ();
                TipoCobroEN tipoCobroEN = (TipoCobroEN)session.Load (typeof(TipoCobroEN), tipoCobro.Id);


                tipoCobroEN.Descripcion = tipoCobro.Descripcion;

                session.Update (tipoCobroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoCobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (TipoCobroEN tipoCobro)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tipoCobro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoCobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoCobro.Id;
}

public void Modificar (TipoCobroEN tipoCobro)
{
        try
        {
                SessionInitializeTransaction ();
                TipoCobroEN tipoCobroEN = (TipoCobroEN)session.Load (typeof(TipoCobroEN), tipoCobro.Id);

                tipoCobroEN.Descripcion = tipoCobro.Descripcion;

                session.Update (tipoCobroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoCobroCAD.", ex);
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
                TipoCobroEN tipoCobroEN = (TipoCobroEN)session.Load (typeof(TipoCobroEN), id);
                session.Delete (tipoCobroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoCobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: TipoCobroEN
public TipoCobroEN ReadOID (int id
                            )
{
        TipoCobroEN tipoCobroEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipoCobroEN = (TipoCobroEN)session.Get (typeof(TipoCobroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoCobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoCobroEN;
}

public System.Collections.Generic.IList<TipoCobroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TipoCobroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TipoCobroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TipoCobroEN>();
                else
                        result = session.CreateCriteria (typeof(TipoCobroEN)).List<TipoCobroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in TipoCobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
