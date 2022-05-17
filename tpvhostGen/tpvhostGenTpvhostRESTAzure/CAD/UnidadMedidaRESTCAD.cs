
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
public class UnidadMedidaRESTCAD : UnidadMedidaCAD
{
public UnidadMedidaRESTCAD()
        : base ()
{
}

public UnidadMedidaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<ProductoEN> GetAllProductoOfUnidadMedida (int id)
{
        IList<ProductoEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM ProductoEN self inner join self.UnidadMedida as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<ProductoEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in UnidadMedidaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
