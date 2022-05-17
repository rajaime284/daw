
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface IClienteCAD
{
ClienteEN ReadOIDDefault (int id
                          );

void ModifyDefault (ClienteEN cliente);

System.Collections.Generic.IList<ClienteEN> ReadAllDefault (int first, int size);



int Nuevo (ClienteEN cliente);

void Modificar (ClienteEN cliente);


void Eliminar (int id
               );


ClienteEN ReadOID (int id
                   );


System.Collections.Generic.IList<ClienteEN> ReadAll (int first, int size);
}
}
