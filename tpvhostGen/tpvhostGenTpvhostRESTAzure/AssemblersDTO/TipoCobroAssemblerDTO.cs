using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class TipoCobroAssemblerDTO {
public static IList<TipoCobroEN> ConvertList (IList<TipoCobroDTO> lista)
{
        IList<TipoCobroEN> result = new List<TipoCobroEN>();
        foreach (TipoCobroDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static TipoCobroEN Convert (TipoCobroDTO dto)
{
        TipoCobroEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new TipoCobroEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Cobro_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ICobroCAD cobroCAD = new TpvhostGenNHibernate.CAD.Rest.CobroCAD ();

                                newinstance.Cobro = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CobroEN>();
                                foreach (int entry in dto.Cobro_oid) {
                                        newinstance.Cobro.Add (cobroCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Descripcion = dto.Descripcion;
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
