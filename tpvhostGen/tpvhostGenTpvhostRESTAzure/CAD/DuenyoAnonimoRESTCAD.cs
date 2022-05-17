
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
public class DuenyoAnonimoRESTCAD : DuenyoCAD
{
public DuenyoAnonimoRESTCAD()
        : base ()
{
}

public DuenyoAnonimoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<EmpresaEN> GetAllEmpresaByDuenyo (int id)
{
        IList<EmpresaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM EmpresaEN self inner join self.Dueño as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<EmpresaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in DuenyoRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
