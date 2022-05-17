using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class LineaCompraProveedorAssemblerDTO {
public static IList<LineaCompraProveedorEN> ConvertList (IList<LineaCompraProveedorDTO> lista)
{
        IList<LineaCompraProveedorEN> result = new List<LineaCompraProveedorEN>();
        foreach (LineaCompraProveedorDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static LineaCompraProveedorEN Convert (LineaCompraProveedorDTO dto)
{
        LineaCompraProveedorEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new LineaCompraProveedorEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Cantidad = dto.Cantidad;
                        if (dto.Servicio_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IServicioCAD servicioCAD = new TpvhostGenNHibernate.CAD.Rest.ServicioCAD ();

                                newinstance.Servicio = servicioCAD.ReadOIDDefault (dto.Servicio_oid);
                        }
                        if (dto.CompraProveedor_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.ICompraProveedorCAD compraProveedorCAD = new TpvhostGenNHibernate.CAD.Rest.CompraProveedorCAD ();

                                newinstance.CompraProveedor = compraProveedorCAD.ReadOIDDefault (dto.CompraProveedor_oid);
                        }
                        if (dto.Producto_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IProductoCAD productoCAD = new TpvhostGenNHibernate.CAD.Rest.ProductoCAD ();

                                newinstance.Producto = productoCAD.ReadOIDDefault (dto.Producto_oid);
                        }
                        newinstance.Costo = dto.Costo;
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
