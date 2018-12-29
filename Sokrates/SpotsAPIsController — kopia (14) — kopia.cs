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
using SpotAPI.Data;

namespace SpotAPI.Controllers
{
    public class SpotsAPIsController : ApiController
    {
        private Syrakuza db = new Syrakuza();

        // GET: api/SpotsAPIs
        public IQueryable<SpotsAPI> GetSpotsAPI()
        {
            return db.SpotsAPI;
        }

        // GET: api/SpotsAPIs/5
        [ResponseType(typeof(SpotsAPI))]
        public IHttpActionResult GetSpotsAPI(int id)
        {
            SpotsAPI spotsAPI = db.SpotsAPI.Find(id);
            if (spotsAPI == null)
            {
                return NotFound();
            }

            return Ok(spotsAPI);
        }

        // PUT: api/SpotsAPIs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpotsAPI(int id, SpotsAPI spotsAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spotsAPI.Id)
            {
                return BadRequest();
            }

            db.Entry(spotsAPI).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpotsAPIExists(id))
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

        // POST: api/SpotsAPIs
        [ResponseType(typeof(SpotsAPI))]
        public IHttpActionResult PostSpotsAPI(SpotsAPI spotsAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpotsAPI.Add(spotsAPI);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = spotsAPI.Id }, spotsAPI);
        }

        // DELETE: api/SpotsAPIs/5
        [ResponseType(typeof(SpotsAPI))]
        public IHttpActionResult DeleteSpotsAPI(int id)
        {
            SpotsAPI spotsAPI = db.SpotsAPI.Find(id);
            if (spotsAPI == null)
            {
                return NotFound();
            }

            db.SpotsAPI.Remove(spotsAPI);
            db.SaveChanges();

            return Ok(spotsAPI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpotsAPIExists(int id)
        {
            return db.SpotsAPI.Count(e => e.Id == id) > 0;
        }
    }
}