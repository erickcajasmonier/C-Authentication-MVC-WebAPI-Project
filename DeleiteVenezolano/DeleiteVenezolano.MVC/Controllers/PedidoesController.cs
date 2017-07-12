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
    public class PedidoesController : Controller
    {
        // private DeleiteDbContext db = new DeleiteDbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public PedidoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }
        public PedidoesController()
        {

        }

        // GET: Pedidoes
        public ActionResult Index()
        {
            var pedidos = _UnityOfWork.Pedidos.GetEntity().Include(p => p.Cliente).Include(p => p.Empleado);
            return View(_UnityOfWork.Pedidos.GetAll());
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Pedido pedido = db.Pedidos.Find(id);

            Pedido pedido = _UnityOfWork.Pedidos.Get(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre");
            ViewBag.EmpleadoId = new SelectList(_UnityOfWork.Empleados.GetEntity(), "EmpleadoId", "Nombre");
            return View();
        }

        // POST: Pedidoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoId,Fecha,Hora,Cantidad,EstadoPedido,EmpleadoId,ClienteId,ComprobanteId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                // db.Pedidos.Add(pedido);
                _UnityOfWork.Pedidos.Add(pedido);
                // db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre", pedido.ClienteId);
            ViewBag.EmpleadoId = new SelectList(_UnityOfWork.Empleados.GetEntity(), "EmpleadoId", "Nombre", pedido.EmpleadoId);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Pedido pedido = db.Pedidos.Find(id);
            Pedido pedido = _UnityOfWork.Pedidos.Get(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre", pedido.ClienteId);
            ViewBag.EmpleadoId = new SelectList(_UnityOfWork.Empleados.GetEntity(), "EmpleadoId", "Nombre", pedido.EmpleadoId);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PedidoId,Fecha,Hora,Cantidad,EstadoPedido,EmpleadoId,ClienteId,ComprobanteId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(pedido).State = EntityState.Modified;
                _UnityOfWork.StateModified(pedido);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre", pedido.ClienteId);
            ViewBag.EmpleadoId = new SelectList(_UnityOfWork.Empleados.GetEntity(), "EmpleadoId", "Nombre", pedido.EmpleadoId);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Pedido pedido = db.Pedidos.Find(id);
            Pedido pedido = _UnityOfWork.Pedidos.Get(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Pedido pedido = db.Pedidos.Find(id);
            Pedido pedido = _UnityOfWork.Pedidos.Get(id);
            //db.Pedidos.Remove(pedido);
            _UnityOfWork.Pedidos.Remove(pedido);
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
