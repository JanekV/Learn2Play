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
    public class SongStylesController : Controller
    {
        private readonly IAppBLL _bll;

        public SongStylesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: SongStyles
        public async Task<IActionResult> Index()
        {
            return View(await _bll.SongStyles.AllAsyncWithInclude());
        }

        // GET: SongStyles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var songStyle = await _bll.SongStyles.FindAsync(id);
            if (songStyle == null)
            {
                return NotFound();
            }

            return View(songStyle);
        }

        // GET: SongStyles/Create
        public async Task<IActionResult> Create()
        {
            var vm = new SongStyleCreateEditViewModel
            {
                SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                    nameof(Song.Id), nameof(Song.Author)),
                StyleSelectList = new SelectList(await _bll.Styles.AllAsync(),
                    nameof(Style.Id), nameof(Style.Name))
            };

            return View(vm);
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
                await _bll.SongStyles.AddAsync(vm.SongStyle);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author));
            vm.StyleSelectList = new SelectList(await _bll.Styles.AllAsync(),
                nameof(Style.Id), nameof(Style.Name));
            
            return View(vm);
        }

        // GET: SongStyles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songStyle = await _bll.SongStyles.FindAsync(id);
            if (songStyle == null)
            {
                return NotFound();
            }

            var vm = new SongStyleCreateEditViewModel();
            vm.SongStyle = songStyle;
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.SongStyle.SongId);
            vm.StyleSelectList = new SelectList(await _bll.Styles.AllAsync(),
                nameof(Style.Id), nameof(Style.Name), vm.SongStyle.StyleId);
            
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
                _bll.SongStyles.Update(vm.SongStyle);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.SongStyle.SongId);
            vm.StyleSelectList = new SelectList(await _bll.Styles.AllAsync(),
                nameof(Style.Id), nameof(Style.Name), vm.SongStyle.StyleId);
            
            return View(vm);
        }

        // GET: SongStyles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var songStyle = await _bll.SongStyles.FindAsync(id);
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
            _bll.SongStyles.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
