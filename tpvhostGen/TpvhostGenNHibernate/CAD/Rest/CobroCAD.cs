
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
 * Clase Cobro:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class CobroCAD : BasicCAD, ICobroCAD
{
public CobroCAD() : base ()
{
}

public CobroCAD(ISession sessionAux) : base (sessionAux)
{
}



public CobroEN ReadOIDDefault (int id
                               )
{
        CobroEN cobroEN = null;

        try
        {
                SessionInitializeTransaction ();
                cobroEN = (CobroEN)session.Get (typeof(CobroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cobroEN;
}

public System.Collections.Generic.IList<CobroEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CobroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CobroEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CobroEN>();
                        else
                                result = session.CreateCriteria (typeof(CobroEN)).List<CobroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CobroEN cobro)
{
        try
        {
                SessionInitializeTransaction ();
                CobroEN cobroEN = (CobroEN)session.Load (typeof(CobroEN), cobro.Id);

                cobroEN.Monto = cobro.Monto;




                cobroEN.TipoDeCobro = cobro.TipoDeCobro;




                cobroEN.NumeroTransaccion = cobro.NumeroTransaccion;

                session.Update (cobroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (CobroEN cobro)
{
        try
        {
                SessionInitializeTransaction ();
                if (cobro.Comanda != null) {
                        // Argumento OID y no colección.
                        cobro.Comanda = (TpvhostGenNHibernate.EN.Rest.ComandaEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.ComandaEN), cobro.Comanda.Id);

                        cobro.Comanda.Pago
                        .Add (cobro);
                }
                if (cobro.Cliente != null) {
                        // Argumento OID y no colección.
                        cobro.Cliente = (TpvhostGenNHibernate.EN.Rest.ClienteEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.ClienteEN), cobro.Cliente.Id);

                        cobro.Cliente.Cobro
                        .Add (cobro);
                }
                if (cobro.TipoCobro != null) {
                        // Argumento OID y no colección.
                        cobro.TipoCobro = (TpvhostGenNHibernate.EN.Rest.TipoCobroEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.TipoCobroEN), cobro.TipoCobro.Id);

                        cobro.TipoCobro.Cobro
                        .Add (cobro);
                }

                session.Save (cobro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cobro.Id;
}

public void Modificar (CobroEN cobro)
{
        try
        {
                SessionInitializeTransaction ();
                CobroEN cobroEN = (CobroEN)session.Load (typeof(CobroEN), cobro.Id);

                cobroEN.Monto = cobro.Monto;


                cobroEN.TipoDeCobro = cobro.TipoDeCobro;


                cobroEN.NumeroTransaccion = cobro.NumeroTransaccion;

                session.Update (cobroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
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
                CobroEN cobroEN = (CobroEN)session.Load (typeof(CobroEN), id);
                session.Delete (cobroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CobroEN
public CobroEN ReadOID (int id
                        )
{
        CobroEN cobroEN = null;

        try
        {
                SessionInitializeTransaction ();
                cobroEN = (CobroEN)session.Get (typeof(CobroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cobroEN;
}

public System.Collections.Generic.IList<CobroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CobroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CobroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CobroEN>();
                else
                        result = session.CreateCriteria (typeof(CobroEN)).List<CobroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
