
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface ILineaPlatoCAD
{
LineaPlatoEN ReadOIDDefault (int id
                             );

void ModifyDefault (LineaPlatoEN lineaPlato);

System.Collections.Generic.IList<LineaPlatoEN> ReadAllDefault (int first, int size);



int Nuevo (LineaPlatoEN lineaPlato);

void Modificar (LineaPlatoEN lineaPlato);


void Eliminar (int id
               );


LineaPlatoEN ReadOID (int id
                      );


System.Collections.Generic.IList<LineaPlatoEN> ReadAll (int first, int size);
}
}
