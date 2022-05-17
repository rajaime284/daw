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
public static class NegocioAssembler
{
public static NegocioDTOA Convert (NegocioEN en, NHibernate.ISession session = null)
{
        NegocioDTOA dto = null;
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioCEN negocioCEN = null;
        NegocioCP negocioCP = null;

        if (en != null) {
                dto = new NegocioDTOA ();
                negocioRESTCAD = new NegocioRESTCAD (session);
                negocioCEN = new NegocioCEN (negocioRESTCAD);
                negocioCP = new NegocioCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Direccion = en.Direccion;


                dto.Ciudad = en.Ciudad;


                dto.Cp = en.Cp;


                dto.Provincia = en.Provincia;


                dto.Pais = en.Pais;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
