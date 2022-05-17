
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
public class ProductoRESTCAD : ProductoCAD
{
public ProductoRESTCAD()
        : base ()
{
}

public ProductoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public UnidadMedidaEN GetUnidadMedidaByProducto (int id)
{
        UnidadMedidaEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.UnidadMedida FROM ProductoEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<UnidadMedidaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in ProductoRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
