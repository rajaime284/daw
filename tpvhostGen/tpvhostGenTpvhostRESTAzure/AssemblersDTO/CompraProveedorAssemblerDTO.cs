using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class CompraProveedorAssemblerDTO {
public static IList<CompraProveedorEN> ConvertList (IList<CompraProveedorDTO> lista)
{
        IList<CompraProveedorEN> result = new List<CompraProveedorEN>();
        foreach (CompraProveedorDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CompraProveedorEN Convert (CompraProveedorDTO dto)
{
        CompraProveedorEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CompraProveedorEN ();



                        newinstance.Id = dto.Id;

                        if (dto.LineaCompraProveedor != null) {
                                TpvhostGenNHibernate.CAD.Rest.ILineaCompraProveedorCAD lineaCompraProveedorCAD = new TpvhostGenNHibernate.CAD.Rest.LineaCompraProveedorCAD ();

                                newinstance.LineaCompraProveedor = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN>();
                                foreach (LineaCompraProveedorDTO entry in dto.LineaCompraProveedor) {
                                        newinstance.LineaCompraProveedor.Add (LineaCompraProveedorAssemblerDTO.Convert (entry));
                                }
                        }
                        if (dto.Proveedor_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IProveedorCAD proveedorCAD = new TpvhostGenNHibernate.CAD.Rest.ProveedorCAD ();

                                newinstance.Proveedor = proveedorCAD.ReadOIDDefault (dto.Proveedor_oid);
                        }
                        if (dto.Negocio_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TpvhostGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = negocioCAD.ReadOIDDefault (dto.Negocio_oid);
                        }
                        if (dto.Pago_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IPagoCAD pagoCAD = new TpvhostGenNHibernate.CAD.Rest.PagoCAD ();

                                newinstance.Pago = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.PagoEN>();
                                foreach (int entry in dto.Pago_oid) {
                                        newinstance.Pago.Add (pagoCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Saldo = dto.Saldo;
                        newinstance.EstadoCompra = dto.EstadoCompra;
                        newinstance.Fecha = dto.Fecha;
                        newinstance.Total = dto.Total;
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
