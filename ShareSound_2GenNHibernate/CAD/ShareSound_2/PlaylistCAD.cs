
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
 * Clase Playlist:
 *
 */

namespace ShareSound_2GenNHibernate.CAD.ShareSound_2
{
public partial class PlaylistCAD : BasicCAD, IPlaylistCAD
{
public PlaylistCAD() : base ()
{
}

public PlaylistCAD(ISession sessionAux) : base (sessionAux)
{
}



public PlaylistEN ReadOIDDefault (int id
                                  )
{
        PlaylistEN playlistEN = null;

        try
        {
                SessionInitializeTransaction ();
                playlistEN = (PlaylistEN)session.Get (typeof(PlaylistEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in PlaylistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return playlistEN;
}

public System.Collections.Generic.IList<PlaylistEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PlaylistEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PlaylistEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PlaylistEN>();
                        else
                                result = session.CreateCriteria (typeof(PlaylistEN)).List<PlaylistEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in PlaylistCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PlaylistEN playlist)
{
        try
        {
                SessionInitializeTransaction ();
                PlaylistEN playlistEN = (PlaylistEN)session.Load (typeof(PlaylistEN), playlist.Id);



                session.Update (playlistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in PlaylistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PlaylistEN playlist)
{
        try
        {
                SessionInitializeTransaction ();
                if (playlist.Usuario != null) {
                        // Argumento OID y no colección.
                        playlist.Usuario = (ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN), playlist.Usuario.Id);

                        playlist.Usuario.Playlists_creadas
                        .Add (playlist);
                }

                session.Save (playlist);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in PlaylistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return playlist.Id;
}

public void Modify (PlaylistEN playlist)
{
        try
        {
                SessionInitializeTransaction ();
                PlaylistEN playlistEN = (PlaylistEN)session.Load (typeof(PlaylistEN), playlist.Id);

                playlistEN.Titulo = playlist.Titulo;


                playlistEN.Descripcion = playlist.Descripcion;


                playlistEN.Imagen = playlist.Imagen;


                playlistEN.Publico = playlist.Publico;


                playlistEN.Fecha = playlist.Fecha;

                session.Update (playlistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in PlaylistCAD.", ex);
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
                PlaylistEN playlistEN = (PlaylistEN)session.Load (typeof(PlaylistEN), id);
                session.Delete (playlistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in PlaylistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PlaylistEN
public PlaylistEN ReadOID (int id
                           )
{
        PlaylistEN playlistEN = null;

        try
        {
                SessionInitializeTransaction ();
                playlistEN = (PlaylistEN)session.Get (typeof(PlaylistEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in PlaylistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return playlistEN;
}

public System.Collections.Generic.IList<PlaylistEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PlaylistEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PlaylistEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PlaylistEN>();
                else
                        result = session.CreateCriteria (typeof(PlaylistEN)).List<PlaylistEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in PlaylistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AnyadirCancion (int p_Playlist_OID, System.Collections.Generic.IList<int> p_canciones_OIDs)
{
        ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN playlistEN = null;
        try
        {
                SessionInitializeTransaction ();
                playlistEN = (PlaylistEN)session.Load (typeof(PlaylistEN), p_Playlist_OID);
                ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN cancionesENAux = null;
                if (playlistEN.Canciones == null) {
                        playlistEN.Canciones = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN>();
                }

                foreach (int item in p_canciones_OIDs) {
                        cancionesENAux = new ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN ();
                        cancionesENAux = (ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN), item);
                        cancionesENAux.Playlists.Add (playlistEN);

                        playlistEN.Canciones.Add (cancionesENAux);
                }


                session.Update (playlistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in PlaylistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarCancion (int p_Playlist_OID, System.Collections.Generic.IList<int> p_canciones_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN playlistEN = null;
                playlistEN = (PlaylistEN)session.Load (typeof(PlaylistEN), p_Playlist_OID);

                ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN cancionesENAux = null;
                if (playlistEN.Canciones != null) {
                        foreach (int item in p_canciones_OIDs) {
                                cancionesENAux = (ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN), item);
                                if (playlistEN.Canciones.Contains (cancionesENAux) == true) {
                                        playlistEN.Canciones.Remove (cancionesENAux);
                                        cancionesENAux.Playlists.Remove (playlistEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_canciones_OIDs you are trying to unrelationer, doesn't exist in PlaylistEN");
                        }
                }

                session.Update (playlistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in PlaylistCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
