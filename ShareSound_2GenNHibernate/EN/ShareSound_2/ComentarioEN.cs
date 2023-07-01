
using System;
// Definición clase ComentarioEN
namespace ShareSound_2GenNHibernate.EN.ShareSound_2
{
public partial class ComentarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo cancion
 */
private ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN cancion;



/**
 *	Atributo usuario
 */
private ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN Cancion {
        get { return cancion; } set { cancion = value;  }
}



public virtual ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ComentarioEN()
{
}



public ComentarioEN(int id, string contenido, Nullable<DateTime> fecha, ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN cancion, ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuario
                    )
{
        this.init (Id, contenido, fecha, cancion, usuario);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (Id, comentario.Contenido, comentario.Fecha, comentario.Cancion, comentario.Usuario);
}

private void init (int id
                   , string contenido, Nullable<DateTime> fecha, ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN cancion, ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN usuario)
{
        this.Id = id;


        this.Contenido = contenido;

        this.Fecha = fecha;

        this.Cancion = cancion;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
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
