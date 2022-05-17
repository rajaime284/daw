
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
public class NegocioRESTCAD : NegocioCAD
{
public NegocioRESTCAD()
        : base ()
{
}

public NegocioRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public EmpresaEN GetEmpresaOfNegocio (int id)
{
        EmpresaEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Empresa FROM NegocioEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<EmpresaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<ServicioEN> GetAllServiciosByNegocio (int id)
{
        IList<ServicioEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM ServicioEN self inner join self.Negocio as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<ServicioEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<ProductoEN> GetAllProductoByNegocio (int id)
{
        IList<ProductoEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM ProductoEN self inner join self.Negocio as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<ProductoEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<EmpleadoEN> GetAllEmpleadoByNegocio (int id)
{
        IList<EmpleadoEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM EmpleadoEN self inner join self.Negocio as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<EmpleadoEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<CajaEN> GetAllCajasByNegocio (int id)
{
        IList<CajaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM CajaEN self inner join self.Negocio as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<CajaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<ClienteEN> GetAllClienteOfNegocio (int id)
{
        IList<ClienteEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM ClienteEN self inner join self.Negocio as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<ClienteEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in NegocioRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
