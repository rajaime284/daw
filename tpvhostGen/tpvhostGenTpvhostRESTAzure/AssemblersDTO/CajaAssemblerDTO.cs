using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class CajaAssemblerDTO {
public static IList<CajaEN> ConvertList (IList<CajaDTO> lista)
{
        IList<CajaEN> result = new List<CajaEN>();
        foreach (CajaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CajaEN Convert (CajaDTO dto)
{
        CajaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CajaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Fondo = dto.Fondo;
                        if (dto.Negocio_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TpvhostGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = negocioCAD.ReadOIDDefault (dto.Negocio_oid);
                        }
                        if (dto.Cajero_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ICajeroCAD cajeroCAD = new TpvhostGenNHibernate.CAD.Rest.CajeroCAD ();

                                newinstance.Cajero = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CajeroEN>();
                                foreach (int entry in dto.Cajero_oid) {
                                        newinstance.Cajero.Add (cajeroCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Pago_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IPagoCAD pagoCAD = new TpvhostGenNHibernate.CAD.Rest.PagoCAD ();

                                newinstance.Pago = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.PagoEN>();
                                foreach (int entry in dto.Pago_oid) {
                                        newinstance.Pago.Add (pagoCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Saldo = dto.Saldo;
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
