using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class MetodoPagoAssemblerDTO {
public static IList<MetodoPagoEN> ConvertList (IList<MetodoPagoDTO> lista)
{
        IList<MetodoPagoEN> result = new List<MetodoPagoEN>();
        foreach (MetodoPagoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static MetodoPagoEN Convert (MetodoPagoDTO dto)
{
        MetodoPagoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new MetodoPagoEN ();



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
