
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface IMenuCAD
{
MenuEN ReadOIDDefault (int id
                       );

void ModifyDefault (MenuEN menu);

System.Collections.Generic.IList<MenuEN> ReadAllDefault (int first, int size);



int Nuevo (MenuEN menu);

void Modificar (MenuEN menu);


void Eliminar (int id
               );




MenuEN ReadOID (int id
                );


System.Collections.Generic.IList<MenuEN> ReadAll (int first, int size);
}
}
