using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using WebApp.ViewModels;

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
            return View(await _uow.TuningNotes.AllAsyncWithInclude());
        }

        // GET: TuningNotes/Details/5
        public async Task<IActionResult> Details(int? id)
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

            return View(tuningNote);
        }

        // GET: TuningNotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TuningNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TuningNoteCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.TuningNotes.AddAsync(vm.TuningNote);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.InstrumentSelectList = new SelectList(await _uow.Instruments.AllAsync(),
                "InstrumentId", "Name", vm.TuningNote.InstrumentId);
            vm.NoteSelectList = new SelectList(await _uow.Notes.AllAsync(),
                "NoteId", "Name", vm.TuningNote.NoteId);
           
            return View(vm);
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
            var vm = new TuningNoteCreateEditViewModel();
            vm.InstrumentSelectList = new SelectList(await _uow.Instruments.AllAsync(),
                "InstrumentId", "Name", vm.TuningNote.InstrumentId);
            vm.NoteSelectList = new SelectList(await _uow.Notes.AllAsync(),
                "NoteId", "Name", vm.TuningNote.NoteId);
           
            return View(vm);
        }

        // POST: TuningNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TuningNoteCreateEditViewModel vm)
        {
            if (id != vm.TuningNote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.TuningNotes.Update(vm.TuningNote);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.InstrumentSelectList = new SelectList(await _uow.Instruments.AllAsync(),
                "InstrumentId", "Name", vm.TuningNote.InstrumentId);
            vm.NoteSelectList = new SelectList(await _uow.Notes.AllAsync(),
                "NoteId", "Name", vm.TuningNote.NoteId);
           
            return View(vm);
        }

        // GET: TuningNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
