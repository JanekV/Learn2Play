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
    public class ChordNotesController : Controller
    {
        private readonly AppDbContext _context;

        public ChordNotesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ChordNotes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ChordNotes.Include(c => c.Chord).Include(c => c.Note);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ChordNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chordNote = await _context.ChordNotes
                .Include(c => c.Chord)
                .Include(c => c.Note)
                .FirstOrDefaultAsync(m => m.ChordNoteId == id);
            if (chordNote == null)
            {
                return NotFound();
            }

            return View(chordNote);
        }

        // GET: ChordNotes/Create
        public IActionResult Create()
        {
            ViewData["ChordId"] = new SelectList(_context.Set<Chord>(), "ChordId", "Name");
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name");
            return View();
        }

        // POST: ChordNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChordNoteId,ChordId,NoteId")] ChordNote chordNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chordNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChordId"] = new SelectList(_context.Set<Chord>(), "ChordId", "Name", chordNote.ChordId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", chordNote.NoteId);
            return View(chordNote);
        }

        // GET: ChordNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chordNote = await _context.ChordNotes.FindAsync(id);
            if (chordNote == null)
            {
                return NotFound();
            }
            ViewData["ChordId"] = new SelectList(_context.Set<Chord>(), "ChordId", "Name", chordNote.ChordId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", chordNote.NoteId);
            return View(chordNote);
        }

        // POST: ChordNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChordNoteId,ChordId,NoteId")] ChordNote chordNote)
        {
            if (id != chordNote.ChordNoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chordNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChordNoteExists(chordNote.ChordNoteId))
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
            ViewData["ChordId"] = new SelectList(_context.Set<Chord>(), "ChordId", "Name", chordNote.ChordId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", chordNote.NoteId);
            return View(chordNote);
        }

        // GET: ChordNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chordNote = await _context.ChordNotes
                .Include(c => c.Chord)
                .Include(c => c.Note)
                .FirstOrDefaultAsync(m => m.ChordNoteId == id);
            if (chordNote == null)
            {
                return NotFound();
            }

            return View(chordNote);
        }

        // POST: ChordNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chordNote = await _context.ChordNotes.FindAsync(id);
            _context.ChordNotes.Remove(chordNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChordNoteExists(int id)
        {
            return _context.ChordNotes.Any(e => e.ChordNoteId == id);
        }
    }
}
