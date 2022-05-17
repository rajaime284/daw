using System;
using System.Collections.Generic;
using TpvhostGenNHibernate.EN.Rest;
using tpvhostGenTpvhostRESTAzure.DTO;

namespace tpvhostGenTpvhostRESTAzure.AssemblersDTO
{
public class EmpleadoAssemblerDTO {
public static IList<EmpleadoEN> ConvertList (IList<EmpleadoDTO> lista)
{
        IList<EmpleadoEN> result = new List<EmpleadoEN>();
        foreach (EmpleadoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static EmpleadoEN Convert (EmpleadoDTO dto)
{
        EmpleadoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new EmpleadoEN ();



                        if (dto.Rol_oid != null) {
                                TpvhostGenNHibernate.CAD.Rest.IRolCAD rolCAD = new TpvhostGenNHibernate.CAD.Rest.RolCAD ();

                                newinstance.Rol = new System.Collections.Generic.List<TpvhostGenNHibernate.EN.Rest.RolEN>();
                                foreach (int entry in dto.Rol_oid) {
                                        newinstance.Rol.Add (rolCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Negocio_oid != -1) {
                                TpvhostGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TpvhostGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = negocioCAD.ReadOIDDefault (dto.Negocio_oid);
                        }
                        newinstance.DNI = dto.DNI;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Apellidos = dto.Apellidos;
                        newinstance.Pass = dto.Pass;
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
