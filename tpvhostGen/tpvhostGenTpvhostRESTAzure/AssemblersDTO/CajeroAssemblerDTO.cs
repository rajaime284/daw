using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class CajeroAssemblerDTO {
public static IList<CajeroEN> ConvertList (IList<CajeroDTO> lista)
{
        IList<CajeroEN> result = new List<CajeroEN>();
        foreach (CajeroDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CajeroEN Convert (CajeroDTO dto)
{
        CajeroEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CajeroEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Rol_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IRolCAD rolCAD = new TpvhostGenNHibernate.CAD.Rest.RolCAD ();

                                newinstance.Rol = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.RolEN>();
                                foreach (int entry in dto.Rol_oid) {
                                        newinstance.Rol.Add (rolCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Caja_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ICajaCAD cajaCAD = new TpvhostGenNHibernate.CAD.Rest.CajaCAD ();

                                newinstance.Caja = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CajaEN>();
                                foreach (int entry in dto.Caja_oid) {
                                        newinstance.Caja.Add (cajaCAD.ReadOIDDefault (entry));
                                }
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
