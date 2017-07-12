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
    public class ComprobantesController : Controller
    {
        //private DeleiteDbContext db = new DeleiteDbContext();

        private readonly IUnityOfWork _UnityOfWork;
        public ComprobantesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }
        public ComprobantesController()
        {

        }

        // GET: Comprobantes
        public ActionResult Index()
        {
            // var comprobantes = db.Comprobantes.Include(c => c.Pedido);
            var clientes = _UnityOfWork.Comprobantes.GetEntity().Include(c => c.Pedido);
            return View(clientes.ToList());

        }

        // GET: Comprobantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Comprobante comprobante = db.Comprobantes.Find(id);
            Comprobante comprobante = _UnityOfWork.Comprobantes.Get(id);
            if (comprobante == null)
            {
                return HttpNotFound();
            }
            return View(comprobante);
        }

        // GET: Comprobantes/Create
        public ActionResult Create()
        {
            ViewBag.ComprobanteId = new SelectList(_UnityOfWork.Pedidos.GetEntity(), "PedidoId", "PedidoId");
            return View();
        }

        // POST: Comprobantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComprobanteId,Fecha,Total,Direccion,NumDocumento,Igv,TipoComprobante,PedidoId")] Comprobante comprobante)
        {
            if (ModelState.IsValid)
            {
                // db.Comprobantes.Add(comprobante);
                _UnityOfWork.Comprobantes.Add(comprobante);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ComprobanteId = new SelectList(_UnityOfWork.Pedidos.GetEntity(), "PedidoId", "PedidoId", comprobante.ComprobanteId);
            return View(comprobante);
        }

        // GET: Comprobantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Comprobante comprobante = db.Comprobantes.Find(id);
            Comprobante comprobante = _UnityOfWork.Comprobantes.Get(id);
            if (comprobante == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComprobanteId = new SelectList(_UnityOfWork.Pedidos.GetEntity(), "PedidoId", "PedidoId", comprobante.ComprobanteId);
            return View(comprobante);
        }

        // POST: Comprobantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComprobanteId,Fecha,Total,Direccion,NumDocumento,Igv,TipoComprobante,PedidoId")] Comprobante comprobante)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(comprobante).State = EntityState.Modified;
                _UnityOfWork.StateModified(comprobante);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComprobanteId = new SelectList(_UnityOfWork.Pedidos.GetEntity(), "PedidoId", "PedidoId", comprobante.ComprobanteId);
            return View(comprobante);
        }

        // GET: Comprobantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Comprobante comprobante = db.Comprobantes.Find(id);
            Comprobante comprobante = _UnityOfWork.Comprobantes.Get(id);
            if (comprobante == null)
            {
                return HttpNotFound();
            }
            return View(comprobante);
        }

        // POST: Comprobantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Comprobante comprobante = db.Comprobantes.Find(id);
            Comprobante comprobante = _UnityOfWork.Comprobantes.Get(id);
            //db.Comprobantes.Remove(comprobante);
            _UnityOfWork.Comprobantes.Remove(comprobante);
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
