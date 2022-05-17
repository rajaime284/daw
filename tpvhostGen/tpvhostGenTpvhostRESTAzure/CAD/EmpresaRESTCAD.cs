
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
public class EmpresaRESTCAD : EmpresaCAD
{
public EmpresaRESTCAD()
        : base ()
{
}

public EmpresaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<NegocioEN> GetAllNegocioByEmpresa (int id)
{
        IList<NegocioEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM NegocioEN self inner join self.Empresa as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<NegocioEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in EmpresaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public DuenyoEN GetDuenyoOfEmpresa (int id)
{
        DuenyoEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Dueño FROM EmpresaEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<DuenyoEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in EmpresaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
