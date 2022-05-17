using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class ClienteAssemblerDTO {
public static IList<ClienteEN> ConvertList (IList<ClienteDTO> lista)
{
        IList<ClienteEN> result = new List<ClienteEN>();
        foreach (ClienteDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ClienteEN Convert (ClienteDTO dto)
{
        ClienteEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ClienteEN ();



                        newinstance.Dni = dto.Dni;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Apellidos = dto.Apellidos;
                        if (dto.Factura_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IFacturaCAD facturaCAD = new TpvhostGenNHibernate.CAD.Rest.FacturaCAD ();

                                newinstance.Factura = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.FacturaEN>();
                                foreach (int entry in dto.Factura_oid) {
                                        newinstance.Factura.Add (facturaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Cobro_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ICobroCAD cobroCAD = new TpvhostGenNHibernate.CAD.Rest.CobroCAD ();

                                newinstance.Cobro = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CobroEN>();
                                foreach (int entry in dto.Cobro_oid) {
                                        newinstance.Cobro.Add (cobroCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Id = dto.Id;
                        if (dto.Negocio_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TpvhostGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = negocioCAD.ReadOIDDefault (dto.Negocio_oid);
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
