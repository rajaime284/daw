
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface IUnidadMedidaCAD
{
UnidadMedidaEN ReadOIDDefault (int id
                               );

void ModifyDefault (UnidadMedidaEN unidadMedida);

System.Collections.Generic.IList<UnidadMedidaEN> ReadAllDefault (int first, int size);



int Nuevo (UnidadMedidaEN unidadMedida);

void Modificar (UnidadMedidaEN unidadMedida);


void Eliminar (int id
               );


UnidadMedidaEN ReadOID (int id
                        );


System.Collections.Generic.IList<UnidadMedidaEN> ReadAll (int first, int size);
}
}
