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
    public class Superheroes_SuperpoderesController : ApiController
    {
        private SuperHeroesEntities db = new SuperHeroesEntities();

        // GET: api/Superheroes_Superpoderes
        public IHttpActionResult GetSuperheroes_Superpoderes()
        {
            return Ok(db.Superheroes_Superpoderes.ToList().Select(x => new Superheroes_Superpoderes()).ToList());
        }

        // GET: api/Superheroes_Superpoderes/5
        [ResponseType(typeof(Superheroes_Superpoderes))]
        public IHttpActionResult GetSuperheroes_Superpoderes(int id)
        {
            Superheroes_Superpoderes superheroes_Superpoderes = db.Superheroes_Superpoderes.Find(id);
            if (superheroes_Superpoderes == null)
            {
                return NotFound();
            }

            return Ok(superheroes_Superpoderes);
        }

        // PUT: api/Superheroes_Superpoderes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuperheroes_Superpoderes(int id, Superheroes_Superpoderes superheroes_Superpoderes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != superheroes_Superpoderes.SuperheroeID)
            {
                return BadRequest();
            }

            db.Entry(superheroes_Superpoderes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Superheroes_SuperpoderesExists(id))
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

        // POST: api/Superheroes_Superpoderes
        [ResponseType(typeof(Superheroes_Superpoderes))]
        public IHttpActionResult PostSuperheroes_Superpoderes(Superheroes_Superpoderes superheroes_Superpoderes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Superheroes_Superpoderes.Add(superheroes_Superpoderes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Superheroes_SuperpoderesExists(superheroes_Superpoderes.SuperheroeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = superheroes_Superpoderes.SuperheroeID }, superheroes_Superpoderes);
        }

        // DELETE: api/Superheroes_Superpoderes/5
        [ResponseType(typeof(Superheroes_Superpoderes))]
        public IHttpActionResult DeleteSuperheroes_Superpoderes(int id)
        {
            Superheroes_Superpoderes superheroes_Superpoderes = db.Superheroes_Superpoderes.Find(id);
            if (superheroes_Superpoderes == null)
            {
                return NotFound();
            }

            db.Superheroes_Superpoderes.Remove(superheroes_Superpoderes);
            db.SaveChanges();

            return Ok(superheroes_Superpoderes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Superheroes_SuperpoderesExists(int id)
        {
            return db.Superheroes_Superpoderes.Count(e => e.SuperheroeID == id) > 0;
        }
    }
}