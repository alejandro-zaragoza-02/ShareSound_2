
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using ShareSound_2GenNHibernate.EN.ShareSound_2;
using ShareSound_2GenNHibernate.CAD.ShareSound_2;
using ShareSound_2GenNHibernate.CEN.ShareSound_2;



/*PROTECTED REGION ID(usingShareSound_2GenNHibernate.CP.ShareSound_2_Cancion_ordenarPorMeGustas) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ShareSound_2GenNHibernate.CP.ShareSound_2
{
public partial class CancionCP : BasicCP
{
public System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> OrdenarPorMeGustas ()
{
        /*PROTECTED REGION ID(ShareSound_2GenNHibernate.CP.ShareSound_2_Cancion_ordenarPorMeGustas) ENABLED START*/

        ICancionCAD cancionCAD = null;
        CancionCEN cancionCEN = null;

        System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN>  result = null;


        try
        {
                SessionInitializeTransaction ();
                cancionCAD = new CancionCAD (session);
                cancionCEN = new  CancionCEN (cancionCAD);

                List<CancionEN> canciones = (List<CancionEN>)cancionCEN.ReadAll (0, -1);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method OrdenarPorMeGustas() not yet implemented.");



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
