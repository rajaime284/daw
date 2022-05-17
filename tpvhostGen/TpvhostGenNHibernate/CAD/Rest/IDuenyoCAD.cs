
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface IDuenyoCAD
{
DuenyoEN ReadOIDDefault (int id
                         );

void ModifyDefault (DuenyoEN duenyo);

System.Collections.Generic.IList<DuenyoEN> ReadAllDefault (int first, int size);



int Nuevo (DuenyoEN duenyo);

void Modificar (DuenyoEN duenyo);


void Eliminar (int id
               );



DuenyoEN ReadOID (int id
                  );


System.Collections.Generic.IList<DuenyoEN> ReadAll (int first, int size);
}
}
