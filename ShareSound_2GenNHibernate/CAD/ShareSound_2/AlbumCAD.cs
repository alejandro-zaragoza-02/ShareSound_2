
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
 * Clase Album:
 *
 */

namespace ShareSound_2GenNHibernate.CAD.ShareSound_2
{
public partial class AlbumCAD : BasicCAD, IAlbumCAD
{
public AlbumCAD() : base ()
{
}

public AlbumCAD(ISession sessionAux) : base (sessionAux)
{
}



public AlbumEN ReadOIDDefault (int id
                               )
{
        AlbumEN albumEN = null;

        try
        {
                SessionInitializeTransaction ();
                albumEN = (AlbumEN)session.Get (typeof(AlbumEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return albumEN;
}

public System.Collections.Generic.IList<AlbumEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AlbumEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AlbumEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AlbumEN>();
                        else
                                result = session.CreateCriteria (typeof(AlbumEN)).List<AlbumEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AlbumEN album)
{
        try
        {
                SessionInitializeTransaction ();
                AlbumEN albumEN = (AlbumEN)session.Load (typeof(AlbumEN), album.Id);



                session.Update (albumEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (AlbumEN album)
{
        try
        {
                SessionInitializeTransaction ();
                if (album.Usuario != null) {
                        // Argumento OID y no colección.
                        album.Usuario = (ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN), album.Usuario.Id);

                        album.Usuario.Albums_creados
                        .Add (album);
                }

                session.Save (album);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return album.Id;
}

public void Modify (AlbumEN album)
{
        try
        {
                SessionInitializeTransaction ();
                AlbumEN albumEN = (AlbumEN)session.Load (typeof(AlbumEN), album.Id);

                albumEN.Titulo = album.Titulo;


                albumEN.Descripcion = album.Descripcion;


                albumEN.Imagen = album.Imagen;


                albumEN.Publico = album.Publico;


                albumEN.Fecha = album.Fecha;

                session.Update (albumEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
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
                AlbumEN albumEN = (AlbumEN)session.Load (typeof(AlbumEN), id);
                session.Delete (albumEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: AlbumEN
public AlbumEN ReadOID (int id
                        )
{
        AlbumEN albumEN = null;

        try
        {
                SessionInitializeTransaction ();
                albumEN = (AlbumEN)session.Get (typeof(AlbumEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return albumEN;
}

public System.Collections.Generic.IList<AlbumEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AlbumEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AlbumEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AlbumEN>();
                else
                        result = session.CreateCriteria (typeof(AlbumEN)).List<AlbumEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in AlbumCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
