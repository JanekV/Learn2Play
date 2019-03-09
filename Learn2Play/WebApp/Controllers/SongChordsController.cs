using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Controllers
{
    public class SongChordsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public SongChordsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: SongChords
        public async Task<IActionResult> Index()
        {
            /*
            var appDbContext = _context.SongChords.Include(s => s.Chord).Include(s => s.Song);
            return View(await appDbContext.ToListAsync());
            */
            return View(await _uow.SongChords.AllAsyncWithInclude());
        }

        // GET: SongChords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /* :TODO maybe is needed to include? 
            var songChord = await _context.SongChords
                .Include(s => s.Chord)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.SongChordId == id);
            */
            var songChord = await _uow.SongChords.FindAsync(id);
            if (songChord == null)
            {
                return NotFound();
            }

            return View(songChord);
        }

        // GET: SongChords/Create
        public IActionResult Create()
        {
            /* :TODO fix this somehow pls future me
            ViewData["ChordId"] = new SelectList(_context.Set<Chord>(), "ChordId", "Name");
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author");
            */
            return View();
        }

        // POST: SongChords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SongId,ChordId")] SongChord songChord)
        {
            if (ModelState.IsValid)
            {
                await _uow.SongChords.AddAsync(songChord);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /* :TODO fix this somehow pls future me
            ViewData["ChordId"] = new SelectList(_context.Set<Chord>(), "ChordId", "Name", songChord.ChordId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songChord.SongId);
            */
            return View(songChord);
        }

        // GET: SongChords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songChord = await _uow.SongChords.FindAsync(id);
            if (songChord == null)
            {
                return NotFound();
            }
            /* :TODO fix this somehow pls future me
            ViewData["ChordId"] = new SelectList(_context.Set<Chord>(), "ChordId", "Name", songChord.ChordId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songChord.SongId);
            */
            return View(songChord);
        }

        // POST: SongChords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SongId,ChordId")] SongChord songChord)
        {
            if (id != songChord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.SongChords.Update(songChord);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /* :TODO fix this somehow pls future me
            ViewData["ChordId"] = new SelectList(_context.Set<Chord>(), "ChordId", "Name", songChord.ChordId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songChord.SongId);
            */
            return View(songChord);
        }

        // GET: SongChords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /* :TODO maybe is needed to include? 
            var songChord = await _context.SongChords
                .Include(s => s.Chord)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.SongChordId == id);
            */
            var songChord = await _uow.SongChords.FindAsync(id);
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
            _uow.SongChords.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
