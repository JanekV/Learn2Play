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
    public class SongChordsController : Controller
    {
        private readonly AppDbContext _context;

        public SongChordsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SongChords
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SongChords.Include(s => s.Chord).Include(s => s.Song);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SongChords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songChord = await _context.SongChords
                .Include(s => s.Chord)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.SongChordId == id);
            if (songChord == null)
            {
                return NotFound();
            }

            return View(songChord);
        }

        // GET: SongChords/Create
        public IActionResult Create()
        {
            ViewData["ChordId"] = new SelectList(_context.Set<Chord>(), "ChordId", "Name");
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author");
            return View();
        }

        // POST: SongChords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongChordId,SongId,ChordId")] SongChord songChord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songChord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChordId"] = new SelectList(_context.Set<Chord>(), "ChordId", "Name", songChord.ChordId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songChord.SongId);
            return View(songChord);
        }

        // GET: SongChords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songChord = await _context.SongChords.FindAsync(id);
            if (songChord == null)
            {
                return NotFound();
            }
            ViewData["ChordId"] = new SelectList(_context.Set<Chord>(), "ChordId", "Name", songChord.ChordId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songChord.SongId);
            return View(songChord);
        }

        // POST: SongChords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongChordId,SongId,ChordId")] SongChord songChord)
        {
            if (id != songChord.SongChordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songChord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongChordExists(songChord.SongChordId))
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
            ViewData["ChordId"] = new SelectList(_context.Set<Chord>(), "ChordId", "Name", songChord.ChordId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songChord.SongId);
            return View(songChord);
        }

        // GET: SongChords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songChord = await _context.SongChords
                .Include(s => s.Chord)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.SongChordId == id);
            if (songChord == null)
            {
                return NotFound();
            }

            return View(songChord);
        }

        // POST: SongChords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songChord = await _context.SongChords.FindAsync(id);
            _context.SongChords.Remove(songChord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongChordExists(int id)
        {
            return _context.SongChords.Any(e => e.SongChordId == id);
        }
    }
}
