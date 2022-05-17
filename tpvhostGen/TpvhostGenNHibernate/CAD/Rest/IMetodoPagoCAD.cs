
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface IMetodoPagoCAD
{
MetodoPagoEN ReadOIDDefault (int id
                             );

void ModifyDefault (MetodoPagoEN metodoPago);

System.Collections.Generic.IList<MetodoPagoEN> ReadAllDefault (int first, int size);



int Nuevo (MetodoPagoEN metodoPago);

void Modificar (MetodoPagoEN metodoPago);


void Eliminar (int id
               );
}
}
