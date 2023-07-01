﻿using ShareSound_2_Front.Assemblers;
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

                FileInfo file = new FileInfo(Server.MapPath("~/src/Canciones/" + id + cancion.Fichero));
                file.Delete();

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

        // POST: Cancion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CancionViewModel vm)
        {
            try
            {
                CancionCAD cancionCAD = new CancionCAD();
                CancionCEN cancionCEN = new CancionCEN(cancionCAD);

                FileInfo file = new FileInfo(Server.MapPath("~/src/Canciones/" + id + vm.Fichero_mp3));
                file.Delete();

                cancionCEN.Destroy(id);
            }
            catch
            {
                // No se hace nada
            }

            return RedirectToAction("Edit", "Album", new { id = id });
        }

        public ActionResult Like(int id)
        {
            try
            {
                SessionInitialize();
                CancionCAD cancionCAD = new CancionCAD(session);
                CancionCEN cancionCEN = new CancionCEN(cancionCAD);

                CancionEN cancion = cancionCEN.ReadOID(id);

                int album_id = cancion.Album.Id;

                cancionCAD = new CancionCAD();
                cancionCEN = new CancionCEN(cancionCAD);

                UsuarioCAD userCAD = new UsuarioCAD(session);
                UsuarioCEN userCEN = new UsuarioCEN(userCAD);

                UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));

                IList<int> users = new List<int>();
                users.Add(user.Id);

                SessionClose();

                cancionCEN.RecibirMeGusta(id, users);

                return RedirectToAction("Details", "Album", new { id = album_id });
            }
            catch
            {
                // No se hace nada
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UnLike(int id)
        {
            try
            {
                SessionInitialize();
                CancionCAD cancionCAD = new CancionCAD(session);
                CancionCEN cancionCEN = new CancionCEN(cancionCAD);

                CancionEN cancion = cancionCEN.ReadOID(id);

                int album_id = cancion.Album.Id;

                cancionCAD = new CancionCAD();
                cancionCEN = new CancionCEN(cancionCAD);

                UsuarioCAD userCAD = new UsuarioCAD(session);
                UsuarioCEN userCEN = new UsuarioCEN(userCAD);

                UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));

                IList<int> users = new List<int>();
                users.Add(user.Id);

                SessionClose();

                cancionCEN.QuitarMeGusta(id, users);

                return RedirectToAction("Details", "Album", new { id = album_id });
            }
            catch
            {
                // No se hace nada
            }
            return RedirectToAction("Index", "Home");
        }
    }
}