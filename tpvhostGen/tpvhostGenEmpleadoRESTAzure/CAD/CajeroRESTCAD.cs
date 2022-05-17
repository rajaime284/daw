
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
public class CajeroRESTCAD : CajeroCAD
{
public CajeroRESTCAD()
        : base ()
{
}

public CajeroRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<CajaEN> Cajas (int id)
{
        IList<CajaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM CajaEN self inner join self.Cajero as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<CajaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in CajeroRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
