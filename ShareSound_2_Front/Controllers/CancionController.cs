using ShareSound_2_Front.Assemblers;
using ShareSound_2_Front.Controllers;
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
using NAudio.Wave;

namespace ShareSound_2_Front.Controllers
{
    [Authorize]
    public class CancionController : BasicController
    {
        // GET: Cancion
        public ActionResult Index()
        {
            SessionInitialize();
            CancionCAD cancionCAD = new CancionCAD(session);
            CancionCEN cancionCEN = new CancionCEN(cancionCAD);

            IList<CancionEN> canciones = cancionCEN.ReadAll(0, -1);

            IEnumerable<CancionViewModel> vm = new CancionAssembler().ConvertListENToViewModel(canciones).ToList();
            SessionClose();
            return View(vm);
        }

        public ActionResult Top10()
        {
            SessionInitialize();
            CancionCAD cancionCAD = new CancionCAD(session);
            CancionCEN cancionCEN = new CancionCEN(cancionCAD);

            IList<CancionEN> canciones = cancionCEN.OrdenarPorReproducciones();

            IEnumerable<CancionViewModel> vm = new CancionAssembler().ConvertListENToViewModel(canciones).ToList().Take(10);
            SessionClose();
            return View(vm);
        }

        public ActionResult Top50()
        {
            SessionInitialize();
            CancionCAD cancionCAD = new CancionCAD(session);
            CancionCEN cancionCEN = new CancionCEN(cancionCAD);

            IList<CancionEN> canciones = cancionCEN.OrdenarPorReproducciones();

            IEnumerable<CancionViewModel> vm = new CancionAssembler().ConvertListENToViewModel(canciones).ToList().Take(50);
            SessionClose();
            return View(vm);
        }

        public ActionResult MasGustadas()
        {
            SessionInitialize();
            CancionCAD cancionCAD = new CancionCAD(session);
            CancionCEN cancionCEN = new CancionCEN(cancionCAD);

            IList<CancionEN> canciones = cancionCEN.OrdenarPorMeGustas();

            IEnumerable<CancionViewModel> vm = new CancionAssembler().ConvertListENToViewModel(canciones).ToList().Take(100);
            SessionClose();
            return View(vm);
        }

        // GET: Cancion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cancion/Create
        public ActionResult Create()
        {
            SessionInitialize();
            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);

            int user_id = Convert.ToInt32(Session["userId"]);
            UsuarioEN user = userCEN.ReadOID(user_id);

            IList<SelectListItem> albumes = new List<SelectListItem>();
            foreach(AlbumEN album in user.Albums_creados)
            {
                albumes.Add(new SelectListItem { Text = album.Titulo, Value = album.Id.ToString() });
            }

            ViewData["idAlbumSeleccionado"] = albumes;
            SessionClose();
            return View();
        }

        // POST: Cancion/Create
        [HttpPost]
        public ActionResult Create(CancionViewModel cancionVM)
        {
            
            CancionCAD cancionCAD = new CancionCAD();
            CancionCEN cancionCEN = new CancionCEN(cancionCAD);

            string ext = "";
            int dur = 0;
            if (cancionVM.Fichero_mp3 != null)
            {
                ext = Path.GetExtension(cancionVM.Fichero_mp3.FileName);
                Mp3FileReader reader = new Mp3FileReader(cancionVM.Fichero_mp3.InputStream);
                dur = (int) reader.TotalTime.TotalSeconds;
            }

            int cancion_id = cancionCEN.New_(cancionVM.Titulo, ext, dur, 0, DateTime.Now, Convert.ToInt32(cancionVM.idAlbumSeleccionado));

            if (cancionVM.Fichero_mp3 != null)
            {
                cancionVM.Fichero_mp3.SaveAs(Server.MapPath("~/src/Canciones/" + cancion_id + ext));
            }

            return RedirectToAction("Details", "Album", new { id = cancionVM.idAlbumSeleccionado });
            
        }

