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
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace DeleitesVenezolano.API.Controllers
{
    public class ReservasController : ApiController
    {
        private DeleiteDbContext db = new DeleiteDbContext();

        // GET: api/Administrativoes
        public IQueryable<Reserva> GetReservas()
        {
            return db.Reservas;
        }

        // GET: api/Administrativoes/5
        [ResponseType(typeof(Reserva))]
        public IHttpActionResult GetReserva(int id)
        {
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return NotFound();
            }

            return Ok(reserva);
        }

        // PUT: api/Administrativoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReserva(int id, Reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reserva.ReservaId)
            {
                return BadRequest();
            }

            db.Entry(reserva).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Administrativoes
        [ResponseType(typeof(Reserva))]
        public IHttpActionResult PostReserva(Reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reservas.Add(reserva);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reserva.ReservaId }, reserva);
        }

        // DELETE: api/Administrativoes/5
        [ResponseType(typeof(Reserva))]
        public IHttpActionResult DeleteReserva(int id)
        {
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return NotFound();
            }

            db.Reservas.Remove(reserva);
            db.SaveChanges();

            return Ok(reserva);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservaExists(int id)
        {
            return db.Reservas.Count(e => e.ReservaId == id) > 0;
        }
    }
}
