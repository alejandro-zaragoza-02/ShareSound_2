using ShareSound_2_Front.Assemblers;
using ShareSound_2_Front.Models;
using ShareSound_2GenNHibernate.CAD.ShareSound_2;
using ShareSound_2GenNHibernate.CEN.ShareSound_2;
using ShareSound_2GenNHibernate.EN.ShareSound_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareSound_2_Front.Controllers
{
    [Authorize]
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            IUsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);

            UsuarioEN user = userCEN.ReadOID(id);
            UsuarioViewModel vm = new UsuarioAssembler().ConvertENToModelUI(user);

            SessionClose();
            return View(vm);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            IUsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);

            UsuarioEN user = userCEN.ReadOID(id);
            UsuarioViewModel vm = new UsuarioAssembler().ConvertENToModelUI(user);

            SessionClose();
            return View(vm);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UsuarioViewModel vm)
        {
            try
            {
                UsuarioCAD userCAD = new UsuarioCAD();
                UsuarioCEN userCEN = new UsuarioCEN(userCAD);
                UsuarioEN user = userCEN.ReadOID(id);
                userCEN.Modify(id, user.Pass, vm.Nombre, vm.Descripcion, user.Imagen, user.Email, user.Fecha);

                return RedirectToAction("Details", new { id = id });
            }
            catch
            {
                return RedirectToAction("Details", new { id = id });
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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

            IList<int> users = new List<int>();
            users.Add(id);

            SessionClose();
            userCAD = new UsuarioCAD();
            userCEN = new UsuarioCEN(userCAD);
            userCEN.SeguirUsuario(user.Id, users);
            return RedirectToAction("Details", "Usuario", new { id = id });
        }

        public ActionResult UnFollow(int id)
        {
            SessionInitialize();
            UsuarioCAD userCAD = new UsuarioCAD(session);
            UsuarioCEN userCEN = new UsuarioCEN(userCAD);

            UsuarioEN user = userCEN.ReadOID(Convert.ToInt32(Session["userId"]));

            IList<int> users = new List<int>();
            users.Add(id);

            SessionClose();
            userCAD = new UsuarioCAD();
            userCEN = new UsuarioCEN(userCAD);
            userCEN.DejarSeguirUsuario(user.Id, users);
            return RedirectToAction("Details", "Usuario", new { id = id });
        }
    }
}
