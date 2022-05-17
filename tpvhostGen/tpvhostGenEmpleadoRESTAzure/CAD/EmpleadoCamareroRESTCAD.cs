
using System;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using System.Collections.Generic;

using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CAD.Rest;
using TpvhostGenNHibernate.CEN.Rest;

namespace tpvhostGenEmpleadoRESTAzure.CAD
{
public class EmpleadoCamareroRESTCAD : EmpleadoCAD
{
public EmpleadoCamareroRESTCAD()
        : base ()
{
}

public EmpleadoCamareroRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
