
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface ILineaMenuCAD
{
LineaMenuEN ReadOIDDefault (int id
                            );

void ModifyDefault (LineaMenuEN lineaMenu);

System.Collections.Generic.IList<LineaMenuEN> ReadAllDefault (int first, int size);



int Nuevo (LineaMenuEN lineaMenu);

void Modificar (LineaMenuEN lineaMenu);


void Eliminar (int id
               );


LineaMenuEN ReadOID (int id
                     );


System.Collections.Generic.IList<LineaMenuEN> ReadAll (int first, int size);
}
}
