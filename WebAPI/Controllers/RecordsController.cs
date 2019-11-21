﻿using System;
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
    public class RecordsController : ApiController
    {
        private FinalChallengeEntities db = new FinalChallengeEntities();

        // GET: api/Records
        public IQueryable<Record> GetRecords()
        {
            return db.Records;
        }

        // GET: api/Records/5
        [ResponseType(typeof(Record))]
        public IHttpActionResult GetRecord(string id)
        {
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }

        // PUT: api/Records/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecord(string id, Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != record.RecordID)
            {
                return BadRequest();
            }

            db.Entry(record).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
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

        // POST: api/Records
        [ResponseType(typeof(Record))]
        public IHttpActionResult PostRecord(Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Records.Add(record);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RecordExists(record.RecordID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = record.RecordID }, record);
        }

        // DELETE: api/Records/5
        [ResponseType(typeof(Record))]
        public IHttpActionResult DeleteRecord(string id)
        {
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return NotFound();
            }

            db.Records.Remove(record);
            db.SaveChanges();

            return Ok(record);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecordExists(string id)
        {
            return db.Records.Count(e => e.RecordID == id) > 0;
        }
    }
}