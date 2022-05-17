
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
 * Clase Negocio:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class NegocioCAD : BasicCAD, INegocioCAD
{
public NegocioCAD() : base ()
{
}

public NegocioCAD(ISession sessionAux) : base (sessionAux)
{
}



public NegocioEN ReadOIDDefault (int id
                                 )
{
        NegocioEN negocioEN = null;

        try
        {
                SessionInitializeTransaction ();
                negocioEN = (NegocioEN)session.Get (typeof(NegocioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return negocioEN;
}

public System.Collections.Generic.IList<NegocioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NegocioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NegocioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NegocioEN>();
                        else
                                result = session.CreateCriteria (typeof(NegocioEN)).List<NegocioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NegocioEN negocio)
{
        try
        {
                SessionInitializeTransaction ();
                NegocioEN negocioEN = (NegocioEN)session.Load (typeof(NegocioEN), negocio.Id);

                negocioEN.Nombre = negocio.Nombre;


                negocioEN.Direccion = negocio.Direccion;


                negocioEN.Ciudad = negocio.Ciudad;


                negocioEN.Cp = negocio.Cp;


                negocioEN.Provincia = negocio.Provincia;


                negocioEN.Pais = negocio.Pais;









                session.Update (negocioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (NegocioEN negocio)
{
        try
        {
                SessionInitializeTransaction ();
                if (negocio.Empresa != null) {
                        // Argumento OID y no colección.
                        negocio.Empresa = (TpvhostGenNHibernate.EN.Rest.EmpresaEN)session.Load (typeof(TpvhostGenNHibernate.EN.Rest.EmpresaEN), negocio.Empresa.Id);

                        negocio.Empresa.Negocio
                        .Add (negocio);
                }

                session.Save (negocio);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return negocio.Id;
}

public void Modificar (NegocioEN negocio)
{
        try
        {
                SessionInitializeTransaction ();
                NegocioEN negocioEN = (NegocioEN)session.Load (typeof(NegocioEN), negocio.Id);

                negocioEN.Nombre = negocio.Nombre;


                negocioEN.Direccion = negocio.Direccion;


                negocioEN.Ciudad = negocio.Ciudad;


                negocioEN.Cp = negocio.Cp;


                negocioEN.Provincia = negocio.Provincia;


                negocioEN.Pais = negocio.Pais;

                session.Update (negocioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioCAD.", ex);
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
                NegocioEN negocioEN = (NegocioEN)session.Load (typeof(NegocioEN), id);
                session.Delete (negocioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: NegocioEN
public NegocioEN ReadOID (int id
                          )
{
        NegocioEN negocioEN = null;

        try
        {
                SessionInitializeTransaction ();
                negocioEN = (NegocioEN)session.Get (typeof(NegocioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return negocioEN;
}

public System.Collections.Generic.IList<NegocioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NegocioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NegocioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NegocioEN>();
                else
                        result = session.CreateCriteria (typeof(NegocioEN)).List<NegocioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
