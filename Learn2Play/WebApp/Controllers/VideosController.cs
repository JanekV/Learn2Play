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
    public class VideosController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public VideosController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            //var appDbContext = _context.Videos.Include(v => v.Song);
            return View(await _uow.Videos.AllAsyncWithInclude());
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var video = await _context.Videos
                .Include(v => v.Song)
                .FirstOrDefaultAsync(m => m.VideoId == id);*/
            var video = await _uow.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            //ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author");
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,YouTubeUrl,AuthorChannelLink,LocalPath,SongId")] Video video)
        {
            if (ModelState.IsValid)
            {
                await _uow.Videos.AddAsync(video);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", video.SongId);
            return View(video);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _uow.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            //ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", video.SongId);
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,YouTubeUrl,AuthorChannelLink,LocalPath,SongId")] Video video)
        {
            if (id != video.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Videos.Update(video);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "Author", video.SongId);
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var video = await _context.Videos
                .Include(v => v.Song)
                .FirstOrDefaultAsync(m => m.VideoId == id);*/
            var video = await _uow.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Videos.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
