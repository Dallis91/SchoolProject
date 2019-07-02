using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using ticketApp.Models;

namespace ticketApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketSystemContext _context;

        public TicketsController(TicketSystemContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index(string searchString)
        {
            var defaultView = await _context.Tickets.Where(e => !e.IsArchived).ToListAsync();
            var items = from i in defaultView select i;
            items.OrderBy(i => i.DateSubmitted );
            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Title.Contains(searchString)
                                       || s.ClientName.Contains(searchString)
                                       || s.Description.Contains(searchString)
                                       || s.AppointedTo.Contains(searchString));
            }

            return View(defaultView);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            var ticketType = new Ticket
            {
                Type = "Bug",
                SprintList = "Low",
                Status = "Open"
            };
            return View(ticketType);
        }
        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateSubmitted,Deadline,Title,Email,ApplicationName,Description,Type,ClientName,SprintList,AppointedTo,Status,Attachments")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateSubmitted,Deadline,Title,Email,ApplicationName,Description,Type,ClientName,SprintList,AppointedTo,Status,Attachments")] Ticket ticket)
        {
            if (id != ticket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Archive/5
        public async Task<IActionResult> Archive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Archive/5
        [HttpPost, ActionName("Archive")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if(ticket.IsArchived == false)
            {
                ticket.IsArchived = true;
            } else
            {
                ticket.IsArchived = false;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ArchiveIndex(Ticket ticket, String searchString)
        {
            var ArchivedView = await _context.Tickets.Where(e => e.IsArchived).ToListAsync();
            var items = from i in ArchivedView select i;
            items.OrderBy(i => i.DateSubmitted);
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Title.Contains(searchString)
                                       || s.ClientName.Contains(searchString)
                                       || s.Description.Contains(searchString)
                                       || s.Type.Contains(searchString)
                                       || s.AppointedTo.Contains(searchString));
            }
            return View(ArchivedView);
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.ID == id);
        }
    }
}
