
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface ICocineroCAD
{
CocineroEN ReadOIDDefault (int id
                           );

void ModifyDefault (CocineroEN cocinero);

System.Collections.Generic.IList<CocineroEN> ReadAllDefault (int first, int size);



int Nuevo (CocineroEN cocinero);

void Modificar (CocineroEN cocinero);


void Eliminar (int id
               );




CocineroEN ReadOID (int id
                    );


System.Collections.Generic.IList<CocineroEN> ReadAll (int first, int size);
}
}
