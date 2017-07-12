using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeleiteVenezolano.Entities.Entities;
using DeleiteVenezolano.Persistence;
using DeleiteVenezolano.Entities.IRepositories;

namespace DeleiteVenezolano.MVC.Controllers
{
    public class MesasController : Controller
    {
        //private DeleiteDbContext db = new DeleiteDbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public MesasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }
        public MesasController()
        {

        }

        // GET: Mesas
        public ActionResult Index()
        {
            var mesas = _UnityOfWork.Mesas.GetEntity().Include(m => m.Reserva);
            return View(_UnityOfWork.Mesas.GetAll());
        }

        // GET: Mesas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Mesa mesa = db.Mesas.Find(id);
            Mesa mesa = _UnityOfWork.Mesas.Get(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        // GET: Mesas/Create
        public ActionResult Create()
        {
            ViewBag.ReservaId = new SelectList(_UnityOfWork.Reservas.GetEntity(), "ReservaId", "ReservaId");
            return View();
        }

        // POST: Mesas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MesaId,Numero,MaxPersonas,EstadoMesa,ReservaId")] Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                // db.Mesas.Add(mesa);
                _UnityOfWork.Mesas.Add(mesa);

                //db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ReservaId = new SelectList(_UnityOfWork.Reservas.GetEntity(), "ReservaId", "ReservaId", mesa.ReservaId);
            return View(mesa);
        }

        // GET: Mesas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Mesa mesa = db.Mesas.Find(id);
            Mesa mesa = _UnityOfWork.Mesas.Get(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReservaId = new SelectList(_UnityOfWork.Reservas.GetEntity(), "ReservaId", "ReservaId", mesa.ReservaId);
            return View(mesa);
        }

        // POST: Mesas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MesaId,Numero,MaxPersonas,EstadoMesa,ReservaId")] Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(mesa).State = EntityState.Modified;
                _UnityOfWork.StateModified(mesa);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReservaId = new SelectList(_UnityOfWork.Reservas.GetEntity(), "ReservaId", "ReservaId", mesa.ReservaId);
            return View(mesa);
        }

        // GET: Mesas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Mesa mesa = db.Mesas.Find(id);
            Mesa mesa = _UnityOfWork.Mesas.Get(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        // POST: Mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Mesa mesa = db.Mesas.Find(id);
            Mesa mesa = _UnityOfWork.Mesas.Get(id);
            //db.Mesas.Remove(mesa);
            _UnityOfWork.Mesas.Remove(mesa);
            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
