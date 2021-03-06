﻿using System;
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
    public class ReservasController : Controller
    {
        //private DeleiteDbContext db = new DeleiteDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public ReservasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }



        // GET: Reservas
        public ActionResult Index()
        {
            // var reservas = db.Reservas.Include(r => r.Cliente);

            var reservas = _UnityOfWork.Reservas.GetEntity().Include(r => r.Cliente);
            //return View(reservas.ToList());
            return View(reservas.ToList());
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Reserva reserva = db.Reservas.Find(id);
            Reserva reserva = _UnityOfWork.Reservas.Get(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            //ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre");
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre");
            return View();
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservaId,Fecha,Hora,ClienteId")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                // db.Reservas.Add(reserva);
                _UnityOfWork.Reservas.Add(reserva);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            // ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", reserva.ClienteId);
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre", reserva.ClienteId);

            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Reserva reserva = db.Reservas.Find(id);
            Reserva reserva = _UnityOfWork.Reservas.Get(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            // ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", reserva.ClienteId);
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre", reserva.ClienteId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservaId,Fecha,Hora,ClienteId")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(reserva).State = EntityState.Modified;
                _UnityOfWork.StateModified(reserva);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            //ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", reserva.ClienteId;
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre", reserva.ClienteId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Reserva reserva = db.Reservas.Find(id);
            Reserva reserva = _UnityOfWork.Reservas.Get(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Reserva reserva = db.Reservas.Find(id);
            Reserva reserva = _UnityOfWork.Reservas.Get(id);
            //db.Reservas.Remove(reserva);
            _UnityOfWork.Reservas.Remove(reserva);
            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
