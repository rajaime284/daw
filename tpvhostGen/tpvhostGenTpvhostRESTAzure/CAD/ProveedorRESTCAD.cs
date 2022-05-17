
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
public class ProveedorRESTCAD : ProveedorCAD
{
public ProveedorRESTCAD()
        : base ()
{
}

public ProveedorRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<CompraProveedorEN> GetAllCompraProveedorByProveedor (int id)
{
        IList<CompraProveedorEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM CompraProveedorEN self inner join self.Proveedor as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<CompraProveedorEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
