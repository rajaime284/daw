
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
 * Clase Mesa:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class MesaCAD : BasicCAD, IMesaCAD
{
public MesaCAD() : base ()
{
}

public MesaCAD(ISession sessionAux) : base (sessionAux)
{
}



public MesaEN ReadOIDDefault (int id
                              )
{
        MesaEN mesaEN = null;

        try
        {
                SessionInitializeTransaction ();
                mesaEN = (MesaEN)session.Get (typeof(MesaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MesaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mesaEN;
}

public System.Collections.Generic.IList<MesaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MesaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MesaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MesaEN>();
                        else
                                result = session.CreateCriteria (typeof(MesaEN)).List<MesaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MesaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MesaEN mesa)
{
        try
        {
                SessionInitializeTransaction ();
                MesaEN mesaEN = (MesaEN)session.Load (typeof(MesaEN), mesa.Id);


                session.Update (mesaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MesaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (MesaEN mesa)
{
        try
        {
                SessionInitializeTransaction ();
                if (mesa.Negocio != null) {
                        // Argumento OID y no colección.
                        mesa.Negocio = (TpvhostGenNHibernate.EN.Rest.NegocioEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.NegocioEN), mesa.Negocio.Id);

                        mesa.Negocio.Mesa
                        .Add (mesa);
                }

                session.Save (mesa);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MesaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mesa.Id;
}

public void Modificar (MesaEN mesa)
{
        try
        {
                SessionInitializeTransaction ();
                MesaEN mesaEN = (MesaEN)session.Load (typeof(MesaEN), mesa.Id);
                session.Update (mesaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MesaCAD.", ex);
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
                MesaEN mesaEN = (MesaEN)session.Load (typeof(MesaEN), id);
                session.Delete (mesaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MesaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: MesaEN
public MesaEN ReadOID (int id
                       )
{
        MesaEN mesaEN = null;

        try
        {
                SessionInitializeTransaction ();
                mesaEN = (MesaEN)session.Get (typeof(MesaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MesaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mesaEN;
}

public System.Collections.Generic.IList<MesaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MesaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MesaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<MesaEN>();
                else
                        result = session.CreateCriteria (typeof(MesaEN)).List<MesaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MesaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
