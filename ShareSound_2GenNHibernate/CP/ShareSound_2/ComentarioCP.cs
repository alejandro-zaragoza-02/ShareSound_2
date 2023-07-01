
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using ShareSound_2GenNHibernate.Exceptions;
using ShareSound_2GenNHibernate.EN.ShareSound_2;
using ShareSound_2GenNHibernate.CAD.ShareSound_2;
using ShareSound_2GenNHibernate.CEN.ShareSound_2;



namespace ShareSound_2GenNHibernate.CP.ShareSound_2
{
public partial class ComentarioCP : BasicCP
{
public ComentarioCP() : base ()
{
}

public ComentarioCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
