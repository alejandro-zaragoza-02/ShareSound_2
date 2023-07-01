

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ShareSound_2GenNHibernate.Exceptions;

using ShareSound_2GenNHibernate.EN.ShareSound_2;
using ShareSound_2GenNHibernate.CAD.ShareSound_2;


namespace ShareSound_2GenNHibernate.CEN.ShareSound_2
{
/*
 *      Definition of the class PlaylistCEN
 *
 */
public partial class PlaylistCEN
{
private IPlaylistCAD _IPlaylistCAD;

public PlaylistCEN()
{
        this._IPlaylistCAD = new PlaylistCAD ();
}

public PlaylistCEN(IPlaylistCAD _IPlaylistCAD)
{
        this._IPlaylistCAD = _IPlaylistCAD;
}

public IPlaylistCAD get_IPlaylistCAD ()
{
        return this._IPlaylistCAD;
}

public int New_ (string p_titulo, string p_descripcion, string p_imagen, bool p_publico, Nullable<DateTime> p_fecha, int p_usuario)
{
        PlaylistEN playlistEN = null;
        int oid;

        //Initialized PlaylistEN
        playlistEN = new PlaylistEN ();
        playlistEN.Titulo = p_titulo;

        playlistEN.Descripcion = p_descripcion;

        playlistEN.Imagen = p_imagen;

        playlistEN.Publico = p_publico;

        playlistEN.Fecha = p_fecha;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                playlistEN.Usuario = new ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN ();
                playlistEN.Usuario.Id = p_usuario;
        }

        //Call to PlaylistCAD

        oid = _IPlaylistCAD.New_ (playlistEN);
        return oid;
}

public void Modify (int p_Playlist_OID, string p_titulo, string p_descripcion, string p_imagen, bool p_publico, Nullable<DateTime> p_fecha)
{
        PlaylistEN playlistEN = null;

        //Initialized PlaylistEN
        playlistEN = new PlaylistEN ();
        playlistEN.Id = p_Playlist_OID;
        playlistEN.Titulo = p_titulo;
        playlistEN.Descripcion = p_descripcion;
        playlistEN.Imagen = p_imagen;
        playlistEN.Publico = p_publico;
        playlistEN.Fecha = p_fecha;
        //Call to PlaylistCAD

        _IPlaylistCAD.Modify (playlistEN);
}

public void Destroy (int id
                     )
{
        _IPlaylistCAD.Destroy (id);
}

public PlaylistEN ReadOID (int id
                           )
{
        PlaylistEN playlistEN = null;

        playlistEN = _IPlaylistCAD.ReadOID (id);
        return playlistEN;
}

public System.Collections.Generic.IList<PlaylistEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PlaylistEN> list = null;

        list = _IPlaylistCAD.ReadAll (first, size);
        return list;
}
public void AnyadirCancion (int p_Playlist_OID, System.Collections.Generic.IList<int> p_canciones_OIDs)
{
        //Call to PlaylistCAD

        _IPlaylistCAD.AnyadirCancion (p_Playlist_OID, p_canciones_OIDs);
}
public void QuitarCancion (int p_Playlist_OID, System.Collections.Generic.IList<int> p_canciones_OIDs)
{
        //Call to PlaylistCAD

        _IPlaylistCAD.QuitarCancion (p_Playlist_OID, p_canciones_OIDs);
}
}
}
