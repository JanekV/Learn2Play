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
    public class TuningNotesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public TuningNotesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: TuningNotes
        public async Task<IActionResult> Index()
        {
/*
            var appDbContext = _context.TuningNotes.Include(t => t.Instrument).Include(t => t.Note);
*/
            return View(await _uow.TuningNotes.AllAsyncWithInclude());
        }

        // GET: TuningNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var tuningNote = await _context.TuningNotes
                .Include(t => t.Instrument)
                .Include(t => t.Note)
                .FirstOrDefaultAsync(m => m.TuningNoteId == id);*/
            var tuningNote = await _uow.TuningNotes.FindAsync(id);
            if (tuningNote == null)
            {
                return NotFound();
            }

            return View(tuningNote);
        }

        // GET: TuningNotes/Create
        public IActionResult Create()
        {
            /*ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name");
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name");
            */
            return View();
        }

        // POST: TuningNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InstrumentId,NoteId,Name")] TuningNote tuningNote)
        {
            if (ModelState.IsValid)
            {
                await _uow.TuningNotes.AddAsync(tuningNote);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", tuningNote.InstrumentId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", tuningNote.NoteId);
            */
            return View(tuningNote);
        }

        // GET: TuningNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tuningNote = await _uow.TuningNotes.FindAsync(id);
            if (tuningNote == null)
            {
                return NotFound();
            }
            /*ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", tuningNote.InstrumentId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", tuningNote.NoteId);
            */
            return View(tuningNote);
        }

        // POST: TuningNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InstrumentId,NoteId,Name")] TuningNote tuningNote)
        {
            if (id != tuningNote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.TuningNotes.Update(tuningNote);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", tuningNote.InstrumentId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", tuningNote.NoteId);
            */
            return View(tuningNote);
        }

        // GET: TuningNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var tuningNote = await _context.TuningNotes
                .Include(t => t.Instrument)
                .Include(t => t.Note)
                .FirstOrDefaultAsync(m => m.TuningNoteId == id);*/
            var tuningNote = await _uow.TuningNotes.FindAsync(id);
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
            _uow.TuningNotes.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
