
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface IEmpresaCAD
{
EmpresaEN ReadOIDDefault (int id
                          );

void ModifyDefault (EmpresaEN empresa);

System.Collections.Generic.IList<EmpresaEN> ReadAllDefault (int first, int size);



int Nuevo (EmpresaEN empresa);

void Modificar (EmpresaEN empresa);


void Eliminar (int id
               );


EmpresaEN ReadOID (int id
                   );


System.Collections.Generic.IList<EmpresaEN> ReadAll (int first, int size);
}
}
