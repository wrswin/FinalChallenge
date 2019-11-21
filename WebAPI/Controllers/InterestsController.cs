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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class InterestsController : ApiController
    {
        private FinalChallengeEntities db = new FinalChallengeEntities();

        // GET: api/Interests
        public IQueryable<Interest> GetInterests()
        {
            return db.Interests;
        }

        // GET: api/Interests/5
        [ResponseType(typeof(Interest))]
        public IHttpActionResult GetInterest(string id)
        {
            Interest interest = db.Interests.Find(id);
            if (interest == null)
            {
                return NotFound();
            }

            return Ok(interest);
        }

        // PUT: api/Interests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInterest(string id, Interest interest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != interest.InterestCode)
            {
                return BadRequest();
            }

            db.Entry(interest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestExists(id))
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

        // POST: api/Interests
        [ResponseType(typeof(Interest))]
        public IHttpActionResult PostInterest(Interest interest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Interests.Add(interest);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InterestExists(interest.InterestCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = interest.InterestCode }, interest);
        }

        // DELETE: api/Interests/5
        [ResponseType(typeof(Interest))]
        public IHttpActionResult DeleteInterest(string id)
        {
            Interest interest = db.Interests.Find(id);
            if (interest == null)
            {
                return NotFound();
            }

            db.Interests.Remove(interest);
            db.SaveChanges();

            return Ok(interest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InterestExists(string id)
        {
            return db.Interests.Count(e => e.InterestCode == id) > 0;
        }
    }
}