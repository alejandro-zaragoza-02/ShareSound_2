
using System;
using System.Text;
using ShareSound_2GenNHibernate.CEN.ShareSound_2;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ShareSound_2GenNHibernate.EN.ShareSound_2;
using ShareSound_2GenNHibernate.Exceptions;


/*
 * Clase Cancion:
 *
 */

namespace ShareSound_2GenNHibernate.CAD.ShareSound_2
{
public partial class CancionCAD : BasicCAD, ICancionCAD
{
public CancionCAD() : base ()
{
}

public CancionCAD(ISession sessionAux) : base (sessionAux)
{
}



public CancionEN ReadOIDDefault (int id
                                 )
{
        CancionEN cancionEN = null;

        try
        {
                SessionInitializeTransaction ();
                cancionEN = (CancionEN)session.Get (typeof(CancionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cancionEN;
}

public System.Collections.Generic.IList<CancionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CancionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CancionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CancionEN>();
                        else
                                result = session.CreateCriteria (typeof(CancionEN)).List<CancionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CancionEN cancion)
{
        try
        {
                SessionInitializeTransaction ();
                CancionEN cancionEN = (CancionEN)session.Load (typeof(CancionEN), cancion.Id);

                cancionEN.Titulo = cancion.Titulo;


                cancionEN.Fichero = cancion.Fichero;


                cancionEN.Duracion = cancion.Duracion;


                cancionEN.Reproducciones = cancion.Reproducciones;


                cancionEN.Fecha = cancion.Fecha;





                session.Update (cancionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CancionEN cancion)
{
        try
        {
                SessionInitializeTransaction ();
                if (cancion.Album != null) {
                        // Argumento OID y no colección.
                        cancion.Album = (ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN), cancion.Album.Id);

                        cancion.Album.Canciones
                        .Add (cancion);
                }

                session.Save (cancion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cancion.Id;
}

public void Modify (CancionEN cancion)
{
        try
        {
                SessionInitializeTransaction ();
                CancionEN cancionEN = (CancionEN)session.Load (typeof(CancionEN), cancion.Id);

                cancionEN.Titulo = cancion.Titulo;


                cancionEN.Fichero = cancion.Fichero;


                cancionEN.Duracion = cancion.Duracion;


                cancionEN.Reproducciones = cancion.Reproducciones;


                cancionEN.Fecha = cancion.Fecha;

                session.Update (cancionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                CancionEN cancionEN = (CancionEN)session.Load (typeof(CancionEN), id);
                session.Delete (cancionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CancionEN
public CancionEN ReadOID (int id
                          )
{
        CancionEN cancionEN = null;

        try
        {
                SessionInitializeTransaction ();
                cancionEN = (CancionEN)session.Get (typeof(CancionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cancionEN;
}

public System.Collections.Generic.IList<CancionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CancionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CancionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CancionEN>();
                else
                        result = session.CreateCriteria (typeof(CancionEN)).List<CancionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> BuscarPorTitulo (string titulo)
{
        System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CancionEN self where FROM CancionEN as can where can.Titulo LIKE :titulo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CancionENbuscarPorTituloHQL");
                query.SetParameter ("titulo", titulo);

                result = query.List<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> OrdenarPorReproducciones ()
{
        System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CancionEN self where FROM CancionEN as can ORDER BY can.Reproducciones DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CancionENordenarPorReproduccionesHQL");

                result = query.List<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> OrdenarPorTitulo ()
{
        System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CancionEN self where FROM CancionEN as canc order by canc.Reproducciones DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CancionENordenarPorTituloHQL");

                result = query.List<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void RecibirMeGusta (int p_Cancion_OID, System.Collections.Generic.IList<int> p_usuarios_gustados_OIDs)
{
        ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN cancionEN = null;
        try
        {
                SessionInitializeTransaction ();
                cancionEN = (CancionEN)session.Load (typeof(CancionEN), p_Cancion_OID);
                ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuarios_gustadosENAux = null;
                if (cancionEN.Usuarios_gustados == null) {
                        cancionEN.Usuarios_gustados = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN>();
                }

                foreach (int item in p_usuarios_gustados_OIDs) {
                        usuarios_gustadosENAux = new ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN ();
                        usuarios_gustadosENAux = (ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN), item);
                        usuarios_gustadosENAux.Canciones_gustadas.Add (cancionEN);

                        cancionEN.Usuarios_gustados.Add (usuarios_gustadosENAux);
                }


                session.Update (cancionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarMeGusta (int p_Cancion_OID, System.Collections.Generic.IList<int> p_usuarios_gustados_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN cancionEN = null;
                cancionEN = (CancionEN)session.Load (typeof(CancionEN), p_Cancion_OID);

                ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuarios_gustadosENAux = null;
                if (cancionEN.Usuarios_gustados != null) {
                        foreach (int item in p_usuarios_gustados_OIDs) {
                                usuarios_gustadosENAux = (ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN), item);
                                if (cancionEN.Usuarios_gustados.Contains (usuarios_gustadosENAux) == true) {
                                        cancionEN.Usuarios_gustados.Remove (usuarios_gustadosENAux);
                                        usuarios_gustadosENAux.Canciones_gustadas.Remove (cancionEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuarios_gustados_OIDs you are trying to unrelationer, doesn't exist in CancionEN");
                        }
                }

                session.Update (cancionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in CancionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
