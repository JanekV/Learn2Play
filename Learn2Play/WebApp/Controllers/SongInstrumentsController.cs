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
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class SongInstrumentsController : Controller
    {
        private readonly IAppBLL _bll;

        public SongInstrumentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: SongInstruments
        public async Task<IActionResult> Index()
        {
            return View(await _bll.SongInstruments.AllAsyncWithInclude());
        }

        // GET: SongInstruments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var songInstrument = await _bll.SongInstruments.FindAsync(id);
            if (songInstrument == null)
            {
                return NotFound();
            }

            return View(songInstrument);
        }

        // GET: SongInstruments/Create
        public async Task<IActionResult> Create()
        {
            var vm = new SongInstrumentCreateEditViewModel();
            vm.InstrumentSelectList = new SelectList(
                await _bll.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name));
            vm.SongSelectList = new SelectList(
                await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Name));
           
            return View(vm);
        }

        // POST: SongInstruments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongInstrumentCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.SongInstruments.AddAsync(vm.SongInstrument);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.InstrumentSelectList = new SelectList(await _bll.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name), vm.SongInstrument.InstrumentId);
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Name), vm.SongInstrument.SongId);

            return View(vm);
        }

        // GET: SongInstruments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songInstrument = await _bll.SongInstruments.FindAsync(id);
            if (songInstrument == null)
            {
                return NotFound();
            }
            var vm = new SongInstrumentCreateEditViewModel();
            vm.SongInstrument = songInstrument;
            vm.InstrumentSelectList = new SelectList(await _bll.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name), vm.SongInstrument.InstrumentId);
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Name), vm.SongInstrument.SongId);
           
            return View(vm);
        }

        // POST: SongInstruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SongInstrumentCreateEditViewModel vm)
        {
            if (id != vm.SongInstrument.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.SongInstruments.Update(vm.SongInstrument);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.InstrumentSelectList = new SelectList(await _bll.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name), vm.SongInstrument.InstrumentId);
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Name), vm.SongInstrument.SongId);

            return View(vm);
        }

        // GET: SongInstruments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var songInstrument = await _bll.SongInstruments.FindAsync(id);
            if (songInstrument == null)
            {
                return NotFound();
            }

            return View(songInstrument);
        }

        // POST: SongInstruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.SongInstruments.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
