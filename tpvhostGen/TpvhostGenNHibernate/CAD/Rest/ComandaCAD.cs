
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
 * Clase Comanda:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class ComandaCAD : BasicCAD, IComandaCAD
{
public ComandaCAD() : base ()
{
}

public ComandaCAD(ISession sessionAux) : base (sessionAux)
{
}



public ComandaEN ReadOIDDefault (int id
                                 )
{
        ComandaEN comandaEN = null;

        try
        {
                SessionInitializeTransaction ();
                comandaEN = (ComandaEN)session.Get (typeof(ComandaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comandaEN;
}

public System.Collections.Generic.IList<ComandaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComandaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComandaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComandaEN>();
                        else
                                result = session.CreateCriteria (typeof(ComandaEN)).List<ComandaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComandaEN comanda)
{
        try
        {
                SessionInitializeTransaction ();
                ComandaEN comandaEN = (ComandaEN)session.Load (typeof(ComandaEN), comanda.Id);

                comandaEN.EstadoPedido = comanda.EstadoPedido;







                comandaEN.Fecha = comanda.Fecha;

                session.Update (comandaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (ComandaEN comanda)
{
        try
        {
                SessionInitializeTransaction ();
                if (comanda.Camarero != null) {
                        // Argumento OID y no colección.
                        comanda.Camarero = (TpvhostGenNHibernate.EN.Rest.CamareroEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.CamareroEN), comanda.Camarero.Id);

                        comanda.Camarero.Pedido
                        .Add (comanda);
                }
                if (comanda.Mesa != null) {
                        // Argumento OID y no colección.
                        comanda.Mesa = (TpvhostGenNHibernate.EN.Rest.MesaEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.MesaEN), comanda.Mesa.Id);

                        comanda.Mesa.Comanda
                        .Add (comanda);
                }

                session.Save (comanda);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comanda.Id;
}

public void Modificar (ComandaEN comanda)
{
        try
        {
                SessionInitializeTransaction ();
                ComandaEN comandaEN = (ComandaEN)session.Load (typeof(ComandaEN), comanda.Id);

                comandaEN.EstadoPedido = comanda.EstadoPedido;


                comandaEN.Fecha = comanda.Fecha;

                session.Update (comandaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
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
                ComandaEN comandaEN = (ComandaEN)session.Load (typeof(ComandaEN), id);
                session.Delete (comandaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ComandaEN
public ComandaEN ReadOID (int id
                          )
{
        ComandaEN comandaEN = null;

        try
        {
                SessionInitializeTransaction ();
                comandaEN = (ComandaEN)session.Get (typeof(ComandaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comandaEN;
}

public System.Collections.Generic.IList<ComandaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComandaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComandaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComandaEN>();
                else
                        result = session.CreateCriteria (typeof(ComandaEN)).List<ComandaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
