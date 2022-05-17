using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class LineaMenuAssemblerDTO {
public static IList<LineaMenuEN> ConvertList (IList<LineaMenuDTO> lista)
{
        IList<LineaMenuEN> result = new List<LineaMenuEN>();
        foreach (LineaMenuDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static LineaMenuEN Convert (LineaMenuDTO dto)
{
        LineaMenuEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new LineaMenuEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Cantidad = dto.Cantidad;
                        if (dto.Plato_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IPlatoCAD platoCAD = new TpvhostGenNHibernate.CAD.Rest.PlatoCAD ();

                                newinstance.Plato = platoCAD.ReadOIDDefault (dto.Plato_oid);
                        }
                        if (dto.Menu_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IMenuCAD menuCAD = new TpvhostGenNHibernate.CAD.Rest.MenuCAD ();

                                newinstance.Menu = menuCAD.ReadOIDDefault (dto.Menu_oid);
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
