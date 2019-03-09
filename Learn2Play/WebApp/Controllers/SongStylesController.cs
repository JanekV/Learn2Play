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
/*
            var appDbContext = _context.SongStyles.Include(s => s.Song).Include(s => s.Style);
*/
            return View(await _uow.SongStyles.AllAsyncWithInclude());
        }

        // GET: SongStyles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var songStyle = await _context.SongStyles
                .Include(s => s.Song)
                .Include(s => s.Style)
                .FirstOrDefaultAsync(m => m.SongStyleId == id);*/
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
            /*ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author");
            ViewData["StyleId"] = new SelectList(_context.Styles, "StyleId", "Name");
            */
            return View();
        }

        // POST: SongStyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SongId,StyleId")] SongStyle songStyle)
        {
            if (ModelState.IsValid)
            {
                await _uow.SongStyles.AddAsync(songStyle);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songStyle.SongId);
            ViewData["StyleId"] = new SelectList(_context.Styles, "StyleId", "Name", songStyle.StyleId);
            */
            return View(songStyle);
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
            /*ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songStyle.SongId);
            ViewData["StyleId"] = new SelectList(_context.Styles, "StyleId", "Name", songStyle.StyleId);
            */
            return View(songStyle);
        }

        // POST: SongStyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SongId,StyleId")] SongStyle songStyle)
        {
            if (id != songStyle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.SongStyles.Update(songStyle);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songStyle.SongId);
            ViewData["StyleId"] = new SelectList(_context.Styles, "StyleId", "Name", songStyle.StyleId);
            */
            return View(songStyle);
        }

        // GET: SongStyles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var songStyle = await _context.SongStyles
                .Include(s => s.Song)
                .Include(s => s.Style)
                .FirstOrDefaultAsync(m => m.SongStyleId == id);*/
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
