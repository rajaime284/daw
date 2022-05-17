using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using tpvhostGenTpvhostRESTAzure.DTOA;
using tpvhostGenTpvhostRESTAzure.CAD;
using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CEN.Rest;
using TpvhostGenNHibernate.CAD.Rest;
using TpvhostGenNHibernate.CP.Rest;

namespace tpvhostGenTpvhostRESTAzure.Assemblers
{
public static class ClienteAssembler
{
public static ClienteDTOA Convert (ClienteEN en, NHibernate.ISession session = null)
{
        ClienteDTOA dto = null;
        ClienteRESTCAD clienteRESTCAD = null;
        ClienteCEN clienteCEN = null;
        ClienteCP clienteCP = null;

        if (en != null) {
                dto = new ClienteDTOA ();
                clienteRESTCAD = new ClienteRESTCAD (session);
                clienteCEN = new ClienteCEN (clienteRESTCAD);
                clienteCP = new ClienteCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Apellidos = en.Apellidos;


                dto.Dni = en.Dni;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
