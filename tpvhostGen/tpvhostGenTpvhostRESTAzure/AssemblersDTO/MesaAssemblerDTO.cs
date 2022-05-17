using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class MesaAssemblerDTO {
public static IList<MesaEN> ConvertList (IList<MesaDTO> lista)
{
        IList<MesaEN> result = new List<MesaEN>();
        foreach (MesaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static MesaEN Convert (MesaDTO dto)
{
        MesaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new MesaEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Comanda_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IComandaCAD comandaCAD = new TpvhostGenNHibernate.CAD.Rest.ComandaCAD ();

                                newinstance.Comanda = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.ComandaEN>();
                                foreach (int entry in dto.Comanda_oid) {
                                        newinstance.Comanda.Add (comandaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Negocio_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TpvhostGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = negocioCAD.ReadOIDDefault (dto.Negocio_oid);
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
