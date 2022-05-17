using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class CobroAssemblerDTO {
public static IList<CobroEN> ConvertList (IList<CobroDTO> lista)
{
        IList<CobroEN> result = new List<CobroEN>();
        foreach (CobroDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CobroEN Convert (CobroDTO dto)
{
        CobroEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CobroEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Monto = dto.Monto;
                        if (dto.Comanda_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IComandaCAD comandaCAD = new TpvhostGenNHibernate.CAD.Rest.ComandaCAD ();

                                newinstance.Comanda = comandaCAD.ReadOIDDefault (dto.Comanda_oid);
                        }
                        if (dto.Cliente_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IClienteCAD clienteCAD = new TpvhostGenNHibernate.CAD.Rest.ClienteCAD ();

                                newinstance.Cliente = clienteCAD.ReadOIDDefault (dto.Cliente_oid);
                        }
                        newinstance.TipoDeCobro = dto.TipoDeCobro;
                        if (dto.TipoCobro_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.ITipoCobroCAD tipoCobroCAD = new TpvhostGenNHibernate.CAD.Rest.TipoCobroCAD ();

                                newinstance.TipoCobro = tipoCobroCAD.ReadOIDDefault (dto.TipoCobro_oid);
                        }
                        if (dto.Caja_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ICajaCAD cajaCAD = new TpvhostGenNHibernate.CAD.Rest.CajaCAD ();

                                newinstance.Caja = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.CajaEN>();
                                foreach (int entry in dto.Caja_oid) {
                                        newinstance.Caja.Add (cajaCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.NumeroTransaccion = dto.NumeroTransaccion;
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
