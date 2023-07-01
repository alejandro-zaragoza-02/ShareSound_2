
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
 * Clase Usuario:
 *
 */

namespace ShareSound_2GenNHibernate.CAD.ShareSound_2
{
public partial class UsuarioCAD : BasicCAD, IUsuarioCAD
{
public UsuarioCAD() : base ()
{
}

public UsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioEN ReadOIDDefault (int id
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Id);

                usuarioEN.Pass = usuario.Pass;


                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Descripcion = usuario.Descripcion;


                usuarioEN.Imagen = usuario.Imagen;


                usuarioEN.Email = usuario.Email;


                usuarioEN.Fecha = usuario.Fecha;









                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario.Id;
}

public void Modify (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Id);

                usuarioEN.Pass = usuario.Pass;


                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Descripcion = usuario.Descripcion;


                usuarioEN.Imagen = usuario.Imagen;


                usuarioEN.Email = usuario.Email;


                usuarioEN.Fecha = usuario.Fecha;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
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
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), id);
                session.Delete (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: UsuarioEN
public UsuarioEN ReadOID (int id
                          )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void SeguirUsuario (int p_Usuario_OID, System.Collections.Generic.IList<int> p_seguidos_OIDs)
{
        ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN seguidosENAux = null;
                if (usuarioEN.Seguidos == null) {
                        usuarioEN.Seguidos = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN>();
                }

                foreach (int item in p_seguidos_OIDs) {
                        seguidosENAux = new ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN ();
                        seguidosENAux = (ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN), item);
                        seguidosENAux.Seguidores.Add (usuarioEN);

                        usuarioEN.Seguidos.Add (seguidosENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DejarSeguirUsuario (int p_Usuario_OID, System.Collections.Generic.IList<int> p_seguidos_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN seguidosENAux = null;
                if (usuarioEN.Seguidos != null) {
                        foreach (int item in p_seguidos_OIDs) {
                                seguidosENAux = (ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN), item);
                                if (usuarioEN.Seguidos.Contains (seguidosENAux) == true) {
                                        usuarioEN.Seguidos.Remove (seguidosENAux);
                                        seguidosENAux.Seguidores.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_seguidos_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void SeguirPlaylist (int p_Usuario_OID, System.Collections.Generic.IList<int> p_playlists_seguidas_OIDs)
{
        ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN playlists_seguidasENAux = null;
                if (usuarioEN.Playlists_seguidas == null) {
                        usuarioEN.Playlists_seguidas = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN>();
                }

                foreach (int item in p_playlists_seguidas_OIDs) {
                        playlists_seguidasENAux = new ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN ();
                        playlists_seguidasENAux = (ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN), item);
                        playlists_seguidasENAux.Seguidores.Add (usuarioEN);

                        usuarioEN.Playlists_seguidas.Add (playlists_seguidasENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DejarSeguirPlaylist (int p_Usuario_OID, System.Collections.Generic.IList<int> p_playlists_seguidas_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN playlists_seguidasENAux = null;
                if (usuarioEN.Playlists_seguidas != null) {
                        foreach (int item in p_playlists_seguidas_OIDs) {
                                playlists_seguidasENAux = (ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN), item);
                                if (usuarioEN.Playlists_seguidas.Contains (playlists_seguidasENAux) == true) {
                                        usuarioEN.Playlists_seguidas.Remove (playlists_seguidasENAux);
                                        playlists_seguidasENAux.Seguidores.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_playlists_seguidas_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void SeguirAlbum (int p_Usuario_OID, System.Collections.Generic.IList<int> p_albums_seguidos_OIDs)
{
        ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN albums_seguidosENAux = null;
                if (usuarioEN.Albums_seguidos == null) {
                        usuarioEN.Albums_seguidos = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN>();
                }

                foreach (int item in p_albums_seguidos_OIDs) {
                        albums_seguidosENAux = new ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN ();
                        albums_seguidosENAux = (ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN), item);
                        albums_seguidosENAux.Seguidores.Add (usuarioEN);

                        usuarioEN.Albums_seguidos.Add (albums_seguidosENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DejarSeguirAlbum (int p_Usuario_OID, System.Collections.Generic.IList<int> p_albums_seguidos_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN albums_seguidosENAux = null;
                if (usuarioEN.Albums_seguidos != null) {
                        foreach (int item in p_albums_seguidos_OIDs) {
                                albums_seguidosENAux = (ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN), item);
                                if (usuarioEN.Albums_seguidos.Contains (albums_seguidosENAux) == true) {
                                        usuarioEN.Albums_seguidos.Remove (albums_seguidosENAux);
                                        albums_seguidosENAux.Seguidores.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_albums_seguidos_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> DameUsuarioPorEmail (string email)
{
        System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorEmailHQL");
                query.SetParameter ("email", email);

                result = query.List<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
