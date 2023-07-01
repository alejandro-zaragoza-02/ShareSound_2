

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
 *      Definition of the class AlbumCEN
 *
 */
public partial class AlbumCEN
{
private IAlbumCAD _IAlbumCAD;

public AlbumCEN()
{
        this._IAlbumCAD = new AlbumCAD ();
}

public AlbumCEN(IAlbumCAD _IAlbumCAD)
{
        this._IAlbumCAD = _IAlbumCAD;
}

public IAlbumCAD get_IAlbumCAD ()
{
        return this._IAlbumCAD;
}

public int New_ (string p_titulo, string p_descripcion, string p_imagen, bool p_publico, Nullable<DateTime> p_fecha, int p_usuario)
{
        AlbumEN albumEN = null;
        int oid;

        //Initialized AlbumEN
        albumEN = new AlbumEN ();
        albumEN.Titulo = p_titulo;

        albumEN.Descripcion = p_descripcion;

        albumEN.Imagen = p_imagen;

        albumEN.Publico = p_publico;

        albumEN.Fecha = p_fecha;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                albumEN.Usuario = new ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN ();
                albumEN.Usuario.Id = p_usuario;
        }

        //Call to AlbumCAD

        oid = _IAlbumCAD.New_ (albumEN);
        return oid;
}

public void Modify (int p_Album_OID, string p_titulo, string p_descripcion, string p_imagen, bool p_publico, Nullable<DateTime> p_fecha)
{
        AlbumEN albumEN = null;

        //Initialized AlbumEN
        albumEN = new AlbumEN ();
        albumEN.Id = p_Album_OID;
        albumEN.Titulo = p_titulo;
        albumEN.Descripcion = p_descripcion;
        albumEN.Imagen = p_imagen;
        albumEN.Publico = p_publico;
        albumEN.Fecha = p_fecha;
        //Call to AlbumCAD

        _IAlbumCAD.Modify (albumEN);
}

public void Destroy (int id
                     )
{
        _IAlbumCAD.Destroy (id);
}

public AlbumEN ReadOID (int id
                        )
{
        AlbumEN albumEN = null;

        albumEN = _IAlbumCAD.ReadOID (id);
        return albumEN;
}

public System.Collections.Generic.IList<AlbumEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AlbumEN> list = null;

        list = _IAlbumCAD.ReadAll (first, size);
        return list;
}
}
}
