using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenEmpleadoRESTAzure.DTO;

namespace tpvhostGenEmpleadoRESTAzure.AssemblersDTO
{
public class PlatoAssemblerDTO {
public static IList<PlatoEN> ConvertList (IList<PlatoDTO> lista)
{
        IList<PlatoEN> result = new List<PlatoEN>();
        foreach (PlatoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static PlatoEN Convert (PlatoDTO dto)
{
        PlatoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new PlatoEN ();



                        newinstance.Id = dto.Id;
                        if (dto.LineaComanda_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ILineaComandaCAD lineaComandaCAD = new TpvhostGenNHibernate.CAD.Rest.LineaComandaCAD ();

                                newinstance.LineaComanda = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaComandaEN>();
                                foreach (int entry in dto.LineaComanda_oid) {
                                        newinstance.LineaComanda.Add (lineaComandaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.LineaPlato_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ILineaPlatoCAD lineaPlatoCAD = new TpvhostGenNHibernate.CAD.Rest.LineaPlatoCAD ();

                                newinstance.LineaPlato = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaPlatoEN>();
                                foreach (int entry in dto.LineaPlato_oid) {
                                        newinstance.LineaPlato.Add (lineaPlatoCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Stock = dto.Stock;
                        newinstance.Precio = dto.Precio;
                        if (dto.LineaMenu_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ILineaMenuCAD lineaMenuCAD = new TpvhostGenNHibernate.CAD.Rest.LineaMenuCAD ();

                                newinstance.LineaMenu = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaMenuEN>();
                                foreach (int entry in dto.LineaMenu_oid) {
                                        newinstance.LineaMenu.Add (lineaMenuCAD.ReadOIDDefault (entry));
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
