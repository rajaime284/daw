
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
 * Clase CategoriaServicio:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class CategoriaServicioCAD : BasicCAD, ICategoriaServicioCAD
{
public CategoriaServicioCAD() : base ()
{
}

public CategoriaServicioCAD(ISession sessionAux) : base (sessionAux)
{
}



public CategoriaServicioEN ReadOIDDefault (int id
                                           )
{
        CategoriaServicioEN categoriaServicioEN = null;

        try
        {
                SessionInitializeTransaction ();
                categoriaServicioEN = (CategoriaServicioEN)session.Get (typeof(CategoriaServicioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaServicioEN;
}

public System.Collections.Generic.IList<CategoriaServicioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CategoriaServicioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CategoriaServicioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CategoriaServicioEN>();
                        else
                                result = session.CreateCriteria (typeof(CategoriaServicioEN)).List<CategoriaServicioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaServicioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CategoriaServicioEN categoriaServicio)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaServicioEN categoriaServicioEN = (CategoriaServicioEN)session.Load (typeof(CategoriaServicioEN), categoriaServicio.Id);


                categoriaServicioEN.Descripcion = categoriaServicio.Descripcion;

                session.Update (categoriaServicioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (CategoriaServicioEN categoriaServicio)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (categoriaServicio);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaServicio.Id;
}

public void Modificar (CategoriaServicioEN categoriaServicio)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaServicioEN categoriaServicioEN = (CategoriaServicioEN)session.Load (typeof(CategoriaServicioEN), categoriaServicio.Id);

                categoriaServicioEN.Descripcion = categoriaServicio.Descripcion;

                session.Update (categoriaServicioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaServicioCAD.", ex);
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
                CategoriaServicioEN categoriaServicioEN = (CategoriaServicioEN)session.Load (typeof(CategoriaServicioEN), id);
                session.Delete (categoriaServicioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CategoriaServicioEN
public CategoriaServicioEN ReadOID (int id
                                    )
{
        CategoriaServicioEN categoriaServicioEN = null;

        try
        {
                SessionInitializeTransaction ();
                categoriaServicioEN = (CategoriaServicioEN)session.Get (typeof(CategoriaServicioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaServicioEN;
}

public System.Collections.Generic.IList<CategoriaServicioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CategoriaServicioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CategoriaServicioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CategoriaServicioEN>();
                else
                        result = session.CreateCriteria (typeof(CategoriaServicioEN)).List<CategoriaServicioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
