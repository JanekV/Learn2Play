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
    public class SongsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public SongsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            return View(await _uow.Songs.AllAsyncWithInclude());
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var song = await _uow.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Songs.AddAsync(vm.Song);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.SongKeySelectList = new SelectList(await _uow.SongKeys.AllAsyncWithInclude(),
                "SongKeyId", "Description", vm.Song.SongKeyId);
            return View(vm);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _uow.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            var vm = new SongCreateEditViewModel();
            vm.SongKeySelectList = new SelectList(await _uow.SongKeys.AllAsyncWithInclude(),
                "SongKeyId", "Description", vm.Song.SongKeyId);
            return View(vm);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SongCreateEditViewModel vm)
        {
            if (id != vm.Song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Songs.Update(vm.Song);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.SongKeySelectList = new SelectList(await _uow.SongKeys.AllAsyncWithInclude(),
                "SongKeyId", "Description", vm.Song.SongKeyId);
            return View(vm);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var song = await _uow.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Songs.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
