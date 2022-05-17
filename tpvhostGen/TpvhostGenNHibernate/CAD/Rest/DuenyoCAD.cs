
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
 * Clase Duenyo:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class DuenyoCAD : BasicCAD, IDuenyoCAD
{
public DuenyoCAD() : base ()
{
}

public DuenyoCAD(ISession sessionAux) : base (sessionAux)
{
}



public DuenyoEN ReadOIDDefault (int id
                                )
{
        DuenyoEN duenyoEN = null;

        try
        {
                SessionInitializeTransaction ();
                duenyoEN = (DuenyoEN)session.Get (typeof(DuenyoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in DuenyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return duenyoEN;
}

public System.Collections.Generic.IList<DuenyoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DuenyoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DuenyoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<DuenyoEN>();
                        else
                                result = session.CreateCriteria (typeof(DuenyoEN)).List<DuenyoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in DuenyoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DuenyoEN duenyo)
{
        try
        {
                SessionInitializeTransaction ();
                DuenyoEN duenyoEN = (DuenyoEN)session.Load (typeof(DuenyoEN), duenyo.Id);

                duenyoEN.Dni = duenyo.Dni;



                duenyoEN.Nombre = duenyo.Nombre;


                duenyoEN.Apellido = duenyo.Apellido;


                duenyoEN.Telefono = duenyo.Telefono;


                duenyoEN.Pass = duenyo.Pass;

                session.Update (duenyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in DuenyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (DuenyoEN duenyo)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (duenyo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in DuenyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return duenyo.Id;
}

public void Modificar (DuenyoEN duenyo)
{
        try
        {
                SessionInitializeTransaction ();
                DuenyoEN duenyoEN = (DuenyoEN)session.Load (typeof(DuenyoEN), duenyo.Id);

                duenyoEN.Dni = duenyo.Dni;


                duenyoEN.Nombre = duenyo.Nombre;


                duenyoEN.Apellido = duenyo.Apellido;


                duenyoEN.Telefono = duenyo.Telefono;


                duenyoEN.Pass = duenyo.Pass;

                session.Update (duenyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in DuenyoCAD.", ex);
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
                DuenyoEN duenyoEN = (DuenyoEN)session.Load (typeof(DuenyoEN), id);
                session.Delete (duenyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in DuenyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: DuenyoEN
public DuenyoEN ReadOID (int id
                         )
{
        DuenyoEN duenyoEN = null;

        try
        {
                SessionInitializeTransaction ();
                duenyoEN = (DuenyoEN)session.Get (typeof(DuenyoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in DuenyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return duenyoEN;
}

public System.Collections.Generic.IList<DuenyoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<DuenyoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(DuenyoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<DuenyoEN>();
                else
                        result = session.CreateCriteria (typeof(DuenyoEN)).List<DuenyoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in DuenyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
