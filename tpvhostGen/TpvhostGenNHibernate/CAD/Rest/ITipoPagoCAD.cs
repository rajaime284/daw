
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface ITipoPagoCAD
{
TipoPagoEN ReadOIDDefault (int id
                           );

void ModifyDefault (TipoPagoEN tipoPago);

System.Collections.Generic.IList<TipoPagoEN> ReadAllDefault (int first, int size);



int Nuevo (TipoPagoEN tipoPago);

void Modificar (TipoPagoEN tipoPago);


void Eliminar (int id
               );


TipoPagoEN ReadOID (int id
                    );


System.Collections.Generic.IList<TipoPagoEN> ReadAll (int first, int size);
}
}
