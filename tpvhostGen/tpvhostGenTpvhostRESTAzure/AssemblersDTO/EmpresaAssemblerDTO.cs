using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class EmpresaAssemblerDTO {
public static IList<EmpresaEN> ConvertList (IList<EmpresaDTO> lista)
{
        IList<EmpresaEN> result = new List<EmpresaEN>();
        foreach (EmpresaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static EmpresaEN Convert (EmpresaDTO dto)
{
        EmpresaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new EmpresaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Direccion = dto.Direccion;
                        if (dto.Dueño_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.IDuenyoCAD duenyoCAD = new TpvhostGenNHibernate.CAD.Rest.DuenyoCAD ();

                                newinstance.Dueño = duenyoCAD.ReadOIDDefault (dto.Dueño_oid);
                        }
                        if (dto.Negocio_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TpvhostGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.NegocioEN>();
                                foreach (int entry in dto.Negocio_oid) {
                                        newinstance.Negocio.Add (negocioCAD.ReadOIDDefault (entry));
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
