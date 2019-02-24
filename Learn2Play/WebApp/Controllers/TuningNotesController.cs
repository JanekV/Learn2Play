using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Controllers
{
    public class TuningNotesController : Controller
    {
        private readonly AppDbContext _context;

        public TuningNotesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TuningNotes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TuningNotes.Include(t => t.Instrument).Include(t => t.Note);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TuningNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tuningNote = await _context.TuningNotes
                .Include(t => t.Instrument)
                .Include(t => t.Note)
                .FirstOrDefaultAsync(m => m.TuningNoteId == id);
            if (tuningNote == null)
            {
                return NotFound();
            }

            return View(tuningNote);
        }

        // GET: TuningNotes/Create
        public IActionResult Create()
        {
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name");
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name");
            return View();
        }

        // POST: TuningNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TuningNoteId,InstrumentId,NoteId,Name")] TuningNote tuningNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tuningNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", tuningNote.InstrumentId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", tuningNote.NoteId);
            return View(tuningNote);
        }

        // GET: TuningNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tuningNote = await _context.TuningNotes.FindAsync(id);
            if (tuningNote == null)
            {
                return NotFound();
            }
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", tuningNote.InstrumentId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", tuningNote.NoteId);
            return View(tuningNote);
        }

        // POST: TuningNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuningNoteId,InstrumentId,NoteId,Name")] TuningNote tuningNote)
        {
            if (id != tuningNote.TuningNoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tuningNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuningNoteExists(tuningNote.TuningNoteId))
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
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", tuningNote.InstrumentId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", tuningNote.NoteId);
            return View(tuningNote);
        }

        // GET: TuningNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tuningNote = await _context.TuningNotes
                .Include(t => t.Instrument)
                .Include(t => t.Note)
                .FirstOrDefaultAsync(m => m.TuningNoteId == id);
            if (tuningNote == null)
            {
                return NotFound();
            }

            return View(tuningNote);
        }

        // POST: TuningNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tuningNote = await _context.TuningNotes.FindAsync(id);
            _context.TuningNotes.Remove(tuningNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuningNoteExists(int id)
        {
            return _context.TuningNotes.Any(e => e.TuningNoteId == id);
        }
    }
}
