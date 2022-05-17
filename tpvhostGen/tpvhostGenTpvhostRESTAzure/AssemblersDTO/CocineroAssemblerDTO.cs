using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class CocineroAssemblerDTO {
public static IList<CocineroEN> ConvertList (IList<CocineroDTO> lista)
{
        IList<CocineroEN> result = new List<CocineroEN>();
        foreach (CocineroDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CocineroEN Convert (CocineroDTO dto)
{
        CocineroEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CocineroEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Rol_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IRolCAD rolCAD = new TpvhostGenNHibernate.CAD.Rest.RolCAD ();

                                newinstance.Rol = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.RolEN>();
                                foreach (int entry in dto.Rol_oid) {
                                        newinstance.Rol.Add (rolCAD.ReadOIDDefault (entry));
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
