using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;
using Domain.Identity;

namespace WebApp.Controllers
{
    public class ChordNotesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ChordNotesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: ChordNotes
        public async Task<IActionResult> Index()
        {
            //Chord notes with included Chord and Note Entities
            /*
            var appDbContext = _context.ChordNotes.Include(c => c.Chord).Include(c => c.Note);
            return View(await appDbContext.ToListAsync());
            */
            return View(await _uow.ChordNotes.AllAsyncWithInclude());
        }

        // GET: ChordNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var chordNote = await _uow.ChordNotes.FindAsync(id);
            if (chordNote == null)
            {
                return NotFound();
            }

            return View(chordNote);
        }

        // GET: ChordNotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChordNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChordId,NoteId")] ChordNote chordNote)
        {
            if (ModelState.IsValid)
            {
                await _uow.ChordNotes.AddAsync(chordNote);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
            return View(chordNote);
        }

        // GET: ChordNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chordNote = await _uow.ChordNotes.FindAsync(id);
            if (chordNote == null)
            {
                return NotFound();
            }
            
            ViewData["ChordId"] = new SelectList(
                await _uow.BaseRepository<Chord>().AllAsync(),
                "ChordId", "Name", chordNote.ChordId);
            
            ViewData["NoteId"] = new SelectList(
                _uow.Notes.AllAsync().Result, "NoteId", "Name", chordNote.NoteId);
            
            return View(chordNote);
        }

        // POST: ChordNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ChordId,NoteId")] ChordNote chordNote)
        {
            if (id != chordNote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.ChordNotes.Update(chordNote);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            ViewData["ChordId"] = new SelectList(
                await _uow.BaseRepository<Chord>().AllAsync(),
                "ChordId", "Name", chordNote.ChordId);
            
            ViewData["NoteId"] = new SelectList(
                _uow.Notes.AllAsync().Result,
                "NoteId", "Name", chordNote.NoteId);

            return View(chordNote);
        }

        // GET: ChordNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chordNote = await _uow.ChordNotes.FindAsync(id);
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
            _uow.ChordNotes.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
