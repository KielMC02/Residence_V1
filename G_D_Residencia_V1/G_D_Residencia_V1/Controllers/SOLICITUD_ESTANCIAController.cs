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
    public class SOLICITUD_ESTANCIAController : Controller
    {
        private RESIDENT_SYSTEMEntities db = new RESIDENT_SYSTEMEntities();

        // GET: SOLICITUD_ESTANCIA
        public ActionResult Index()
        {
            var sOLICITUD_ESTANCIA = db.SOLICITUD_ESTANCIA.Include(s => s.USUARIO);
            return View(sOLICITUD_ESTANCIA.ToList());
        }

        // GET: SOLICITUD_ESTANCIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLICITUD_ESTANCIA sOLICITUD_ESTANCIA = db.SOLICITUD_ESTANCIA.Find(id);
            if (sOLICITUD_ESTANCIA == null)
            {
                return HttpNotFound();
            }
            return View(sOLICITUD_ESTANCIA);
        }

        // GET: SOLICITUD_ESTANCIA/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.USUARIOS, "id_usuario", "nombres");
            return View();
        }

        // POST: SOLICITUD_ESTANCIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_solicitud,id_usuario,motivo_solicitud,seguro_medico,carta_conducta,cedula,fecha_solicitud,fecha_respuesta,estado_solicitud")] SOLICITUD_ESTANCIA sOLICITUD_ESTANCIA)
        {
            if (ModelState.IsValid)
            {
                db.SOLICITUD_ESTANCIA.Add(sOLICITUD_ESTANCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.USUARIOS, "id_usuario", "nombres", sOLICITUD_ESTANCIA.id_usuario);
            return View(sOLICITUD_ESTANCIA);
        }

        // GET: SOLICITUD_ESTANCIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLICITUD_ESTANCIA sOLICITUD_ESTANCIA = db.SOLICITUD_ESTANCIA.Find(id);
            if (sOLICITUD_ESTANCIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.USUARIOS, "id_usuario", "nombres", sOLICITUD_ESTANCIA.id_usuario);
            return View(sOLICITUD_ESTANCIA);
        }

        // POST: SOLICITUD_ESTANCIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_solicitud,id_usuario,motivo_solicitud,seguro_medico,carta_conducta,cedula,fecha_solicitud,fecha_respuesta,estado_solicitud")] SOLICITUD_ESTANCIA sOLICITUD_ESTANCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOLICITUD_ESTANCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.USUARIOS, "id_usuario", "nombres", sOLICITUD_ESTANCIA.id_usuario);
            return View(sOLICITUD_ESTANCIA);
        }

        // GET: SOLICITUD_ESTANCIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLICITUD_ESTANCIA sOLICITUD_ESTANCIA = db.SOLICITUD_ESTANCIA.Find(id);
            if (sOLICITUD_ESTANCIA == null)
            {
                return HttpNotFound();
            }
            return View(sOLICITUD_ESTANCIA);
        }

        // POST: SOLICITUD_ESTANCIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOLICITUD_ESTANCIA sOLICITUD_ESTANCIA = db.SOLICITUD_ESTANCIA.Find(id);
            db.SOLICITUD_ESTANCIA.Remove(sOLICITUD_ESTANCIA);
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
