
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
public class RolCajeroRESTCAD : RolCAD
{
public RolCajeroRESTCAD()
        : base ()
{
}

public RolCajeroRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public CocineroEN Cocinero (int id)
{
        CocineroEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Cocinero FROM RolEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<CocineroEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public CamareroEN Camarero (int id)
{
        CamareroEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Camarero FROM RolEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<CamareroEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public CajeroEN Cajero (int id)
{
        CajeroEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Cajero FROM RolEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<CajeroEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public EncargadoEN Encargado (int id)
{
        EncargadoEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Encargado FROM RolEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<EncargadoEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TpvhostGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TpvhostGenNHibernate.Exceptions.DataLayerException ("Error in RolRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
