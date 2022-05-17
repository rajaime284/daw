
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface ICajeroCAD
{
CajeroEN ReadOIDDefault (int id
                         );

void ModifyDefault (CajeroEN cajero);

System.Collections.Generic.IList<CajeroEN> ReadAllDefault (int first, int size);



int Nuevo (CajeroEN cajero);

void Modificar (CajeroEN cajero);


void Eliminar (int id
               );




CajeroEN ReadOID (int id
                  );


System.Collections.Generic.IList<CajeroEN> ReadAll (int first, int size);
}
}
