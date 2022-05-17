
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
 * Clase Pago:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class PagoCAD : BasicCAD, IPagoCAD
{
public PagoCAD() : base ()
{
}

public PagoCAD(ISession sessionAux) : base (sessionAux)
{
}



public PagoEN ReadOIDDefault (int id
                              )
{
        PagoEN pagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pagoEN = (PagoEN)session.Get (typeof(PagoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PagoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PagoEN>();
                        else
                                result = session.CreateCriteria (typeof(PagoEN)).List<PagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                PagoEN pagoEN = (PagoEN)session.Load (typeof(PagoEN), pago.Id);

                pagoEN.IdPedidoProveedor = pago.IdPedidoProveedor;


                pagoEN.Monto = pago.Monto;



                pagoEN.FechaPago = pago.FechaPago;



                pagoEN.NumeroDocumento = pago.NumeroDocumento;


                session.Update (pagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                if (pago.TipoPago != null) {
                        // Argumento OID y no colección.
                        pago.TipoPago = (TpvhostGenNHibernate.EN.Rest.TipoPagoEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.TipoPagoEN), pago.TipoPago.Id);

                        pago.TipoPago.Pago
                        .Add (pago);
                }

                session.Save (pago);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pago.Id;
}

public void Modificar (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                PagoEN pagoEN = (PagoEN)session.Load (typeof(PagoEN), pago.Id);

                pagoEN.Monto = pago.Monto;


                pagoEN.FechaPago = pago.FechaPago;


                pagoEN.NumeroDocumento = pago.NumeroDocumento;

                session.Update (pagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
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
                PagoEN pagoEN = (PagoEN)session.Load (typeof(PagoEN), id);
                session.Delete (pagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
