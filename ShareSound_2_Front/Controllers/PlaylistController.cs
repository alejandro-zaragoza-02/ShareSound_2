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
    [Authorize]
    public class PlaylistController : BasicController
    {
        // GET: Playlist
        public ActionResult Index()
        {
            SessionInitialize();

            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);

            UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));
            IEnumerable<ListaViewModel> vm = new PlaylistAssembler().ConvertListENToModel(user.Playlists_creadas).ToList();
            SessionClose();
            return View(vm);
        }

        public ActionResult Seguidas()
        {
            SessionInitialize();

            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);

            UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));
            IEnumerable<ListaViewModel> vm = new PlaylistAssembler().ConvertListENToModel(user.Playlists_seguidas).ToList();
            SessionClose();
            return View(vm);

        }

        public ActionResult Explorar_playlist()
        {
            SessionInitialize();

            PlaylistCAD playlistCAD = new PlaylistCAD(session);
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistCAD);

            IList<PlaylistEN> playlists = playlistCEN.ReadAll(0, -1);

            IEnumerable<ListaViewModel> vm = new PlaylistAssembler().ConvertListENToModel(playlists).ToList();
            SessionClose();
            return View(vm);

        }

        // GET: Playlist/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            PlaylistCAD playlistCAD = new PlaylistCAD(session);
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistCAD);

            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);
            UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));

            Dictionary<int, string> playlists = new Dictionary<int, string>();

            foreach (PlaylistEN pl in user.Playlists_creadas)
            {
                playlists.Add(pl.Id, pl.Titulo);
            }

            ViewData["idPlaylistSelected"] = playlists;

            PlaylistEN playlist = playlistCEN.ReadOID(id);

            ListaViewModel vm = new PlaylistAssembler().ConvertENToModelUI(playlist);
            SessionClose();
            return View(vm);
        }

        // GET: Playlist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Playlist/Create
        [HttpPost]
        public ActionResult Create(ListaViewModel lvm)
        {
            try
            {
                SessionInitialize();
                PlaylistCEN playlistCEN = new PlaylistCEN();
                int user_id = Convert.ToInt32(Session["userId"]);

                if (lvm.Descripcion == null)
                {
                    lvm.Descripcion = "";
                }
                string ext = "";
                if (lvm.Imagen != null)
                {
                    ext = Path.GetExtension(lvm.Imagen.FileName);
                }

                int newPlaylistId = playlistCEN.New_(lvm.Titulo, lvm.Descripcion, ext, false, DateTime.Now, user_id);

                if (lvm.Imagen != null)
                {
                    lvm.Imagen.SaveAs(Server.MapPath("~/src/Playlists/" + newPlaylistId + ext));
                }

                SessionClose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Playlist/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            PlaylistCAD playlistCAD = new PlaylistCAD(session);
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistCAD);

            PlaylistEN playlist = playlistCEN.ReadOID(id);

            ListaViewModel vm = new PlaylistAssembler().ConvertENToModelUI(playlist);
            SessionClose();
            return View(vm);
        }

        // POST: Playlist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ListaViewModel lvm)
        {
            try
            {
                PlaylistCEN playlistCEN = new PlaylistCEN();
                IList<CancionEN> canciones = new List<CancionEN>();
                PlaylistEN playlist = playlistCEN.ReadOID(id);

                string ext = "";
                if (lvm.Descripcion == null)
                {
                    lvm.Descripcion = "";
                }
                if (lvm.Imagen != null)
                {
                    ext = Path.GetExtension(lvm.Imagen.FileName);
                }

                if (lvm.Imagen != null)
                {
                    FileInfo file = new FileInfo(Server.MapPath("~/src/Playlists/" + id + playlist.Imagen));
                    file.Delete();
                    lvm.Imagen.SaveAs(Server.MapPath("~/src/Playlists/" + lvm.Id + ext));
                }

                playlistCEN.Modify(id, lvm.Titulo, lvm.Descripcion, ext, playlist.Publico, playlist.Fecha);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Playlist/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SessionInitialize();

                PlaylistCAD playlistCAD = new PlaylistCAD(session);
                PlaylistCEN playlistCEN = new PlaylistCEN(playlistCAD);
                PlaylistEN playlist = playlistCEN.ReadOID(id);

                foreach (CancionEN cancion in playlist.Canciones)
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

                FileInfo file = new FileInfo(Server.MapPath("~/src/Playlists/" + id + playlist.Imagen));
                file.Delete();

                SessionClose();

                playlistCAD = new PlaylistCAD();
                playlistCEN = new PlaylistCEN(playlistCAD);

                playlistCEN.Destroy(id);


                return RedirectToAction("Index", "Playlist");
            }
            catch
            {
                return RedirectToAction("Details", "Playlist", new { id = id });
            }
        }

        // POST: Playlist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Follow(int id)
        {
            SessionInitialize();
            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);

            UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));

            IList<int> playlists = new List<int>();
            playlists.Add(id);

            SessionClose();
            userCAD = new UsuarioCAD();
            userCEN = new UsuarioCEN(userCAD);
            userCEN.SeguirPlaylist(user.Id, playlists);
            return RedirectToAction("Details", "Playlist", new { id = id });
        }

        public ActionResult UnFollow(int id)
        {
            SessionInitialize();
            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);

            UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));

            IList<int> playlists = new List<int>();
            playlists.Add(id);

            SessionClose();
            userCAD = new UsuarioCAD();
            userCEN = new UsuarioCEN(userCAD);
            userCEN.DejarSeguirPlaylist(user.Id, playlists);
            return RedirectToAction("Details", "Playlist", new { id = id });
        }

        public ActionResult Add(int play_id, int song_id)
        {
            PlaylistCAD playlistCAD = new PlaylistCAD();
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistCAD);

            playlistCEN.AnyadirCancion(play_id, new List<int> { song_id });

            return RedirectToAction("Details", "Playlist", new { id = play_id });
        }

        public ActionResult Remove(int play_id, int song_id)
        {
            PlaylistCAD playlistCAD = new PlaylistCAD();
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistCAD);

            playlistCEN.QuitarCancion(play_id, new List<int> { song_id });

            return RedirectToAction("Edit", "Playlist", new { id = play_id });
        }

        public ActionResult Buscador(string nombre)
        {
            SessionInitialize();
            PlaylistCAD playlistCAD = new PlaylistCAD(session);
            PlaylistCEN playlistCEN = new PlaylistCEN(playlistCAD);

            string cadena = HttpContext.Request.Url.AbsoluteUri;
            string[] Separado = cadena.Split('/');
            string Final = Separado[Separado.Length - 1];

            IList<PlaylistEN> cancion = new List<PlaylistEN>();
            cancion = playlistCEN.BuscarPorTitulo(Final);

            IEnumerable<ListaViewModel> list = new PlaylistAssembler().ConvertListENToModel(cancion).ToList();
            SessionClose();

            return View(list);
        }
    }
}
