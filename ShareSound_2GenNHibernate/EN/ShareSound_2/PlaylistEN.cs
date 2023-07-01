
using System;
// Definición clase PlaylistEN
namespace ShareSound_2GenNHibernate.EN.ShareSound_2
{
public partial class PlaylistEN                                                                     : ShareSound_2GenNHibernate.EN.ShareSound_2.ListaEN


{
/**
 *	Atributo usuario
 */
private ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuario;



/**
 *	Atributo seguidores
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> seguidores;



/**
 *	Atributo canciones
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> canciones;






public virtual ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> Seguidores {
        get { return seguidores; } set { seguidores = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> Canciones {
        get { return canciones; } set { canciones = value;  }
}





public PlaylistEN() : base ()
{
        seguidores = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN>();
        canciones = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN>();
}



public PlaylistEN(int id, ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuario, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> seguidores, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> canciones
                  , string titulo, string descripcion, string imagen, bool publico, Nullable<DateTime> fecha
                  )
{
        this.init (Id, usuario, seguidores, canciones, titulo, descripcion, imagen, publico, fecha);
}


public PlaylistEN(PlaylistEN playlist)
{
        this.init (Id, playlist.Usuario, playlist.Seguidores, playlist.Canciones, playlist.Titulo, playlist.Descripcion, playlist.Imagen, playlist.Publico, playlist.Fecha);
}

private void init (int id
                   , ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuario, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> seguidores, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> canciones, string titulo, string descripcion, string imagen, bool publico, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Seguidores = seguidores;

        this.Canciones = canciones;

        this.Titulo = titulo;

        this.Descripcion = descripcion;

        this.Imagen = imagen;

        this.Publico = publico;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PlaylistEN t = obj as PlaylistEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
