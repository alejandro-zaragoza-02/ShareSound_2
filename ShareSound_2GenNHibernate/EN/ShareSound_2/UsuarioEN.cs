
using System;
// Definición clase UsuarioEN
namespace ShareSound_2GenNHibernate.EN.ShareSound_2
{
public partial class UsuarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo playlists_creadas
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> playlists_creadas;



/**
 *	Atributo playlists_seguidas
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> playlists_seguidas;



/**
 *	Atributo albums_creados
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN> albums_creados;



/**
 *	Atributo albums_seguidos
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN> albums_seguidos;



/**
 *	Atributo canciones_gustadas
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> canciones_gustadas;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.ComentarioEN> comentarios;



/**
 *	Atributo seguidos
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> seguidos;



/**
 *	Atributo seguidores
 */
private System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> seguidores;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> Playlists_creadas {
        get { return playlists_creadas; } set { playlists_creadas = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> Playlists_seguidas {
        get { return playlists_seguidas; } set { playlists_seguidas = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN> Albums_creados {
        get { return albums_creados; } set { albums_creados = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN> Albums_seguidos {
        get { return albums_seguidos; } set { albums_seguidos = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> Canciones_gustadas {
        get { return canciones_gustadas; } set { canciones_gustadas = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.ComentarioEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> Seguidos {
        get { return seguidos; } set { seguidos = value;  }
}



public virtual System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> Seguidores {
        get { return seguidores; } set { seguidores = value;  }
}





public UsuarioEN()
{
        playlists_creadas = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN>();
        playlists_seguidas = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN>();
        albums_creados = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN>();
        albums_seguidos = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN>();
        canciones_gustadas = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN>();
        comentarios = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.ComentarioEN>();
        seguidos = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN>();
        seguidores = new System.Collections.Generic.List<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN>();
}



public UsuarioEN(int id, String pass, string nombre, string descripcion, string imagen, string email, Nullable<DateTime> fecha, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> playlists_creadas, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> playlists_seguidas, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN> albums_creados, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN> albums_seguidos, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> canciones_gustadas, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.ComentarioEN> comentarios, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> seguidos, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> seguidores
                 )
{
        this.init (Id, pass, nombre, descripcion, imagen, email, fecha, playlists_creadas, playlists_seguidas, albums_creados, albums_seguidos, canciones_gustadas, comentarios, seguidos, seguidores);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Id, usuario.Pass, usuario.Nombre, usuario.Descripcion, usuario.Imagen, usuario.Email, usuario.Fecha, usuario.Playlists_creadas, usuario.Playlists_seguidas, usuario.Albums_creados, usuario.Albums_seguidos, usuario.Canciones_gustadas, usuario.Comentarios, usuario.Seguidos, usuario.Seguidores);
}

private void init (int id
                   , String pass, string nombre, string descripcion, string imagen, string email, Nullable<DateTime> fecha, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> playlists_creadas, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> playlists_seguidas, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN> albums_creados, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN> albums_seguidos, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> canciones_gustadas, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.ComentarioEN> comentarios, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> seguidos, System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> seguidores)
{
        this.Id = id;


        this.Pass = pass;

        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Imagen = imagen;

        this.Email = email;

        this.Fecha = fecha;

        this.Playlists_creadas = playlists_creadas;

        this.Playlists_seguidas = playlists_seguidas;

        this.Albums_creados = albums_creados;

        this.Albums_seguidos = albums_seguidos;

        this.Canciones_gustadas = canciones_gustadas;

        this.Comentarios = comentarios;

        this.Seguidos = seguidos;

        this.Seguidores = seguidores;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
