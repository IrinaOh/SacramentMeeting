using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class SpeakerAssignmentsController : Controller
    {
        private readonly SacramentMeetingPlannerContext _context;

        public SpeakerAssignmentsController(SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        // GET: SpeakerAssignments
        public async Task<IActionResult> Index(int?id)
        {
            ViewData["MeetingID"] = id;

            var sacramentMeetingPlannerContext = _context.SpeakerAssignment.Include(s => s.Meeting);
            return View(await sacramentMeetingPlannerContext.ToListAsync()); 
        }

        // GET: SpeakerAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakerAssignment = await _context.SpeakerAssignment
                .Include(s => s.Meeting)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (speakerAssignment == null)
            {
                return NotFound();
            }

            return View(speakerAssignment);
        }

        // GET: SpeakerAssignments/Create
        public IActionResult Create()
        {
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "Id", "Id");
            return View();
        }

        // POST: SpeakerAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MeetingID,SpeakerName")] SpeakerAssignment speakerAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speakerAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "Id", "Id", speakerAssignment.MeetingID);
            return View(speakerAssignment);
        }

        // GET: SpeakerAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakerAssignment = await _context.SpeakerAssignment.FindAsync(id);
            if (speakerAssignment == null)
            {
                return NotFound();
            }
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "Id", "Id", speakerAssignment.MeetingID);
            return View(speakerAssignment);
        }

        // POST: SpeakerAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MeetingID,SpeakerName")] SpeakerAssignment speakerAssignment)
        {
            if (id != speakerAssignment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speakerAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakerAssignmentExists(speakerAssignment.ID))
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
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "Id", "Id", speakerAssignment.MeetingID);
            return View(speakerAssignment);
        }

        // GET: SpeakerAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakerAssignment = await _context.SpeakerAssignment
                .Include(s => s.Meeting)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (speakerAssignment == null)
            {
                return NotFound();
            }

            return View(speakerAssignment);
        }

        // POST: SpeakerAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speakerAssignment = await _context.SpeakerAssignment.FindAsync(id);
            _context.SpeakerAssignment.Remove(speakerAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeakerAssignmentExists(int id)
        {
            return _context.SpeakerAssignment.Any(e => e.ID == id);
        }
    }
}
