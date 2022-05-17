
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
 * Clase Caja:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class CajaCAD : BasicCAD, ICajaCAD
{
public CajaCAD() : base ()
{
}

public CajaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CajaEN ReadOIDDefault (int id
                              )
{
        CajaEN cajaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cajaEN = (CajaEN)session.Get (typeof(CajaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cajaEN;
}

public System.Collections.Generic.IList<CajaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CajaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CajaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CajaEN>();
                        else
                                result = session.CreateCriteria (typeof(CajaEN)).List<CajaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CajaEN caja)
{
        try
        {
                SessionInitializeTransaction ();
                CajaEN cajaEN = (CajaEN)session.Load (typeof(CajaEN), caja.Id);

                cajaEN.Fondo = caja.Fondo;





                cajaEN.Saldo = caja.Saldo;



                cajaEN.Descripcion = caja.Descripcion;

                session.Update (cajaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (CajaEN caja)
{
        try
        {
                SessionInitializeTransaction ();
                if (caja.Negocio != null) {
                        // Argumento OID y no colección.
                        caja.Negocio = (TpvhostGenNHibernate.EN.Rest.NegocioEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.NegocioEN), caja.Negocio.Id);

                        caja.Negocio.Caja
                        .Add (caja);
                }

                session.Save (caja);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return caja.Id;
}

public void Modificar (CajaEN caja)
{
        try
        {
                SessionInitializeTransaction ();
                CajaEN cajaEN = (CajaEN)session.Load (typeof(CajaEN), caja.Id);

                cajaEN.Descripcion = caja.Descripcion;

                session.Update (cajaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
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
                CajaEN cajaEN = (CajaEN)session.Load (typeof(CajaEN), id);
                session.Delete (cajaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CajaEN
public CajaEN ReadOID (int id
                       )
{
        CajaEN cajaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cajaEN = (CajaEN)session.Get (typeof(CajaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cajaEN;
}

public System.Collections.Generic.IList<CajaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CajaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CajaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CajaEN>();
                else
                        result = session.CreateCriteria (typeof(CajaEN)).List<CajaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
