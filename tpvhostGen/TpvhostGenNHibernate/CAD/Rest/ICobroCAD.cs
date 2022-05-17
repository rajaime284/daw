
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface ICobroCAD
{
CobroEN ReadOIDDefault (int id
                        );

void ModifyDefault (CobroEN cobro);

System.Collections.Generic.IList<CobroEN> ReadAllDefault (int first, int size);



int Nuevo (CobroEN cobro);

void Modificar (CobroEN cobro);


void Eliminar (int id
               );


CobroEN ReadOID (int id
                 );


System.Collections.Generic.IList<CobroEN> ReadAll (int first, int size);
}
}
