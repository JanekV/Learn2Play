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
    public class TabsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public TabsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Tabs
        public async Task<IActionResult> Index()
        {
            //var appDbContext = _context.Tabs.Include(t => t.Video);
            return View(await _uow.Tabs.AllAsyncWithInclude());
        }

        // GET: Tabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var tab = await _context.Tabs
                .Include(t => t.Video)
                .FirstOrDefaultAsync(m => m.TabId == id);*/
            var tab = await _uow.Tabs.FindAsync(id);
            if (tab == null)
            {
                return NotFound();
            }

            return View(tab);
        }

        // GET: Tabs/Create
        public IActionResult Create()
        {
            //ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "AuthorChannelLink");
            return View();
        }

        // POST: Tabs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SongPart,StrummingPattern,PicturePath,Link,Author,VideoId")] Tab tab)
        {
            if (ModelState.IsValid)
            {
                await _uow.Tabs.AddAsync(tab);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "AuthorChannelLink", tab.VideoId);
            return View(tab);
        }

        // GET: Tabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tab = await _uow.Tabs.FindAsync(id);
            if (tab == null)
            {
                return NotFound();
            }
           // ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "AuthorChannelLink", tab.VideoId);
            return View(tab);
        }

        // POST: Tabs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SongPart,StrummingPattern,PicturePath,Link,Author,VideoId")] Tab tab)
        {
            if (id != tab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Tabs.Update(tab);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           // ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "AuthorChannelLink", tab.VideoId);
            return View(tab);
        }

        // GET: Tabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var tab = await _context.Tabs
                .Include(t => t.Video)
                .FirstOrDefaultAsync(m => m.TabId == id);*/
            var tab = await _uow.Tabs.FindAsync(id);
            if (tab == null)
            {
                return NotFound();
            }

            return View(tab);
        }

        // POST: Tabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Tabs.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
