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
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class SongKeysController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public SongKeysController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: SongKeys
        public async Task<IActionResult> Index()
        {
            return View(await _uow.SongKeys.AllAsyncWithInclude());
        }

        // GET: SongKeys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var songKey = await _uow.SongKeys.FindAsync(id);
            if (songKey == null)
            {
                return NotFound();
            }

            return View(songKey);
        }

        // GET: SongKeys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SongKeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongKeyCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.SongKeys.AddAsync(vm.SongKey);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            vm.NoteSelectList = new SelectList(await _uow.Notes.AllAsync(),
                "NoteId", "Name", vm.SongKey.NoteId);
            return View(vm);
        }

        // GET: SongKeys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songKey = await _uow.SongKeys.FindAsync(id);
            if (songKey == null)
            {
                return NotFound();
            }
            var vm = new SongKeyCreateEditViewModel();
            vm.NoteSelectList = new SelectList(await _uow.Notes.AllAsync(),
                "NoteId", "Name", vm.SongKey.NoteId);
            return View(vm);
        }

        // POST: SongKeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SongKeyCreateEditViewModel vm)
        {
            if (id != vm.SongKey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.SongKeys.Update(vm.SongKey);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.NoteSelectList = new SelectList(await _uow.Notes.AllAsync(),
                "NoteId", "Name", vm.SongKey.NoteId);
            return View(vm);
        }

        // GET: SongKeys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var songKey = await _uow.SongKeys.FindAsync(id);
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
            _uow.SongKeys.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
