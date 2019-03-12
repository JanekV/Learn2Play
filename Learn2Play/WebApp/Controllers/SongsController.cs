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
            //var appDbContext = _context.Songs.Include(s => s.Key);
            return View(await _uow.Songs.AllAsyncWithInclude());
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var song = await _context.Songs
                .Include(s => s.Key)
                .FirstOrDefaultAsync(m => m.SongId == id);*/
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
            //ViewData["SongKeyId"] = new SelectList(_context.SongKeys, "SongKeyId", "Description");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Author,SpotifyLink,Description,SongKeyId")] Song song)
        {
            if (ModelState.IsValid)
            {
                await _uow.Songs.AddAsync(song);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["SongKeyId"] = new SelectList(_context.SongKeys, "SongKeyId", "Description", song.SongKeyId);
            return View(song);
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
            //ViewData["SongKeyId"] = new SelectList(_context.SongKeys, "SongKeyId", "Description", song.SongKeyId);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Author,SpotifyLink,Description,SongKeyId")] Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Songs.Update(song);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["SongKeyId"] = new SelectList(_context.SongKeys, "SongKeyId", "Description", song.SongKeyId);
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var song = await _context.Songs
                .Include(s => s.Key)
                .FirstOrDefaultAsync(m => m.SongId == id);*/
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
