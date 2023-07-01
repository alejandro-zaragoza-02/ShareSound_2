using ShareSound_2_Front.Assemblers;
using ShareSound_2_Front.Models;
using ShareSound_2GenNHibernate.CAD.ShareSound_2;
using ShareSound_2GenNHibernate.CEN.ShareSound_2;
using ShareSound_2GenNHibernate.EN.ShareSound_2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareSound_2_Front.Controllers
{
    public class AlbumController : BasicController
    {
        // GET: Album
        [Authorize]
        public ActionResult Index()
        {
            SessionInitialize();
            AlbumCAD albumCAD = new AlbumCAD(session);
            AlbumCEN albumCEN = new AlbumCEN(albumCAD);

            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);

            UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));
            IEnumerable<ListaViewModel> vm = new AlbumAssembler().ConvertListENToModel(user.Albums_creados).ToList();
            SessionClose();
            return View(vm);

        }

        [Authorize]
        public ActionResult Seguidos()
        {
            SessionInitialize();
            AlbumCAD albumCAD = new AlbumCAD(session);
            AlbumCEN albumCEN = new AlbumCEN(albumCAD);

            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);

            UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));
            IEnumerable<ListaViewModel> vm = new AlbumAssembler().ConvertListENToModel(user.Albums_seguidos).ToList();
            SessionClose();
            return View(vm);

        }

        // GET: Album/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            AlbumCAD albumCAD = new AlbumCAD(session);
            AlbumCEN albumCEN = new AlbumCEN(albumCAD);

            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);
            UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));

            Dictionary<int, string> playlists = new Dictionary<int, string>();

            foreach (PlaylistEN playlist in user.Playlists_creadas)
            {
                playlists.Add(playlist.Id, playlist.Titulo);
            }

            ViewData["idPlaylistSelected"] = playlists;

            AlbumEN album = albumCEN.ReadOID(id);

            ListaViewModel vm = new AlbumAssembler().ConvertENToModelUI(album);
            SessionClose();
            return View(vm); 
            
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        [HttpPost]
        public ActionResult Create(ListaViewModel alb)
        {
            try
            {
                SessionInitialize();
                AlbumCEN albumCEN = new AlbumCEN();
                int user_id = Convert.ToInt32(Session["userId"]);

                if (alb.Descripcion == null)
                {
                    alb.Descripcion = "";
                }
                string ext = "";
                if (alb.Imagen != null)
                {
                    ext = Path.GetExtension(alb.Imagen.FileName);
                }

                int newAlbumId = albumCEN.New_(alb.Titulo, alb.Descripcion, ext, false, DateTime.Now, user_id);

                if (alb.Imagen != null)
                {
                    alb.Imagen.SaveAs(Server.MapPath("~/src/Albumes/" + newAlbumId + ext));
                }

                SessionClose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            AlbumCAD albumCAD = new AlbumCAD(session);
            AlbumCEN albumCEN = new AlbumCEN(albumCAD);

            AlbumEN album = albumCEN.ReadOID(id);
            if (album != null)
            {
                ListaViewModel vm = new AlbumAssembler().ConvertENToModelUI(album);
                SessionClose();
                return View(vm);
            }
            else
            {
                SessionClose();
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: Album/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ListaViewModel alb)
        {
            try
            {
                AlbumCEN albumCEN = new AlbumCEN();
                IList<CancionEN> canciones = new List<CancionEN>();
                AlbumEN album = albumCEN.ReadOID(id);

                string ext = "";
                if (alb.Descripcion == null)
                {
                    alb.Descripcion = "";
                }
                if (alb.Imagen != null)
                {
                    ext = Path.GetExtension(alb.Imagen.FileName);
                }

                if (alb.Imagen != null)
                {
                    FileInfo file = new FileInfo(Server.MapPath("~/src/Albumes/" + id + album.Imagen));
                    file.Delete();
                    alb.Imagen.SaveAs(Server.MapPath("~/src/Albumes/" + alb.Id + ext));
                }

                albumCEN.Modify(id, alb.Titulo, alb.Descripcion, ext, album.Publico, album.Fecha);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SessionInitialize();

                AlbumCAD albumCAD = new AlbumCAD(session);
                AlbumCEN albumCEN = new AlbumCEN(albumCAD);
                AlbumEN album = albumCEN.ReadOID(id);

                foreach(CancionEN cancion in album.Canciones)
                {
                    try
                    {
                        FileInfo song_file = new FileInfo(Server.MapPath("~/src/Canciones/" + cancion.Id + cancion.Fichero));
                        song_file.Delete();
                    }
                    catch
                    {
                        // No se puede borrar esta canción
                    }
                }

                FileInfo file = new FileInfo(Server.MapPath("~/src/Albumes/" + id + album.Imagen));
                file.Delete();

                SessionClose();

                albumCAD = new AlbumCAD();
                albumCEN = new AlbumCEN(albumCAD);

                albumCEN.Destroy(id);
                

                return RedirectToAction("Index", "Album");
            }
            catch
            {
                return RedirectToAction("Details", "Album", new { id = id });
            }
        }

        // POST: Album/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ListaViewModel albumVM)
        {
            try
            {
                AlbumCEN albumCEN = new AlbumCEN();
                AlbumEN album = albumCEN.ReadOID(id);

                albumCEN.Destroy(id);
                FileInfo file = new FileInfo(Server.MapPath("~/src/Albumes/" + albumVM.Id + album.Imagen));
                file.Delete();

                return RedirectToAction("Index", "Album");
            }
            catch
            {
                return RedirectToAction("Details", "Album", new { id = id});
            }
        }

        public ActionResult Follow(int id)
        {
            SessionInitialize();
            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);

            UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));

            IList<int> albums = new List<int>();
            albums.Add(id);

            SessionClose();
            userCAD = new UsuarioCAD();
            userCEN = new UsuarioCEN(userCAD);
            userCEN.SeguirAlbum(user.Id, albums);
            return RedirectToAction("Details", "Album", new { id = id });
        }

        public ActionResult UnFollow(int id)
        {
            SessionInitialize();
            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);

            UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));

            IList<int> albums = new List<int>();
            albums.Add(id);

            SessionClose();
            userCAD = new UsuarioCAD();
            userCEN = new UsuarioCEN(userCAD);
            userCEN.DejarSeguirAlbum(user.Id, albums);
            return RedirectToAction("Details", "Album", new { id = id });
        }
    }
}
