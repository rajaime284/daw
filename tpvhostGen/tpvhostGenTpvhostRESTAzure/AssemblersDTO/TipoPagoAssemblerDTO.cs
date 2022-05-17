using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class TipoPagoAssemblerDTO {
public static IList<TipoPagoEN> ConvertList (IList<TipoPagoDTO> lista)
{
        IList<TipoPagoEN> result = new List<TipoPagoEN>();
        foreach (TipoPagoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static TipoPagoEN Convert (TipoPagoDTO dto)
{
        TipoPagoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new TipoPagoEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Descripcion = dto.Descripcion;
                        if (dto.Pago_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IPagoCAD pagoCAD = new TpvhostGenNHibernate.CAD.Rest.PagoCAD ();

                                newinstance.Pago = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.PagoEN>();
                                foreach (int entry in dto.Pago_oid) {
                                        newinstance.Pago.Add (pagoCAD.ReadOIDDefault (entry));
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
