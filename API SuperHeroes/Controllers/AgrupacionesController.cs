using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_SuperHeroes.Models;

namespace API_SuperHeroes.Controllers
{
    public class AgrupacionesController : ApiController
    {
        private SuperHeroesEntities db = new SuperHeroesEntities();

        // GET: api/Agrupaciones
        public IHttpActionResult GetAgrupaciones()
        {
            return Ok(db.Agrupaciones.ToList().Select(x => new Agrupaciones()).ToList());
        }

        // GET: api/Agrupaciones/5
        [ResponseType(typeof(Agrupaciones))]
        public IHttpActionResult GetAgrupaciones(int id)
        {
            Agrupaciones agrupaciones = db.Agrupaciones.Find(id);
            if (agrupaciones == null)
            {
                return NotFound();
            }

            return Ok(agrupaciones);
        }

        // PUT: api/Agrupaciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgrupaciones(int id, Agrupaciones agrupaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agrupaciones.AgrupacionesID)
            {
                return BadRequest();
            }

            db.Entry(agrupaciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgrupacionesExists(id))
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

        // POST: api/Agrupaciones
        [ResponseType(typeof(Agrupaciones))]
        public IHttpActionResult PostAgrupaciones(Agrupaciones agrupaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Agrupaciones.Add(agrupaciones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agrupaciones.AgrupacionesID }, agrupaciones);
        }

        // DELETE: api/Agrupaciones/5
        [ResponseType(typeof(Agrupaciones))]
        public IHttpActionResult DeleteAgrupaciones(int id)
        {
            Agrupaciones agrupaciones = db.Agrupaciones.Find(id);
            if (agrupaciones == null)
            {
                return NotFound();
            }

            db.Agrupaciones.Remove(agrupaciones);
            db.SaveChanges();

            return Ok(agrupaciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgrupacionesExists(int id)
        {
            return db.Agrupaciones.Count(e => e.AgrupacionesID == id) > 0;
        }
    }
}