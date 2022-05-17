
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface IProveedorCAD
{
ProveedorEN ReadOIDDefault (int id
                            );

void ModifyDefault (ProveedorEN proveedor);

System.Collections.Generic.IList<ProveedorEN> ReadAllDefault (int first, int size);



int Nuevo (ProveedorEN proveedor);

void Modificar (ProveedorEN proveedor);


void Eliminar (int id
               );


ProveedorEN ReadOID (int id
                     );


System.Collections.Generic.IList<ProveedorEN> ReadAll (int first, int size);
}
}
