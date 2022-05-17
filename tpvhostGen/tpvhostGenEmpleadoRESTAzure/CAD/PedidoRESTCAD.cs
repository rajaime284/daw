
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

namespace tpvhostGenEmpleadoRESTAzure.CAD
{
public class PedidoRESTCAD : ComandaCAD
{
public PedidoRESTCAD()
        : base ()
{
}

public PedidoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<LineaComandaEN> Lineas (int id)
{
        IList<LineaComandaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaComandaEN self inner join self.Comanda as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaComandaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in ComandaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<CobroEN> PagoDePedido (int id)
{
        IList<CobroEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM CobroEN self inner join self.Comanda as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<CobroEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in ComandaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
