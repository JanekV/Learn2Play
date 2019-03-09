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
    public class SongInFoldersController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public SongInFoldersController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: SongInFolders
        public async Task<IActionResult> Index()
        {
            /*
            var appDbContext = _context.SongInFolders.Include(s => s.Folder).Include(s => s.Song);
            return View(await appDbContext.ToListAsync());
            */
            return View(await _uow.SongInFolders.AllAsyncWithInclude());
        }

        // GET: SongInFolders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*
            var songInFolder = await _context.SongInFolders
                .Include(s => s.Folder)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.SongInFolderId == id);
            */
            var songInFolder = await _uow.SongInFolders.FindAsync(id);
            if (songInFolder == null)
            {
                return NotFound();
            }

            return View(songInFolder);
        }

        // GET: SongInFolders/Create
        public IActionResult Create()
        {
            /* :TODO fix this somehow pls future me
            ViewData["FolderId"] = new SelectList(_context.Folders, "FolderId", "Name");
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author");
            */
            return View();
        }

        // POST: SongInFolders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FolderId,SongId")] SongInFolder songInFolder)
        {
            if (ModelState.IsValid)
            {
                await _uow.SongInFolders.AddAsync(songInFolder);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /* :TODO fix this somehow pls future me
            ViewData["FolderId"] = new SelectList(_context.Folders, "FolderId", "Name", songInFolder.FolderId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songInFolder.SongId);
            */
            return View(songInFolder);
        }

        // GET: SongInFolders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songInFolder = await _uow.SongInFolders.FindAsync(id);
            if (songInFolder == null)
            {
                return NotFound();
            }
            /* :TODO fix this somehow pls future me
            ViewData["FolderId"] = new SelectList(_context.Folders, "FolderId", "Name", songInFolder.FolderId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songInFolder.SongId);
            */
            return View(songInFolder);
        }

        // POST: SongInFolders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FolderId,SongId")] SongInFolder songInFolder)
        {
            if (id != songInFolder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.SongInFolders.Update(songInFolder);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /* :TODO fix this somehow pls future me
            ViewData["FolderId"] = new SelectList(_context.Folders, "FolderId", "Name", songInFolder.FolderId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", songInFolder.SongId);
            */
            return View(songInFolder);
        }

        // GET: SongInFolders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*
            var songInFolder = await _context.SongInFolders
                .Include(s => s.Folder)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.SongInFolderId == id);
            */
            var songInFolder = await _uow.SongInFolders.FindAsync(id);
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
            _uow.SongInFolders.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
