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
using eWorkShopAPI.Common;
using eWorkShopAPI.Entity;

namespace eWorkShopAPI.Controllers
{
  public class TicketsController : ApiController
  {
    private eWorkShop123Entities db = new eWorkShop123Entities();

    // GET: api/Tickets
    public IQueryable<Ticket> GetTickets()
    {
      return db.Tickets;
    }

    // GET: api/Tickets/5
    [ResponseType(typeof(Ticket))]
    public IHttpActionResult GetTicket(long id)
    {
      Ticket ticket = db.Tickets.Find(id);
      if (ticket == null)
      {
        return NotFound();
      }

      return Ok(ticket);
    }

    // PUT: api/Tickets/5
    [HttpPost]
    public IHttpActionResult UpdateTicket(long id, Ticket ticket)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != ticket.TicketID)
      {
        return BadRequest();
      }

      db.Entry(ticket).State = EntityState.Modified;

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TicketExists(id))
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

    // POST: api/Tickets
    [HttpPost]
    public IHttpActionResult SaveTicket(Ticket ticket, TemplateType templateTypes, TicketInvoice ticketInvoice)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      ticket.CreatedDate = DateTime.Now;
      ticket.CreatedBy = (int)EUserTypes.Admin;
      ticket.UpdatedDate = DateTime.Now;
      ticket.UpdatedBy = (int)EUserTypes.Admin;
      ticket.IsArchived = false;

      db.Tickets.Add(ticket);
      db.SaveChanges();

      return CreatedAtRoute("DefaultApi", new { id = ticket.TicketID }, ticket);
    }

    // DELETE: api/Tickets/5
    [HttpGet]
    public IHttpActionResult DeleteTicket(long id)
    {
      Ticket ticket = db.Tickets.Find(id);
      if (ticket == null)
      {
        return NotFound();
      }

      db.Tickets.Remove(ticket);
      db.SaveChanges();

      return Ok(ticket);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool TicketExists(long id)
    {
      return db.Tickets.Count(e => e.TicketID == id) > 0;
    }
  }
}