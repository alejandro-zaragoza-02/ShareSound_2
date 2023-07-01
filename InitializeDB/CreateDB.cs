
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ShareSound_2GenNHibernate.EN.ShareSound_2;
using ShareSound_2GenNHibernate.CEN.ShareSound_2;
using ShareSound_2GenNHibernate.CAD.ShareSound_2;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                IAlbumCAD _IAlbumCAD = new AlbumCAD ();
                IUsuarioCAD _IUsuarioCAD = new UsuarioCAD ();
                IPlaylistCAD _IPlaylistCAD = new PlaylistCAD ();
                ICancionCAD _ICancionCAD = new CancionCAD ();
                IListaCAD _IListaCAD = new ListaCAD ();
                IComentarioCAD _IComentarioCAD = new ComentarioCAD ();

                AlbumCEN albumCEN = new AlbumCEN (_IAlbumCAD);
                UsuarioCEN usuarioCEN = new UsuarioCEN (_IUsuarioCAD);
                PlaylistCEN playlistCEN = new PlaylistCEN (_IPlaylistCAD);
                CancionCEN cancionCEN = new CancionCEN (_ICancionCAD);
                ListaCEN listaCEN = new ListaCEN (_IListaCAD);
                ComentarioCEN comentarioCEN = new ComentarioCEN (_IComentarioCAD);

                int user_0_id = usuarioCEN.New_ ("Dsm123$", "ShareSound", "ShareSound", ".jpg", "sharesound@gmail.com", DateTime.Now);
                int user_1_id = usuarioCEN.New_ ("Dsm123$", "Alejandro", "Me llamo Alejandro!", ".jpg", "alejandro@gmail.com", DateTime.Now);
                int user_2_id = usuarioCEN.New_ ("Dsm123$", "Miguel", "Me llamo Miguel!", ".jpg", "miguel@gmail.com", DateTime.Now);
                int user_3_id = usuarioCEN.New_ ("Dsm123$", "Pablo", "Me llamo Pablo!", ".jpg", "pablo@gmail.com", DateTime.Now);

                Console.WriteLine ("Este es el ID del usuario admin --> " + user_0_id);

                int album_1_id = albumCEN.New_ ("Albumium", "Albumium es un �lbum muy chachi.", "65536.jpg", false, DateTime.Now, user_1_id);
                int album_2_id = albumCEN.New_ ("La vida es bella", "La vida es bella es un �lbum lleno de inspiraci�n.", ".jpg", false, DateTime.Now, user_1_id);
                int album_3_id = albumCEN.New_ ("Platinostrum", "Platinostrum es una experiencia musical innovadora!", ".jpg", false, DateTime.Now, user_2_id);

                int playlist_1_id = playlistCEN.New_ ("Albumium", "Albumium es un �lbum muy chachi.", ".jpg", false, DateTime.Now, user_3_id);

                int cancion_1_id = cancionCEN.New_ ("Luz de luna", ".mp3", 120, 0, DateTime.Now, album_1_id);
                int cancion_2_id = cancionCEN.New_ ("Luz de sol", ".mp3", 140, 0, DateTime.Now, album_1_id);
                int cancion_3_id = cancionCEN.New_ ("Terricolas", ".mp3", 180, 0, DateTime.Now, album_3_id);

                IList<int> lista = new List<int>();
                lista.Add (cancion_2_id);
                playlistCEN.AnyadirCancion (playlist_1_id, lista);


                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
