using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class UnidadMedidaAssemblerDTO {
public static IList<UnidadMedidaEN> ConvertList (IList<UnidadMedidaDTO> lista)
{
        IList<UnidadMedidaEN> result = new List<UnidadMedidaEN>();
        foreach (UnidadMedidaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static UnidadMedidaEN Convert (UnidadMedidaDTO dto)
{
        UnidadMedidaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new UnidadMedidaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Descripcion = dto.Descripcion;
                        if (dto.Producto_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IProductoCAD productoCAD = new TpvhostGenNHibernate.CAD.Rest.ProductoCAD ();

                                newinstance.Producto = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.ProductoEN>();
                                foreach (int entry in dto.Producto_oid) {
                                        newinstance.Producto.Add (productoCAD.ReadOIDDefault (entry));
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
