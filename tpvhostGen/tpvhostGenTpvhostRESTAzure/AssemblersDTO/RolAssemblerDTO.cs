using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class RolAssemblerDTO {
public static IList<RolEN> ConvertList (IList<RolDTO> lista)
{
        IList<RolEN> result = new List<RolEN>();
        foreach (RolDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static RolEN Convert (RolDTO dto)
{
        RolEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new RolEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Cajero_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.ICajeroCAD cajeroCAD = new TpvhostGenNHibernate.CAD.Rest.CajeroCAD ();

                                newinstance.Cajero = cajeroCAD.ReadOIDDefault (dto.Cajero_oid);
                        }
                        if (dto.Cocinero_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.ICocineroCAD cocineroCAD = new TpvhostGenNHibernate.CAD.Rest.CocineroCAD ();

                                newinstance.Cocinero = cocineroCAD.ReadOIDDefault (dto.Cocinero_oid);
                        }
                        if (dto.Encargado_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IEncargadoCAD encargadoCAD = new TpvhostGenNHibernate.CAD.Rest.EncargadoCAD ();

                                newinstance.Encargado = encargadoCAD.ReadOIDDefault (dto.Encargado_oid);
                        }
                        if (dto.Camarero_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.ICamareroCAD camareroCAD = new TpvhostGenNHibernate.CAD.Rest.CamareroCAD ();

                                newinstance.Camarero = camareroCAD.ReadOIDDefault (dto.Camarero_oid);
                        }
                        newinstance.Empleo = dto.Empleo;
                        if (dto.Empleado_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IEmpleadoCAD empleadoCAD = new TpvhostGenNHibernate.CAD.Rest.EmpleadoCAD ();

                                newinstance.Empleado = empleadoCAD.ReadOIDDefault (dto.Empleado_oid);
                        }
                }
        }
        catch (Exception ex)
        {
                throw ex;
        }
        return newinstance;
}
}
}
