
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface ITipoCobroCAD
{
TipoCobroEN ReadOIDDefault (int id
                            );

void ModifyDefault (TipoCobroEN tipoCobro);

System.Collections.Generic.IList<TipoCobroEN> ReadAllDefault (int first, int size);



int Nuevo (TipoCobroEN tipoCobro);

void Modificar (TipoCobroEN tipoCobro);


void Eliminar (int id
               );


TipoCobroEN ReadOID (int id
                     );


System.Collections.Generic.IList<TipoCobroEN> ReadAll (int first, int size);
}
}
