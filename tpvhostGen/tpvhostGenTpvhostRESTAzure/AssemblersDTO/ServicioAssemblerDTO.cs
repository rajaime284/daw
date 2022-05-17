using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class ServicioAssemblerDTO {
public static IList<ServicioEN> ConvertList (IList<ServicioDTO> lista)
{
        IList<ServicioEN> result = new List<ServicioEN>();
        foreach (ServicioDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ServicioEN Convert (ServicioDTO dto)
{
        ServicioEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ServicioEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Negocio_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TpvhostGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = negocioCAD.ReadOIDDefault (dto.Negocio_oid);
                        }
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Costo = dto.Costo;

                        if (dto.LineaProveedor != null) {
                                TpvhostGenNHibernate.CAD.Rest.ILineaCompraProveedorCAD lineaCompraProveedorCAD = new TpvhostGenNHibernate.CAD.Rest.LineaCompraProveedorCAD ();

                                newinstance.LineaProveedor = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaCompraProveedorEN>();
                                foreach (LineaCompraProveedorDTO entry in dto.LineaProveedor) {
                                        newinstance.LineaProveedor.Add (LineaCompraProveedorAssemblerDTO.Convert (entry));
                                }
                        }
                        newinstance.CodigoContrato = dto.CodigoContrato;
                        if (dto.CategoriaServicio_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.ICategoriaServicioCAD categoriaServicioCAD = new TpvhostGenNHibernate.CAD.Rest.CategoriaServicioCAD ();

                                newinstance.CategoriaServicio = categoriaServicioCAD.ReadOIDDefault (dto.CategoriaServicio_oid);
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
