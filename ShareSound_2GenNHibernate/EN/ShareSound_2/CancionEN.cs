
using System;
// Definición clase CancionEN
namespace ShareSound_2GenNHibernate.EN.ShareSound_2
{
public partial class CancionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo fichero
 */
private string fichero;



/**
 *	Atributo duracion
 */
private int duracion;



/**
 *	Atributo reproducciones
 */
private int reproducciones;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo usuarios_gustados
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> usuarios_gustados;



/**
 *	Atributo album
 */
private ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN album;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.ComentarioEN> comentarios;



/**
 *	Atributo playlists
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> playlists;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Fichero {
        get { return fichero; } set { fichero = value;  }
}



public virtual int Duracion {
        get { return duracion; } set { duracion = value;  }
}



public virtual int Reproducciones {
        get { return reproducciones; } set { reproducciones = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> Usuarios_gustados {
        get { return usuarios_gustados; } set { usuarios_gustados = value;  }
}



public virtual ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN Album {
        get { return album; } set { album = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.ComentarioEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> Playlists {
        get { return playlists; } set { playlists = value;  }
}





public CancionEN()
{
        usuarios_gustados = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN>();
        comentarios = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.ComentarioEN>();
        playlists = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN>();
}



public CancionEN(int id, string titulo, string fichero, int duracion, int reproducciones, Nullable<DateTime> fecha, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> usuarios_gustados, ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN album, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.ComentarioEN> comentarios, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> playlists
                 )
{
        this.init (Id, titulo, fichero, duracion, reproducciones, fecha, usuarios_gustados, album, comentarios, playlists);
}


public CancionEN(CancionEN cancion)
{
        this.init (Id, cancion.Titulo, cancion.Fichero, cancion.Duracion, cancion.Reproducciones, cancion.Fecha, cancion.Usuarios_gustados, cancion.Album, cancion.Comentarios, cancion.Playlists);
}

private void init (int id
                   , string titulo, string fichero, int duracion, int reproducciones, Nullable<DateTime> fecha, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> usuarios_gustados, ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN album, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.ComentarioEN> comentarios, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> playlists)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Fichero = fichero;

        this.Duracion = duracion;

        this.Reproducciones = reproducciones;

        this.Fecha = fecha;

        this.Usuarios_gustados = usuarios_gustados;

        this.Album = album;

        this.Comentarios = comentarios;

        this.Playlists = playlists;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CancionEN t = obj as CancionEN;
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
