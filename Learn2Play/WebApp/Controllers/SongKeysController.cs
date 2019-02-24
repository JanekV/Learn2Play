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
    public class SongKeysController : Controller
    {
        private readonly AppDbContext _context;

        public SongKeysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SongKeys
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SongKeys.Include(s => s.Note);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SongKeys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songKey = await _context.SongKeys
                .Include(s => s.Note)
                .FirstOrDefaultAsync(m => m.SongKeyId == id);
            if (songKey == null)
            {
                return NotFound();
            }

            return View(songKey);
        }

        // GET: SongKeys/Create
        public IActionResult Create()
        {
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name");
            return View();
        }

        // POST: SongKeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongKeyId,Description,NoteId")] SongKey songKey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songKey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", songKey.NoteId);
            return View(songKey);
        }

        // GET: SongKeys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songKey = await _context.SongKeys.FindAsync(id);
            if (songKey == null)
            {
                return NotFound();
            }
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", songKey.NoteId);
            return View(songKey);
        }

        // POST: SongKeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongKeyId,Description,NoteId")] SongKey songKey)
        {
            if (id != songKey.SongKeyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songKey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongKeyExists(songKey.SongKeyId))
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
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", songKey.NoteId);
            return View(songKey);
        }

        // GET: SongKeys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songKey = await _context.SongKeys
                .Include(s => s.Note)
                .FirstOrDefaultAsync(m => m.SongKeyId == id);
            if (songKey == null)
            {
                return NotFound();
            }

            return View(songKey);
        }

        // POST: SongKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songKey = await _context.SongKeys.FindAsync(id);
            _context.SongKeys.Remove(songKey);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongKeyExists(int id)
        {
            return _context.SongKeys.Any(e => e.SongKeyId == id);
        }
    }
}
