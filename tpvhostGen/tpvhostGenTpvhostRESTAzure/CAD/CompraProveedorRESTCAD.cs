
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
public class CompraProveedorRESTCAD : CompraProveedorCAD
{
public CompraProveedorRESTCAD()
        : base ()
{
}

public CompraProveedorRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<LineaCompraProveedorEN> LineasCompraProveedor (int id)
{
        IList<LineaCompraProveedorEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaCompraProveedorEN self inner join self.CompraProveedor as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaCompraProveedorEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CompraProveedorRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
