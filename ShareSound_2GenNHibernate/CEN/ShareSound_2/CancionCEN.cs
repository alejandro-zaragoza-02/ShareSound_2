

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
 *      Definition of the class CancionCEN
 *
 */
public partial class CancionCEN
{
private ICancionCAD _ICancionCAD;

public CancionCEN()
{
        this._ICancionCAD = new CancionCAD ();
}

public CancionCEN(ICancionCAD _ICancionCAD)
{
        this._ICancionCAD = _ICancionCAD;
}

public ICancionCAD get_ICancionCAD ()
{
        return this._ICancionCAD;
}

public int New_ (string p_titulo, string p_fichero, int p_duracion, int p_reproducciones, Nullable<DateTime> p_fecha, int p_album)
{
        CancionEN cancionEN = null;
        int oid;

        //Initialized CancionEN
        cancionEN = new CancionEN ();
        cancionEN.Titulo = p_titulo;

        cancionEN.Fichero = p_fichero;

        cancionEN.Duracion = p_duracion;

        cancionEN.Reproducciones = p_reproducciones;

        cancionEN.Fecha = p_fecha;


        if (p_album != -1) {
                // El argumento p_album -> Property album es oid = false
                // Lista de oids id
                cancionEN.Album = new ShareSound_2GenNHibernate.EN.ShareSound_2.AlbumEN ();
                cancionEN.Album.Id = p_album;
        }

        //Call to CancionCAD

        oid = _ICancionCAD.New_ (cancionEN);
        return oid;
}

public void Modify (int p_Cancion_OID, string p_titulo, string p_fichero, int p_duracion, int p_reproducciones, Nullable<DateTime> p_fecha)
{
        CancionEN cancionEN = null;

        //Initialized CancionEN
        cancionEN = new CancionEN ();
        cancionEN.Id = p_Cancion_OID;
        cancionEN.Titulo = p_titulo;
        cancionEN.Fichero = p_fichero;
        cancionEN.Duracion = p_duracion;
        cancionEN.Reproducciones = p_reproducciones;
        cancionEN.Fecha = p_fecha;
        //Call to CancionCAD

        _ICancionCAD.Modify (cancionEN);
}

public void Destroy (int id
                     )
{
        _ICancionCAD.Destroy (id);
}

public CancionEN ReadOID (int id
                          )
{
        CancionEN cancionEN = null;

        cancionEN = _ICancionCAD.ReadOID (id);
        return cancionEN;
}

public System.Collections.Generic.IList<CancionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CancionEN> list = null;

        list = _ICancionCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> BuscarPorTitulo (string titulo)
{
        return _ICancionCAD.BuscarPorTitulo (titulo);
}
public System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> OrdenarPorReproducciones ()
{
        return _ICancionCAD.OrdenarPorReproducciones ();
}
public System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> OrdenarPorTitulo ()
{
        return _ICancionCAD.OrdenarPorTitulo ();
}
public void RecibirMeGusta (int p_Cancion_OID, System.Collections.Generic.IList<int> p_usuarios_gustados_OIDs)
{
        //Call to CancionCAD

        _ICancionCAD.RecibirMeGusta (p_Cancion_OID, p_usuarios_gustados_OIDs);
}
public void QuitarMeGusta (int p_Cancion_OID, System.Collections.Generic.IList<int> p_usuarios_gustados_OIDs)
{
        //Call to CancionCAD

        _ICancionCAD.QuitarMeGusta (p_Cancion_OID, p_usuarios_gustados_OIDs);
}
}
}
