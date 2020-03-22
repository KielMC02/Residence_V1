using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using G_D_Residencia_V1.Models;

namespace G_D_Residencia_V1.Controllers
{
    public class USUARIOsController : Controller
    {
        private RESIDENT_SYSTEMEntities db = new RESIDENT_SYSTEMEntities();

        // GET: USUARIOs
        public ActionResult Index()
        {
            var uSUARIOS = db.USUARIOS.Include(u => u.HABITACIONE).Include(u => u.AspNetUser);
            return View(uSUARIOS.ToList());
        }

        // GET: USUARIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOS.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIOs/Create
        public ActionResult Create()
        {
            ViewBag.id_habitacion = new SelectList(db.HABITACIONES, "id_habitacion", "habitacion");
            ViewBag.id_Net_Users = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: USUARIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_usuario,id_habitacion,nombres,apellidos,matricula,cedula,telefono,estado_usuario,fecha_nac,sexo,direccion,id_Net_Users")] USUARIO uSUARIO)
        {
            //id_usuario = from s in db.AspNetUsers where s.Email == email_usuario
            //uSUARIO.id_Net_Users =
            if (ModelState.IsValid)
            {

                db.USUARIOS.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_habitacion = new SelectList(db.HABITACIONES, "id_habitacion", "habitacion", uSUARIO.id_habitacion);
            ViewBag.id_Net_Users = new SelectList(db.AspNetUsers, "Id", "Email", uSUARIO.id_Net_Users);
            return View(uSUARIO);
        }

        // GET: USUARIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOS.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_habitacion = new SelectList(db.HABITACIONES, "id_habitacion", "habitacion", uSUARIO.id_habitacion);
            ViewBag.id_Net_Users = new SelectList(db.AspNetUsers, "Id", "Email", uSUARIO.id_Net_Users);
            return View(uSUARIO);
        }

        // POST: USUARIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_usuario,id_habitacion,nombres,apellidos,matricula,cedula,telefono,estado_usuario,fecha_nac,sexo,direccion,id_Net_Users")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_habitacion = new SelectList(db.HABITACIONES, "id_habitacion", "habitacion", uSUARIO.id_habitacion);
            ViewBag.id_Net_Users = new SelectList(db.AspNetUsers, "Id", "Email", uSUARIO.id_Net_Users);
            return View(uSUARIO);
        }

        // GET: USUARIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOS.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO uSUARIO = db.USUARIOS.Find(id);
            db.USUARIOS.Remove(uSUARIO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
