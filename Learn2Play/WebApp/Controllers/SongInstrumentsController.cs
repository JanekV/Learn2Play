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
    public class SongInstrumentsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public SongInstrumentsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: SongInstruments
        public async Task<IActionResult> Index()
        {
/*
            var appDbContext = _context.SongInstruments.Include(s => s.Instrument).Include(s => s.Song);
*/
            return View(await _uow.SongInstruments.AllAsyncWithInclude());
        }

        // GET: SongInstruments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var songInstrument = await _context.SongInstruments
                .Include(s => s.Instrument)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.SongInstrumentId == id);*/
            var songInstrument = await _uow.SongInstruments.FindAsync(id);
            if (songInstrument == null)
            {
                return NotFound();
            }

            return View(songInstrument);
        }

        // GET: SongInstruments/Create
        public IActionResult Create()
        {
            /* :TODO fix
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name");
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author");
            */
            return View();
        }

        // POST: SongInstruments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SongId,InstrumentId")] SongInstrument songInstrument)
        {
            if (ModelState.IsValid)
            {
                await _uow.SongInstruments.AddAsync(songInstrument);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", songInstrument.InstrumentId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songInstrument.SongId);
            */
            return View(songInstrument);
        }

        // GET: SongInstruments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songInstrument = await _uow.SongInstruments.FindAsync(id);
            if (songInstrument == null)
            {
                return NotFound();
            }
            /*
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", songInstrument.InstrumentId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songInstrument.SongId);
            */
            return View(songInstrument);
        }

        // POST: SongInstruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SongId,InstrumentId")] SongInstrument songInstrument)
        {
            if (id != songInstrument.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.SongInstruments.Update(songInstrument);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", songInstrument.InstrumentId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songInstrument.SongId);
            */
            return View(songInstrument);
        }

        // GET: SongInstruments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var songInstrument = await _context.SongInstruments
                .Include(s => s.Instrument)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.SongInstrumentId == id);*/
            var songInstrument = await _uow.SongInstruments.FindAsync(id);
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
            _uow.SongInstruments.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
