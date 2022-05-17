using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class DuenyoAssemblerDTO {
public static IList<DuenyoEN> ConvertList (IList<DuenyoDTO> lista)
{
        IList<DuenyoEN> result = new List<DuenyoEN>();
        foreach (DuenyoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static DuenyoEN Convert (DuenyoDTO dto)
{
        DuenyoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new DuenyoEN ();



                        newinstance.Dni = dto.Dni;
                        if (dto.Empresa_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IEmpresaCAD empresaCAD = new TpvhostGenNHibernate.CAD.Rest.EmpresaCAD ();

                                newinstance.Empresa = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.EmpresaEN>();
                                foreach (int entry in dto.Empresa_oid) {
                                        newinstance.Empresa.Add (empresaCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Apellido = dto.Apellido;
                        newinstance.Telefono = dto.Telefono;
                        newinstance.Pass = dto.Pass;
                        newinstance.Id = dto.Id;
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