        // GET: Cancion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cancion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cancion/Delete/5
        public ActionResult Delete(int id)
        {
            int album_id = 0;

            try
            {
                SessionInitialize();
                CancionCAD cancionCAD = new CancionCAD(session);
                CancionCEN cancionCEN = new CancionCEN(cancionCAD);

                CancionEN cancion = cancionCEN.ReadOID(id);

                album_id = cancion.Album.Id;

                try
                {
                    FileInfo file = new FileInfo(Server.MapPath("~/src/Canciones/" + id + cancion.Fichero));
                    file.Delete();
                }
                catch
                {
                    // El archivo ya esta borrado
                }

                SessionClose();

                cancionCAD = new CancionCAD();
                cancionCEN = new CancionCEN(cancionCAD);

                cancionCEN.Destroy(id);
            }
            catch
            {
                // No se hace nada
            }

            return RedirectToAction("Edit", "Album", new { id = album_id });
        }


        public ActionResult Like(int id, string ctl, string act, int idLista)
        {
            try
            {
                SessionInitialize();
                CancionCAD cancionCAD = new CancionCAD(session);
                CancionCEN cancionCEN = new CancionCEN(cancionCAD);

                CancionEN cancion = cancionCEN.ReadOID(id);

                cancionCAD = new CancionCAD();
                cancionCEN = new CancionCEN(cancionCAD);

                UsuarioCAD userCAD = new UsuarioCAD(session);
                UsuarioCEN userCEN = new UsuarioCEN(userCAD);

                UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));

                IList<int> users = new List<int>();
                users.Add(user.Id);

                SessionClose();

                cancionCEN.RecibirMeGusta(id, users);

                if (idLista != 0)
                {
                    return RedirectToAction(act, ctl, new { id = idLista });
                }
                else
                {
                    return RedirectToAction(act, ctl);
                }
            }
            catch
            {
                // No se hace nada
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UnLike(int id, string ctl, string act, int idLista)
        {
            try
            {
                SessionInitialize();
                CancionCAD cancionCAD = new CancionCAD(session);
                CancionCEN cancionCEN = new CancionCEN(cancionCAD);

                CancionEN cancion = cancionCEN.ReadOID(id);

                cancionCAD = new CancionCAD();
                cancionCEN = new CancionCEN(cancionCAD);

                UsuarioCAD userCAD = new UsuarioCAD(session);
                UsuarioCEN userCEN = new UsuarioCEN(userCAD);

                UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));

                IList<int> users = new List<int>();
                users.Add(user.Id);

                SessionClose();

                cancionCEN.QuitarMeGusta(id, users);

                if(idLista != 0)
                {
                    return RedirectToAction(act, ctl, new { id = idLista });
                }
                else
                {
                    return RedirectToAction(act, ctl);
                }

            }
            catch
            {
                // No se hace nada
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Liked()
        {
            SessionInitialize();
            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);
            UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));

            Dictionary<int, string> playlists = new Dictionary<int, string>();

            foreach (PlaylistEN playlist in user.Playlists_creadas)
            {
                playlists.Add(playlist.Id, playlist.Titulo);
            }

            ViewData["idPlaylistSelected"] = playlists;

            List<CancionViewModel> vm = new CancionAssembler().ConvertListENToViewModel(user.Canciones_gustadas).ToList();
            SessionClose();

            return View(vm);
        } 

        public ActionResult Buscador(string nombre)
        {
            SessionInitialize();
            CancionCAD cancionCAD = new CancionCAD(session);
            CancionCEN cancionCEN = new CancionCEN(cancionCAD);

            string cadena = HttpContext.Request.Url.AbsoluteUri;
            string[] Separado = cadena.Split('/');
            string Final = Separado[Separado.Length - 1];

            IList<CancionEN> cancion = new List<CancionEN>();
            cancion = cancionCEN.BuscarPorTitulo(Final);

            IEnumerable<CancionViewModel> list = new CancionAssembler().ConvertListENToViewModel(cancion).ToList();
            SessionClose();

            return View(list);
        }
    }
}
