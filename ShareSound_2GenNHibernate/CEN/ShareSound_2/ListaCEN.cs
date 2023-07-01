

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
 *      Definition of the class ListaCEN
 *
 */
public partial class ListaCEN
{
private IListaCAD _IListaCAD;

public ListaCEN()
{
        this._IListaCAD = new ListaCAD ();
}

public ListaCEN(IListaCAD _IListaCAD)
{
        this._IListaCAD = _IListaCAD;
}

public IListaCAD get_IListaCAD ()
{
        return this._IListaCAD;
}

public int New_ (string p_titulo, string p_descripcion, string p_imagen, bool p_publico, Nullable<DateTime> p_fecha)
{
        ListaEN listaEN = null;
        int oid;

        //Initialized ListaEN
        listaEN = new ListaEN ();
        listaEN.Titulo = p_titulo;

        listaEN.Descripcion = p_descripcion;

        listaEN.Imagen = p_imagen;

        listaEN.Publico = p_publico;

        listaEN.Fecha = p_fecha;

        //Call to ListaCAD

        oid = _IListaCAD.New_ (listaEN);
        return oid;
}

public void Modify (int p_Lista_OID, string p_titulo, string p_descripcion, string p_imagen, bool p_publico, Nullable<DateTime> p_fecha)
{
        ListaEN listaEN = null;

        //Initialized ListaEN
        listaEN = new ListaEN ();
        listaEN.Id = p_Lista_OID;
        listaEN.Titulo = p_titulo;
        listaEN.Descripcion = p_descripcion;
        listaEN.Imagen = p_imagen;
        listaEN.Publico = p_publico;
        listaEN.Fecha = p_fecha;
        //Call to ListaCAD

        _IListaCAD.Modify (listaEN);
}

public void Destroy (int id
                     )
{
        _IListaCAD.Destroy (id);
}

public ListaEN ReadOID (int id
                        )
{
        ListaEN listaEN = null;

        listaEN = _IListaCAD.ReadOID (id);
        return listaEN;
}

public System.Collections.Generic.IList<ListaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> list = null;

        list = _IListaCAD.ReadAll (first, size);
        return list;
}
}
}
