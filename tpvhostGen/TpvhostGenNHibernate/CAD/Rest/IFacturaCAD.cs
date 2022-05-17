
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface IFacturaCAD
{
FacturaEN ReadOIDDefault (int id
                          );

void ModifyDefault (FacturaEN factura);

System.Collections.Generic.IList<FacturaEN> ReadAllDefault (int first, int size);



int Nuevo (FacturaEN factura);

void Modificar (FacturaEN factura);


void Eliminar (int id
               );




FacturaEN ReadOID (int id
                   );


System.Collections.Generic.IList<FacturaEN> ReadAll (int first, int size);
}
}
