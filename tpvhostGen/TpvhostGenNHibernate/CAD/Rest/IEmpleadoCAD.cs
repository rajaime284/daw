
using System;
using TpvhostGenNHibernate.EN.Rest;

namespace TpvhostGenNHibernate.CAD.Rest
{
public partial interface IEmpleadoCAD
{
EmpleadoEN ReadOIDDefault (int DNI
                           );

void ModifyDefault (EmpleadoEN empleado);

System.Collections.Generic.IList<EmpleadoEN> ReadAllDefault (int first, int size);



int Nuevo (EmpleadoEN empleado);

void Modificar (EmpleadoEN empleado);


void Eliminar (int DNI
               );


EmpleadoEN ReadOID (int DNI
                    );


System.Collections.Generic.IList<EmpleadoEN> ReadAll (int first, int size);
}
}
