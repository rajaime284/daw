
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface ILineaCompraProveedorCAD
{
LineaCompraProveedorEN ReadOIDDefault (int id
                                       );

void ModifyDefault (LineaCompraProveedorEN lineaCompraProveedor);

System.Collections.Generic.IList<LineaCompraProveedorEN> ReadAllDefault (int first, int size);



int NuevaLineaServicio (LineaCompraProveedorEN lineaCompraProveedor);

void Modificar (LineaCompraProveedorEN lineaCompraProveedor);


void Eliminar (int id
               );


int NuevaLineaProducto (LineaCompraProveedorEN lineaCompraProveedor);

LineaCompraProveedorEN ReadOID (int id
                                );


System.Collections.Generic.IList<LineaCompraProveedorEN> ReadAll (int first, int size);
}
}
