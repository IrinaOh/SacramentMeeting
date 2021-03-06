﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly SacramentMeetingPlannerContext _context;

        public SpeakersController(SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        // GET: Speakers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Speaker.ToListAsync());
        }

        // GET: Speakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker
                .FirstOrDefaultAsync(m => m.SpeakerID == id);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // GET: Speakers/Create
        public IActionResult Create(int? id)
        {
            ViewData["MeetingID"] = id;
            return View();
        }

        // POST: Speakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpeakerID,MeetingID,SpeakerName,Topic")] Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speaker);
                await _context.SaveChangesAsync();
                //return back to the details page and show the list of all speakers assigned to this meeeting
                return RedirectToAction("Details", "Meetings", new { id = speaker.MeetingID });
            }

            return RedirectToAction("Details", "Meetings", new { id = speaker.MeetingID });
        }

        // GET: Speakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker.FindAsync(id);
            if (speaker == null)
            {
                return NotFound();
            }

            ViewData["MeetingID"] = speaker.MeetingID;
           
            return View(speaker);
        }

        // POST: Speakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpeakerID,MeetingID,SpeakerName,Topic")] Speaker speaker)
        {
            if (id != speaker.SpeakerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakerExists(speaker.SpeakerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction("Details", "Meetings", new { id = speaker.MeetingID });
            }
            ViewData["MeetingID"] = speaker.MeetingID;
            return RedirectToAction("Details", "Meetings", new { id = speaker.MeetingID });
        }

        // GET: Speakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker
                .FirstOrDefaultAsync(m => m.SpeakerID == id);
            if (speaker == null)
            {
                return NotFound();
            }

            //ViewData["MeetingID"] = new SelectList(_context.Meeting, "MeetingID", "MeetingID", speaker.MeetingID);
            //return View(speaker);
            ViewData["MeetingID"] = speaker.MeetingID;
            return RedirectToAction("Details", "Meetings", new { id = speaker.MeetingID });

        }

        // POST: Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speaker = await _context.Speaker.FindAsync(id);
            _context.Speaker.Remove(speaker);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            //ViewData["MeetingID"] = new SelectList(_context.Meeting, "MeetingID", "MeetingID", speaker.MeetingID);
            ViewData["MeetingID"] = speaker.MeetingID;
            return RedirectToAction("Details", "Meetings", new { id = speaker.MeetingID });
        }

        private bool SpeakerExists(int id)
        {
            return _context.Speaker.Any(e => e.SpeakerID == id);
        }
    }
}
