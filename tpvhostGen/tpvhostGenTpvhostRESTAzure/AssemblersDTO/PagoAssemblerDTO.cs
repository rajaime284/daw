using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class PagoAssemblerDTO {
public static IList<PagoEN> ConvertList (IList<PagoDTO> lista)
{
        IList<PagoEN> result = new List<PagoEN>();
        foreach (PagoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static PagoEN Convert (PagoDTO dto)
{
        PagoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new PagoEN ();



                        newinstance.Id = dto.Id;
                        newinstance.IdPedidoProveedor = dto.IdPedidoProveedor;
                        newinstance.Monto = dto.Monto;
                        if (dto.CompraProveedor_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ICompraProveedorCAD compraProveedorCAD = new TpvhostGenNHibernate.CAD.Rest.CompraProveedorCAD ();

                                newinstance.CompraProveedor = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN>();
                                foreach (int entry in dto.CompraProveedor_oid) {
                                        newinstance.CompraProveedor.Add (compraProveedorCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.FechaPago = dto.FechaPago;
                        if (dto.TipoPago_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.ITipoPagoCAD tipoPagoCAD = new TpvhostGenNHibernate.CAD.Rest.TipoPagoCAD ();

                                newinstance.TipoPago = tipoPagoCAD.ReadOIDDefault (dto.TipoPago_oid);
                        }
                        newinstance.NumeroDocumento = dto.NumeroDocumento;
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
