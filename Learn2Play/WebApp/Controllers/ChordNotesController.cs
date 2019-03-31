using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using WebApp.ViewModels;

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
        public async Task<IActionResult> Create(ChordNoteCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.ChordNotes.AddAsync(vm.ChordNote);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
            return View(vm);
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

            var vm = new ChordNoteCreateEditViewModel();
            vm.ChordSelectList = new SelectList(
                await _uow.BaseRepository<Chord>().AllAsync(),
                "ChordId", "Name", chordNote.ChordId);
            
            vm.NoteSelectList = new SelectList(
                await _uow.Notes.AllAsync(), "NoteId", "Name", chordNote.NoteId);
            
            return View(vm);
        }

        // POST: ChordNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ChordNoteCreateEditViewModel vm)
        {
            if (id != vm.ChordNote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.ChordNotes.Update(vm.ChordNote);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            vm.ChordSelectList = new SelectList(
                await _uow.BaseRepository<Chord>().AllAsync(),
                "ChordId", "Name", vm.ChordNote.ChordId);
            
            vm.NoteSelectList = new SelectList(
                await _uow.Notes.AllAsync(),
                "NoteId", "Name", vm.ChordNote.NoteId);

            return View(vm);
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
