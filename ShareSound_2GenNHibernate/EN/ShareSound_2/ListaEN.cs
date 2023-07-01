
using System;
// Definición clase ListaEN
namespace ShareSound_2GenNHibernate.EN.ShareSound_2
{
public partial class ListaEN
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
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo publico
 */
private bool publico;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual bool Publico {
        get { return publico; } set { publico = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public ListaEN()
{
}



public ListaEN(int id, string titulo, string descripcion, string imagen, bool publico, Nullable<DateTime> fecha
               )
{
        this.init (Id, titulo, descripcion, imagen, publico, fecha);
}


public ListaEN(ListaEN lista)
{
        this.init (Id, lista.Titulo, lista.Descripcion, lista.Imagen, lista.Publico, lista.Fecha);
}

private void init (int id
                   , string titulo, string descripcion, string imagen, bool publico, Nullable<DateTime> fecha)
{
        this.Id = id;


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
        ListaEN t = obj as ListaEN;
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
