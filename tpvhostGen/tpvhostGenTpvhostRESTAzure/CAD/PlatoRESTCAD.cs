
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
public class PlatoRESTCAD : PlatoCAD
{
public PlatoRESTCAD()
        : base ()
{
}

public PlatoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<LineaPlatoEN> LineasPlato (int id)
{
        IList<LineaPlatoEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaPlatoEN self inner join self.Plato as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaPlatoEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in PlatoRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<LineaPlatoEN> GetAllLineaPlatoByPlato (int id)
{
        IList<LineaPlatoEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaPlatoEN self inner join self.Plato as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaPlatoEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in PlatoRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
