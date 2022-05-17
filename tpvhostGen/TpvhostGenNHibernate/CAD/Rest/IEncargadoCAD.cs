
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface IEncargadoCAD
{
EncargadoEN ReadOIDDefault (int id
                            );

void ModifyDefault (EncargadoEN encargado);

System.Collections.Generic.IList<EncargadoEN> ReadAllDefault (int first, int size);



int Nuevo (EncargadoEN encargado);

void Modificar (EncargadoEN encargado);


void Eliminar (int id
               );


EncargadoEN ReadOID (int id
                     );


System.Collections.Generic.IList<EncargadoEN> ReadAll (int first, int size);
}
}
