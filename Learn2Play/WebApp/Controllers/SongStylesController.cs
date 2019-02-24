using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Controllers
{
    public class SongStylesController : Controller
    {
        private readonly AppDbContext _context;

        public SongStylesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SongStyles
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SongStyles.Include(s => s.Song).Include(s => s.Style);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SongStyles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songStyle = await _context.SongStyles
                .Include(s => s.Song)
                .Include(s => s.Style)
                .FirstOrDefaultAsync(m => m.SongStyleId == id);
            if (songStyle == null)
            {
                return NotFound();
            }

            return View(songStyle);
        }

        // GET: SongStyles/Create
        public IActionResult Create()
        {
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author");
            ViewData["StyleId"] = new SelectList(_context.Styles, "StyleId", "Name");
            return View();
        }

        // POST: SongStyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongStyleId,SongId,StyleId")] SongStyle songStyle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songStyle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songStyle.SongId);
            ViewData["StyleId"] = new SelectList(_context.Styles, "StyleId", "Name", songStyle.StyleId);
            return View(songStyle);
        }

        // GET: SongStyles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songStyle = await _context.SongStyles.FindAsync(id);
            if (songStyle == null)
            {
                return NotFound();
            }
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songStyle.SongId);
            ViewData["StyleId"] = new SelectList(_context.Styles, "StyleId", "Name", songStyle.StyleId);
            return View(songStyle);
        }

        // POST: SongStyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongStyleId,SongId,StyleId")] SongStyle songStyle)
        {
            if (id != songStyle.SongStyleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songStyle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongStyleExists(songStyle.SongStyleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songStyle.SongId);
            ViewData["StyleId"] = new SelectList(_context.Styles, "StyleId", "Name", songStyle.StyleId);
            return View(songStyle);
        }

        // GET: SongStyles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songStyle = await _context.SongStyles
                .Include(s => s.Song)
                .Include(s => s.Style)
                .FirstOrDefaultAsync(m => m.SongStyleId == id);
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
            var songStyle = await _context.SongStyles.FindAsync(id);
            _context.SongStyles.Remove(songStyle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongStyleExists(int id)
        {
            return _context.SongStyles.Any(e => e.SongStyleId == id);
        }
    }
}
