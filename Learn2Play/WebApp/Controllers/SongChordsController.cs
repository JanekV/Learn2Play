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
            return View(await _uow.SongChords.AllAsyncWithInclude());
        }

        // GET: SongChords/Details/5
        public async Task<IActionResult> Details(int? id)
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

            return View(songChord);
        }

        // GET: SongChords/Create
        public async Task<IActionResult> Create()
        {
            var vm = new SongChordCreateEditViewModel();
            
            vm.ChordSelectList = new SelectList(
                await _uow.Chords.AllAsync(),
                nameof(Chord.Id), nameof(Chord.Name), vm.SongChord.ChordId);
            vm.SongSelectList = new SelectList(
                await _uow.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.SongChord.SongId);
            return View(vm);
        }

        // POST: SongChords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongChordCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.SongChords.AddAsync(vm.SongChord);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.ChordSelectList = new SelectList(
                await _uow.Chords.AllAsync(),
                nameof(Chord.Id), nameof(Chord.Name), vm.SongChord.ChordId);
            vm.SongSelectList = new SelectList(await _uow.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.SongChord.SongId);
            return View(vm);
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
            var vm = new SongChordCreateEditViewModel();
            vm.SongChord = songChord;
            vm.ChordSelectList = new SelectList(
                await _uow.Chords.AllAsync(),
                nameof(Chord.Id), nameof(Chord.Name), vm.SongChord.ChordId);
            vm.SongSelectList = new SelectList(await _uow.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.SongChord.SongId);
            return View(vm);
        }

        // POST: SongChords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SongChordCreateEditViewModel vm)
        {
            if (id != vm.SongChord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.SongChords.Update(vm.SongChord);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.ChordSelectList = new SelectList(
                await _uow.Chords.AllAsync(),
                nameof(Chord.Id), nameof(Chord.Name), vm.SongChord.ChordId);
            vm.SongSelectList = new SelectList(await _uow.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.SongChord.SongId);
            return View(vm);
        }

        // GET: SongChords/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
