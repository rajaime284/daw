
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
 * Clase Rol:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class RolCAD : BasicCAD, IRolCAD
{
public RolCAD() : base ()
{
}

public RolCAD(ISession sessionAux) : base (sessionAux)
{
}



public RolEN ReadOIDDefault (int id
                             )
{
        RolEN rolEN = null;

        try
        {
                SessionInitializeTransaction ();
                rolEN = (RolEN)session.Get (typeof(RolEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return rolEN;
}

public System.Collections.Generic.IList<RolEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RolEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RolEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RolEN>();
                        else
                                result = session.CreateCriteria (typeof(RolEN)).List<RolEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RolEN rol)
{
        try
        {
                SessionInitializeTransaction ();
                RolEN rolEN = (RolEN)session.Load (typeof(RolEN), rol.Id);





                rolEN.Empleo = rol.Empleo;


                session.Update (rolEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NuevoCajero (RolEN rol)
{
        try
        {
                SessionInitializeTransaction ();
                if (rol.Empleado != null) {
                        // Argumento OID y no colección.
                        rol.Empleado = (TpvhostGenNHibernate.EN.Rest.EmpleadoEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.EmpleadoEN), rol.Empleado.DNI);

                        rol.Empleado.Rol
                        .Add (rol);
                }

                session.Save (rol);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return rol.Id;
}

public void Modificar (RolEN rol)
{
        try
        {
                SessionInitializeTransaction ();
                RolEN rolEN = (RolEN)session.Load (typeof(RolEN), rol.Id);

                rolEN.Empleo = rol.Empleo;

                session.Update (rolEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
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
                RolEN rolEN = (RolEN)session.Load (typeof(RolEN), id);
                session.Delete (rolEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int NuevoCocinero (RolEN rol)
{
        try
        {
                SessionInitializeTransaction ();
                if (rol.Empleado != null) {
                        // Argumento OID y no colección.
                        rol.Empleado = (TpvhostGenNHibernate.EN.Rest.EmpleadoEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.EmpleadoEN), rol.Empleado.DNI);

                        rol.Empleado.Rol
                        .Add (rol);
                }

                session.Save (rol);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return rol.Id;
}

public int NuevoCamarero (RolEN rol)
{
        try
        {
                SessionInitializeTransaction ();
                if (rol.Empleado != null) {
                        // Argumento OID y no colección.
                        rol.Empleado = (TpvhostGenNHibernate.EN.Rest.EmpleadoEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.EmpleadoEN), rol.Empleado.DNI);

                        rol.Empleado.Rol
                        .Add (rol);
                }

                session.Save (rol);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return rol.Id;
}

public int NuevoEncargado (RolEN rol)
{
        try
        {
                SessionInitializeTransaction ();
                if (rol.Empleado != null) {
                        // Argumento OID y no colección.
                        rol.Empleado = (TpvhostGenNHibernate.EN.Rest.EmpleadoEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.EmpleadoEN), rol.Empleado.DNI);

                        rol.Empleado.Rol
                        .Add (rol);
                }

                session.Save (rol);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return rol.Id;
}

//Sin e: ReadOID
//Con e: RolEN
public RolEN ReadOID (int id
                      )
{
        RolEN rolEN = null;

        try
        {
                SessionInitializeTransaction ();
                rolEN = (RolEN)session.Get (typeof(RolEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return rolEN;
}

public System.Collections.Generic.IList<RolEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RolEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RolEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RolEN>();
                else
                        result = session.CreateCriteria (typeof(RolEN)).List<RolEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
