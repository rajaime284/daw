using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class ComandaAssemblerDTO {
public static IList<ComandaEN> ConvertList (IList<ComandaDTO> lista)
{
        IList<ComandaEN> result = new List<ComandaEN>();
        foreach (ComandaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ComandaEN Convert (ComandaDTO dto)
{
        ComandaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ComandaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.EstadoPedido = dto.EstadoPedido;
                        if (dto.Camarero_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.ICamareroCAD camareroCAD = new TpvhostGenNHibernate.CAD.Rest.CamareroCAD ();

                                newinstance.Camarero = camareroCAD.ReadOIDDefault (dto.Camarero_oid);
                        }

                        if (dto.LineaComanda != null) {
                                TpvhostGenNHibernate.CAD.Rest.ILineaComandaCAD lineaComandaCAD = new TpvhostGenNHibernate.CAD.Rest.LineaComandaCAD ();

                                newinstance.LineaComanda = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaComandaEN>();
                                foreach (LineaComandaDTO entry in dto.LineaComanda) {
                                        newinstance.LineaComanda.Add (LineaComandaAssemblerDTO.Convert (entry));
                                }
                        }
                        if (dto.Pago_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ICobroCAD cobroCAD = new TpvhostGenNHibernate.CAD.Rest.CobroCAD ();

                                newinstance.Pago = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CobroEN>();
                                foreach (int entry in dto.Pago_oid) {
                                        newinstance.Pago.Add (cobroCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Mesa_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IMesaCAD mesaCAD = new TpvhostGenNHibernate.CAD.Rest.MesaCAD ();

                                newinstance.Mesa = mesaCAD.ReadOIDDefault (dto.Mesa_oid);
                        }
                        if (dto.Factura_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IFacturaCAD facturaCAD = new TpvhostGenNHibernate.CAD.Rest.FacturaCAD ();

                                newinstance.Factura = facturaCAD.ReadOIDDefault (dto.Factura_oid);
                        }
                        newinstance.Fecha = dto.Fecha;
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
