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
    public class SongInFoldersController : Controller
    {
        private readonly AppDbContext _context;

        public SongInFoldersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SongInFolders
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SongInFolders.Include(s => s.Folder).Include(s => s.Song);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SongInFolders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songInFolder = await _context.SongInFolders
                .Include(s => s.Folder)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.SongInFolderId == id);
            if (songInFolder == null)
            {
                return NotFound();
            }

            return View(songInFolder);
        }

        // GET: SongInFolders/Create
        public IActionResult Create()
        {
            ViewData["FolderId"] = new SelectList(_context.Folders, "FolderId", "Name");
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author");
            return View();
        }

        // POST: SongInFolders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongInFolderId,FolderId,SongId")] SongInFolder songInFolder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songInFolder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FolderId"] = new SelectList(_context.Folders, "FolderId", "Name", songInFolder.FolderId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songInFolder.SongId);
            return View(songInFolder);
        }

        // GET: SongInFolders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songInFolder = await _context.SongInFolders.FindAsync(id);
            if (songInFolder == null)
            {
                return NotFound();
            }
            ViewData["FolderId"] = new SelectList(_context.Folders, "FolderId", "Name", songInFolder.FolderId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songInFolder.SongId);
            return View(songInFolder);
        }

        // POST: SongInFolders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongInFolderId,FolderId,SongId")] SongInFolder songInFolder)
        {
            if (id != songInFolder.SongInFolderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songInFolder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongInFolderExists(songInFolder.SongInFolderId))
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
            ViewData["FolderId"] = new SelectList(_context.Folders, "FolderId", "Name", songInFolder.FolderId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songInFolder.SongId);
            return View(songInFolder);
        }

        // GET: SongInFolders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songInFolder = await _context.SongInFolders
                .Include(s => s.Folder)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.SongInFolderId == id);
            if (songInFolder == null)
            {
                return NotFound();
            }

            return View(songInFolder);
        }

        // POST: SongInFolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songInFolder = await _context.SongInFolders.FindAsync(id);
            _context.SongInFolders.Remove(songInFolder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongInFolderExists(int id)
        {
            return _context.SongInFolders.Any(e => e.SongInFolderId == id);
        }
    }
}
