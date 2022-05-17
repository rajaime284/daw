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
public static class ProductoAssembler
{
public static ProductoDTOA Convert (ProductoEN en, NHibernate.ISession session = null)
{
        ProductoDTOA dto = null;
        ProductoRESTCAD productoRESTCAD = null;
        ProductoCEN productoCEN = null;
        ProductoCP productoCP = null;

        if (en != null) {
                dto = new ProductoDTOA ();
                productoRESTCAD = new ProductoRESTCAD (session);
                productoCEN = new ProductoCEN (productoRESTCAD);
                productoCP = new ProductoCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Stock = en.Stock;


                dto.Descripcion = en.Descripcion;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
