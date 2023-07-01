
using System;
using System.Text;
using ShareSound_2GenNHibernate.CEN.ShareSound_2;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ShareSound_2GenNHibernate.EN.ShareSound_2;
using ShareSound_2GenNHibernate.Exceptions;


/*
 * Clase Lista:
 *
 */

namespace ShareSound_2GenNHibernate.CAD.ShareSound_2
{
public partial class ListaCAD : BasicCAD, IListaCAD
{
public ListaCAD() : base ()
{
}

public ListaCAD(ISession sessionAux) : base (sessionAux)
{
}



public ListaEN ReadOIDDefault (int id
                               )
{
        ListaEN listaEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Get (typeof(ListaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaEN;
}

public System.Collections.Generic.IList<ListaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ListaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ListaEN>();
                        else
                                result = session.CreateCriteria (typeof(ListaEN)).List<ListaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                ListaEN listaEN = (ListaEN)session.Load (typeof(ListaEN), lista.Id);

                listaEN.Titulo = lista.Titulo;


                listaEN.Descripcion = lista.Descripcion;


                listaEN.Imagen = lista.Imagen;


                listaEN.Publico = lista.Publico;


                listaEN.Fecha = lista.Fecha;

                session.Update (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (lista);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lista.Id;
}

public void Modify (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                ListaEN listaEN = (ListaEN)session.Load (typeof(ListaEN), lista.Id);

                listaEN.Titulo = lista.Titulo;


                listaEN.Descripcion = lista.Descripcion;


                listaEN.Imagen = lista.Imagen;


                listaEN.Publico = lista.Publico;


                listaEN.Fecha = lista.Fecha;

                session.Update (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ListaEN listaEN = (ListaEN)session.Load (typeof(ListaEN), id);
                session.Delete (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ListaEN
public ListaEN ReadOID (int id
                        )
{
        ListaEN listaEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Get (typeof(ListaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaEN;
}

public System.Collections.Generic.IList<ListaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ListaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ListaEN>();
                else
                        result = session.CreateCriteria (typeof(ListaEN)).List<ListaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ListaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
