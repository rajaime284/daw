
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

namespace tpvhostGenTpvhostRESTAzure.CAD
{
public class LineaPlatoRESTCAD : LineaPlatoCAD
{
public LineaPlatoRESTCAD()
        : base ()
{
}

public LineaPlatoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
