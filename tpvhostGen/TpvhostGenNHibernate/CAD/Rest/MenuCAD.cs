
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
 * Clase Menu:
 *
 */

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial class MenuCAD : BasicCAD, IMenuCAD
{
public MenuCAD() : base ()
{
}

public MenuCAD(ISession sessionAux) : base (sessionAux)
{
}



public MenuEN ReadOIDDefault (int id
                              )
{
        MenuEN menuEN = null;

        try
        {
                SessionInitializeTransaction ();
                menuEN = (MenuEN)session.Get (typeof(MenuEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MenuCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return menuEN;
}

public System.Collections.Generic.IList<MenuEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MenuEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MenuEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MenuEN>();
                        else
                                result = session.CreateCriteria (typeof(MenuEN)).List<MenuEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MenuCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MenuEN menu)
{
        try
        {
                SessionInitializeTransaction ();
                MenuEN menuEN = (MenuEN)session.Load (typeof(MenuEN), menu.Id);

                menuEN.Nombre = menu.Nombre;


                menuEN.Stock = menu.Stock;



                session.Update (menuEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MenuCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (MenuEN menu)
{
        try
        {
                SessionInitializeTransaction ();
                if (menu.LineaMenu != null) {
                        foreach (TpvhostGenNHibernate.EN.Rest.LineaMenuEN item in menu.LineaMenu) {
                                item.Menu = menu;
                                session.Save (item);
                        }
                }

                session.Save (menu);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MenuCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return menu.Id;
}

public void Modificar (MenuEN menu)
{
        try
        {
                SessionInitializeTransaction ();
                MenuEN menuEN = (MenuEN)session.Load (typeof(MenuEN), menu.Id);

                menuEN.Nombre = menu.Nombre;

                session.Update (menuEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MenuCAD.", ex);
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
                MenuEN menuEN = (MenuEN)session.Load (typeof(MenuEN), id);
                session.Delete (menuEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MenuCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: MenuEN
public MenuEN ReadOID (int id
                       )
{
        MenuEN menuEN = null;

        try
        {
                SessionInitializeTransaction ();
                menuEN = (MenuEN)session.Get (typeof(MenuEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MenuCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return menuEN;
}

public System.Collections.Generic.IList<MenuEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MenuEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MenuEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<MenuEN>();
                else
                        result = session.CreateCriteria (typeof(MenuEN)).List<MenuEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MenuCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
