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
    public class SongStylesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public SongStylesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: SongStyles
        public async Task<IActionResult> Index()
        {
            return View(await _uow.SongStyles.AllAsyncWithInclude());
        }

        // GET: SongStyles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var songStyle = await _uow.SongStyles.FindAsync(id);
            if (songStyle == null)
            {
                return NotFound();
            }

            return View(songStyle);
        }

        // GET: SongStyles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SongStyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongStyleCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.SongStyles.AddAsync(vm.SongStyle);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.SongSelectList = new SelectList(await _uow.SongStyles.AllAsyncWithInclude(),
                "SongId", "Author", vm.SongStyle.SongId);
            vm.StyleSelectList = new SelectList(await _uow.Styles.AllAsync(),
                "StyleId", "Name", vm.SongStyle.StyleId);
            
            return View(vm);
        }

        // GET: SongStyles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songStyle = await _uow.SongStyles.FindAsync(id);
            if (songStyle == null)
            {
                return NotFound();
            }

            var vm = new SongStyleCreateEditViewModel();
            vm.SongSelectList = new SelectList(await _uow.SongStyles.AllAsyncWithInclude(),
                "SongId", "Author", vm.SongStyle.SongId);
            vm.StyleSelectList = new SelectList(await _uow.Styles.AllAsync(),
                "StyleId", "Name", vm.SongStyle.StyleId);
            
            return View(vm);
        }

        // POST: SongStyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SongStyleCreateEditViewModel vm)
        {
            if (id != vm.SongStyle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.SongStyles.Update(vm.SongStyle);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.SongSelectList = new SelectList(await _uow.SongStyles.AllAsyncWithInclude(),
                "SongId", "Author", vm.SongStyle.SongId);
            vm.StyleSelectList = new SelectList(await _uow.Styles.AllAsync(),
                "StyleId", "Name", vm.SongStyle.StyleId);
            
            return View(vm);
        }

        // GET: SongStyles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var songStyle = await _uow.SongStyles.FindAsync(id);
            if (songStyle == null)
            {
                return NotFound();
            }

            return View(songStyle);
        }

        // POST: SongStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.SongStyles.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
