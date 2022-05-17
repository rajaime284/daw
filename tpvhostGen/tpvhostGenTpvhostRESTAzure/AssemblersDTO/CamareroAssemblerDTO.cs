using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class CamareroAssemblerDTO {
public static IList<CamareroEN> ConvertList (IList<CamareroDTO> lista)
{
        IList<CamareroEN> result = new List<CamareroEN>();
        foreach (CamareroDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CamareroEN Convert (CamareroDTO dto)
{
        CamareroEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CamareroEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Rol_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IRolCAD rolCAD = new TpvhostGenNHibernate.CAD.Rest.RolCAD ();

                                newinstance.Rol = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.RolEN>();
                                foreach (int entry in dto.Rol_oid) {
                                        newinstance.Rol.Add (rolCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Pedido_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IComandaCAD comandaCAD = new TpvhostGenNHibernate.CAD.Rest.ComandaCAD ();

                                newinstance.Pedido = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.ComandaEN>();
                                foreach (int entry in dto.Pedido_oid) {
                                        newinstance.Pedido.Add (comandaCAD.ReadOIDDefault (entry));
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
