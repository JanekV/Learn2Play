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
/*
            var appDbContext = _context.SongKeys.Include(s => s.Note);
*/
            return View(await _uow.SongKeys.AllAsyncWithInclude());
        }

        // GET: SongKeys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var songKey = await _context.SongKeys
                .Include(s => s.Note)
                .FirstOrDefaultAsync(m => m.SongKeyId == id);*/
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
/*
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name");
*/
            return View();
        }

        // POST: SongKeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,NoteId")] SongKey songKey)
        {
            if (ModelState.IsValid)
            {
                await _uow.SongKeys.AddAsync(songKey);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
/*
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", songKey.NoteId);
*/
            return View(songKey);
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
/*
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", songKey.NoteId);
*/
            return View(songKey);
        }

        // POST: SongKeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,NoteId")] SongKey songKey)
        {
            if (id != songKey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.SongKeys.Update(songKey);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
/*
            ViewData["NoteId"] = new SelectList(_context.Notes, "NoteId", "Name", songKey.NoteId);
*/
            return View(songKey);
        }

        // GET: SongKeys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var songKey = await _context.SongKeys
                .Include(s => s.Note)
                .FirstOrDefaultAsync(m => m.SongKeyId == id);*/
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
