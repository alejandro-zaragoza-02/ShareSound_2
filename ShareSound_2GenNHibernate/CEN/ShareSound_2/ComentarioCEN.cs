

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
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioCAD _IComentarioCAD;

public ComentarioCEN()
{
        this._IComentarioCAD = new ComentarioCAD ();
}

public ComentarioCEN(IComentarioCAD _IComentarioCAD)
{
        this._IComentarioCAD = _IComentarioCAD;
}

public IComentarioCAD get_IComentarioCAD ()
{
        return this._IComentarioCAD;
}

public int New_ (string p_contenido, Nullable<DateTime> p_fecha, int p_cancion, int p_usuario)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Contenido = p_contenido;

        comentarioEN.Fecha = p_fecha;


        if (p_cancion != -1) {
                // El argumento p_cancion -> Property cancion es oid = false
                // Lista de oids id
                comentarioEN.Cancion = new ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN ();
                comentarioEN.Cancion.Id = p_cancion;
        }


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                comentarioEN.Usuario = new ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN ();
                comentarioEN.Usuario.Id = p_usuario;
        }

        //Call to ComentarioCAD

        oid = _IComentarioCAD.New_ (comentarioEN);
        return oid;
}

public void Modify (int p_Comentario_OID, string p_contenido, Nullable<DateTime> p_fecha)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_Comentario_OID;
        comentarioEN.Contenido = p_contenido;
        comentarioEN.Fecha = p_fecha;
        //Call to ComentarioCAD

        _IComentarioCAD.Modify (comentarioEN);
}

public void Destroy (int id
                     )
{
        _IComentarioCAD.Destroy (id);
}

public ComentarioEN ReadOID (int id
                             )
{
        ComentarioEN comentarioEN = null;

        comentarioEN = _IComentarioCAD.ReadOID (id);
        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> list = null;

        list = _IComentarioCAD.ReadAll (first, size);
        return list;
}
}
}
