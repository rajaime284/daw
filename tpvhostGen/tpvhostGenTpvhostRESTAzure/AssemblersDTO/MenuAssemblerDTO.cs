using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class MenuAssemblerDTO {
public static IList<MenuEN> ConvertList (IList<MenuDTO> lista)
{
        IList<MenuEN> result = new List<MenuEN>();
        foreach (MenuDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static MenuEN Convert (MenuDTO dto)
{
        MenuEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new MenuEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Stock = dto.Stock;
                        if (dto.LineaComanda_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.ILineaComandaCAD lineaComandaCAD = new TpvhostGenNHibernate.CAD.Rest.LineaComandaCAD ();

                                newinstance.LineaComanda = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaComandaEN>();
                                foreach (int entry in dto.LineaComanda_oid) {
                                        newinstance.LineaComanda.Add (lineaComandaCAD.ReadOIDDefault (entry));
                                }
                        }

                        if (dto.LineaMenu != null) {
                                TpvhostGenNHibernate.CAD.Rest.ILineaMenuCAD lineaMenuCAD = new TpvhostGenNHibernate.CAD.Rest.LineaMenuCAD ();

                                newinstance.LineaMenu = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.LineaMenuEN>();
                                foreach (LineaMenuDTO entry in dto.LineaMenu) {
                                        newinstance.LineaMenu.Add (LineaMenuAssemblerDTO.Convert (entry));
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
