
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface INegocioCAD
{
NegocioEN ReadOIDDefault (int id
                          );

void ModifyDefault (NegocioEN negocio);

System.Collections.Generic.IList<NegocioEN> ReadAllDefault (int first, int size);



int Nuevo (NegocioEN negocio);

void Modificar (NegocioEN negocio);


void Eliminar (int id
               );


NegocioEN ReadOID (int id
                   );


System.Collections.Generic.IList<NegocioEN> ReadAll (int first, int size);
}
}
