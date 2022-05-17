
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface IPagoCAD
{
PagoEN ReadOIDDefault (int id
                       );

void ModifyDefault (PagoEN pago);

System.Collections.Generic.IList<PagoEN> ReadAllDefault (int first, int size);



int Nuevo (PagoEN pago);

void Modificar (PagoEN pago);


void Eliminar (int id
               );
}
}
