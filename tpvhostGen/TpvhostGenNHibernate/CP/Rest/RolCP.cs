
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using TpvhostGenNHibernate.Exceptions;
using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CAD.Rest;
using TpvhostGenNHibernate.CEN.Rest;



namespace TpvhostGenNHibernate.CP.Rest
{
public partial class RolCP : BasicCP
{
public RolCP() : base ()
{
}

public RolCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
