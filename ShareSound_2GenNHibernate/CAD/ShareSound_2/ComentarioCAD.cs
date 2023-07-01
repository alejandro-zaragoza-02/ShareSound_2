
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
 * Clase Comentario:
 *
 */

namespace ShareSound_2GenNHibernate.CAD.ShareSound_2
{
public partial class ComentarioCAD : BasicCAD, IComentarioCAD
{
public ComentarioCAD() : base ()
{
}

public ComentarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public ComentarioEN ReadOIDDefault (int id
                                    )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentarioEN)).List<ComentarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), comentario.Id);

                comentarioEN.Contenido = comentario.Contenido;


                comentarioEN.Fecha = comentario.Fecha;



                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                if (comentario.Cancion != null) {
                        // Argumento OID y no colección.
                        comentario.Cancion = (ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN), comentario.Cancion.Id);

                        comentario.Cancion.Comentarios
                        .Add (comentario);
                }
                if (comentario.Usuario != null) {
                        // Argumento OID y no colección.
                        comentario.Usuario = (ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN)session.Load (typeof(ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN), comentario.Usuario.Id);

                        comentario.Usuario.Comentarios
                        .Add (comentario);
                }

                session.Save (comentario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentario.Id;
}

public void Modify (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), comentario.Id);

                comentarioEN.Contenido = comentario.Contenido;


                comentarioEN.Fecha = comentario.Fecha;

                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
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
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), id);
                session.Delete (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ComentarioEN
public ComentarioEN ReadOID (int id
                             )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComentarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                else
                        result = session.CreateCriteria (typeof(ComentarioEN)).List<ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ShareSound_2GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ShareSound_2GenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
