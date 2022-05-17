
using System;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using System.Collections.Generic;

using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CAD.Rest;
using TpvhostGenNHibernate.CEN.Rest;

namespace tpvhostGenTpvhostRESTAzure.CAD
{
public class MenuRESTCAD : MenuCAD
{
public MenuRESTCAD()
        : base ()
{
}

public MenuRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<LineaMenuEN> LineasMenu (int id)
{
        IList<LineaMenuEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaMenuEN self inner join self.Menu as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaMenuEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MenuRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<LineaMenuEN> GetAllLineaMenuByMenu (int id)
{
        IList<LineaMenuEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaMenuEN self inner join self.Menu as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaMenuEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in MenuRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
