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
    public class AcompanantesController : ApiController
    {
        private SuperHeroesEntities db = new SuperHeroesEntities();

        // GET: api/Acompanantes
        public IHttpActionResult GetAcompanantes()
        {
            return Ok(db.Acompanantes.ToList().Select(x => new Acompanantes()).ToList());
        }

        // GET: api/Acompanantes/5
        [ResponseType(typeof(Acompanantes))]
        public IHttpActionResult GetAcompanantes(int id)
        {
            Acompanantes acompanantes = db.Acompanantes.Find(id);
            if (acompanantes == null)
            {
                return NotFound();
            }

            return Ok(acompanantes);
        }

        // PUT: api/Acompanantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAcompanantes(int id, Acompanantes acompanantes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acompanantes.SuperheroeID)
            {
                return BadRequest();
            }

            db.Entry(acompanantes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcompanantesExists(id))
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

        // POST: api/Acompanantes
        [ResponseType(typeof(Acompanantes))]
        public IHttpActionResult PostAcompanantes(Acompanantes acompanantes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Acompanantes.Add(acompanantes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AcompanantesExists(acompanantes.SuperheroeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = acompanantes.SuperheroeID }, acompanantes);
        }

        // DELETE: api/Acompanantes/5
        [ResponseType(typeof(Acompanantes))]
        public IHttpActionResult DeleteAcompanantes(int id)
        {
            Acompanantes acompanantes = db.Acompanantes.Find(id);
            if (acompanantes == null)
            {
                return NotFound();
            }

            db.Acompanantes.Remove(acompanantes);
            db.SaveChanges();

            return Ok(acompanantes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AcompanantesExists(int id)
        {
            return db.Acompanantes.Count(e => e.SuperheroeID == id) > 0;
        }
    }
}