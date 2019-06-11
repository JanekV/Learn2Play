using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize(Roles = "DbAdmin")]
    public class TuningNotesController : Controller
    {
        private readonly IAppBLL _bll;

        public TuningNotesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: TuningNotes
        public async Task<IActionResult> Index()
        {
            return View(await _bll.TuningNotes.AllAsyncWithInclude());
        }

        // GET: TuningNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tuningNote = await _bll.TuningNotes.FindAsync(id);
            if (tuningNote == null)
            {
                return NotFound();
            }

            return View(tuningNote);
        }

        // GET: TuningNotes/Create
        public async Task<IActionResult> Create()
        {
            var vm = new TuningNoteCreateEditViewModel();
            vm.InstrumentSelectList = new SelectList(await _bll.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name));
            vm.NoteSelectList = new SelectList(await _bll.Notes.AllAsync(),
                nameof(Note.Id), nameof(Note.Name));
           
            return View(vm);
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
                await _bll.TuningNotes.AddAsync(vm.TuningNote);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.InstrumentSelectList = new SelectList(await _bll.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name));
            vm.NoteSelectList = new SelectList(await _bll.Notes.AllAsync(),
                nameof(Note.Id), nameof(Note.Name));
           
            return View(vm);
        }

        // GET: TuningNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tuningNote = await _bll.TuningNotes.FindAsync(id);
            if (tuningNote == null)
            {
                return NotFound();
            }
            var vm = new TuningNoteCreateEditViewModel();
            vm.TuningNote = tuningNote;
            vm.InstrumentSelectList = new SelectList(await _bll.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name), vm.TuningNote.InstrumentId);
            vm.NoteSelectList = new SelectList(await _bll.Notes.AllAsync(),
                nameof(Note.Id), nameof(Note.Name), vm.TuningNote.NoteId);
           
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
                _bll.TuningNotes.Update(vm.TuningNote);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.InstrumentSelectList = new SelectList(await _bll.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name), vm.TuningNote.InstrumentId);
            vm.NoteSelectList = new SelectList(await _bll.Notes.AllAsync(),
                nameof(Note.Id), nameof(Note.Name), vm.TuningNote.NoteId);
           
            return View(vm);
        }

        // GET: TuningNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tuningNote = await _bll.TuningNotes.FindAsync(id);
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
            _bll.TuningNotes.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
