
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
 * Clase metodoPago:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class MetodoPagoCAD : BasicCAD, IMetodoPagoCAD
{
public MetodoPagoCAD() : base ()
{
}

public MetodoPagoCAD(ISession sessionAux) : base (sessionAux)
{
}



public MetodoPagoEN ReadOIDDefault (int id
                                    )
{
        MetodoPagoEN metodoPagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                metodoPagoEN = (MetodoPagoEN)session.Get (typeof(MetodoPagoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MetodoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return metodoPagoEN;
}

public System.Collections.Generic.IList<MetodoPagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MetodoPagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MetodoPagoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MetodoPagoEN>();
                        else
                                result = session.CreateCriteria (typeof(MetodoPagoEN)).List<MetodoPagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MetodoPagoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MetodoPagoEN metodoPago)
{
        try
        {
                SessionInitializeTransaction ();
                MetodoPagoEN metodoPagoEN = (MetodoPagoEN)session.Load (typeof(MetodoPagoEN), metodoPago.Id);

                metodoPagoEN.Descripcion = metodoPago.Descripcion;


                session.Update (metodoPagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MetodoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (MetodoPagoEN metodoPago)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (metodoPago);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MetodoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return metodoPago.Id;
}

public void Modificar (MetodoPagoEN metodoPago)
{
        try
        {
                SessionInitializeTransaction ();
                MetodoPagoEN metodoPagoEN = (MetodoPagoEN)session.Load (typeof(MetodoPagoEN), metodoPago.Id);

                metodoPagoEN.Descripcion = metodoPago.Descripcion;

                session.Update (metodoPagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MetodoPagoCAD.", ex);
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
                MetodoPagoEN metodoPagoEN = (MetodoPagoEN)session.Load (typeof(MetodoPagoEN), id);
                session.Delete (metodoPagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MetodoPagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
