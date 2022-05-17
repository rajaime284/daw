using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class NegocioAssemblerDTO {
public static IList<NegocioEN> ConvertList (IList<NegocioDTO> lista)
{
        IList<NegocioEN> result = new List<NegocioEN>();
        foreach (NegocioDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static NegocioEN Convert (NegocioDTO dto)
{
        NegocioEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new NegocioEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Direccion = dto.Direccion;
                        newinstance.Ciudad = dto.Ciudad;
                        newinstance.Cp = dto.Cp;
                        newinstance.Provincia = dto.Provincia;
                        newinstance.Pais = dto.Pais;
                        if (dto.Servicios_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IServicioCAD servicioCAD = new TpvhostGenNHibernate.CAD.Rest.ServicioCAD ();

                                newinstance.Servicios = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.ServicioEN>();
                                foreach (int entry in dto.Servicios_oid) {
                                        newinstance.Servicios.Add (servicioCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Empresa_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IEmpresaCAD empresaCAD = new TpvhostGenNHibernate.CAD.Rest.EmpresaCAD ();

                                newinstance.Empresa = empresaCAD.ReadOIDDefault (dto.Empresa_oid);
                        }
                        if (dto.Mesa_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IMesaCAD mesaCAD = new TpvhostGenNHibernate.CAD.Rest.MesaCAD ();

                                newinstance.Mesa = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.MesaEN>();
                                foreach (int entry in dto.Mesa_oid) {
                                        newinstance.Mesa.Add (mesaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Caja_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ICajaCAD cajaCAD = new TpvhostGenNHibernate.CAD.Rest.CajaCAD ();

                                newinstance.Caja = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CajaEN>();
                                foreach (int entry in dto.Caja_oid) {
                                        newinstance.Caja.Add (cajaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.CompraProveedor_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ICompraProveedorCAD compraProveedorCAD = new TpvhostGenNHibernate.CAD.Rest.CompraProveedorCAD ();

                                newinstance.CompraProveedor = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CompraProveedorEN>();
                                foreach (int entry in dto.CompraProveedor_oid) {
                                        newinstance.CompraProveedor.Add (compraProveedorCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Producto_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IProductoCAD productoCAD = new TpvhostGenNHibernate.CAD.Rest.ProductoCAD ();

                                newinstance.Producto = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.ProductoEN>();
                                foreach (int entry in dto.Producto_oid) {
                                        newinstance.Producto.Add (productoCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Empleado_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IEmpleadoCAD empleadoCAD = new TpvhostGenNHibernate.CAD.Rest.EmpleadoCAD ();

                                newinstance.Empleado = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.EmpleadoEN>();
                                foreach (int entry in dto.Empleado_oid) {
                                        newinstance.Empleado.Add (empleadoCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Cliente_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IClienteCAD clienteCAD = new TpvhostGenNHibernate.CAD.Rest.ClienteCAD ();

                                newinstance.Cliente = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.ClienteEN>();
                                foreach (int entry in dto.Cliente_oid) {
                                        newinstance.Cliente.Add (clienteCAD.ReadOIDDefault (entry));
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
