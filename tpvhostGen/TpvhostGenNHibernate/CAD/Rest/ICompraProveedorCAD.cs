
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface ICompraProveedorCAD
{
CompraProveedorEN ReadOIDDefault (int id
                                  );

void ModifyDefault (CompraProveedorEN compraProveedor);

System.Collections.Generic.IList<CompraProveedorEN> ReadAllDefault (int first, int size);



int Nuevo (CompraProveedorEN compraProveedor);

void Modificar (CompraProveedorEN compraProveedor);


void Eliminar (int id
               );


CompraProveedorEN ReadOID (int id
                           );


System.Collections.Generic.IList<CompraProveedorEN> ReadAll (int first, int size);
}
}
