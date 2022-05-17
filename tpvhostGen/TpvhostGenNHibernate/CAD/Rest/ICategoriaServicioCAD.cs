
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface ICategoriaServicioCAD
{
CategoriaServicioEN ReadOIDDefault (int id
                                    );

void ModifyDefault (CategoriaServicioEN categoriaServicio);

System.Collections.Generic.IList<CategoriaServicioEN> ReadAllDefault (int first, int size);



int Nuevo (CategoriaServicioEN categoriaServicio);

void Modificar (CategoriaServicioEN categoriaServicio);


void Eliminar (int id
               );


CategoriaServicioEN ReadOID (int id
                             );


System.Collections.Generic.IList<CategoriaServicioEN> ReadAll (int first, int size);
}
}
