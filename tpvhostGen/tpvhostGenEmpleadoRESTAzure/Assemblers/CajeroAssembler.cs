using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using tpvhostGenEmpleadoRESTAzure.DTOA;
using tpvhostGenEmpleadoRESTAzure.CAD;
using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CEN.Rest;
using TpvhostGenNHibernate.CAD.Rest;
using TpvhostGenNHibernate.CP.Rest;

namespace tpvhostGenEmpleadoRESTAzure.Assemblers
{
public static class CajeroAssembler
{
public static CajeroDTOA Convert (CajeroEN en, NHibernate.ISession session = null)
{
        CajeroDTOA dto = null;
        CajeroRESTCAD cajeroRESTCAD = null;
        CajeroCEN cajeroCEN = null;
        CajeroCP cajeroCP = null;

        if (en != null) {
                dto = new CajeroDTOA ();
                cajeroRESTCAD = new CajeroRESTCAD (session);
                cajeroCEN = new CajeroCEN (cajeroRESTCAD);
                cajeroCP = new CajeroCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                //
                // TravesalLink

                /* Rol: Cajero o--> Caja */
                dto.Cajas = null;
                List<CajaEN> Cajas = cajeroRESTCAD.Cajas (en.Id).ToList ();
                if (Cajas != null) {
                        dto.Cajas = new List<CajaDTOA>();
                        foreach (CajaEN entry in Cajas)
                                dto.Cajas.Add (CajaAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
