using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class EncargadoAssemblerDTO {
public static IList<EncargadoEN> ConvertList (IList<EncargadoDTO> lista)
{
        IList<EncargadoEN> result = new List<EncargadoEN>();
        foreach (EncargadoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static EncargadoEN Convert (EncargadoDTO dto)
{
        EncargadoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new EncargadoEN ();



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
