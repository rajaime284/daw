
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface ICajaCAD
{
CajaEN ReadOIDDefault (int id
                       );

void ModifyDefault (CajaEN caja);

System.Collections.Generic.IList<CajaEN> ReadAllDefault (int first, int size);



int Nuevo (CajaEN caja);

void Modificar (CajaEN caja);


void Eliminar (int id
               );




CajaEN ReadOID (int id
                );


System.Collections.Generic.IList<CajaEN> ReadAll (int first, int size);
}
}
