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
    public class TabsController : Controller
    {
        private readonly AppDbContext _context;

        public TabsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tabs
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Tabs.Include(t => t.Video);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Tabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tab = await _context.Tabs
                .Include(t => t.Video)
                .FirstOrDefaultAsync(m => m.TabId == id);
            if (tab == null)
            {
                return NotFound();
            }

            return View(tab);
        }

        // GET: Tabs/Create
        public IActionResult Create()
        {
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "AuthorChannelLink");
            return View();
        }

        // POST: Tabs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TabId,SongPart,StrummingPattern,PicturePath,Link,Author,VideoId")] Tab tab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "AuthorChannelLink", tab.VideoId);
            return View(tab);
        }

        // GET: Tabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tab = await _context.Tabs.FindAsync(id);
            if (tab == null)
            {
                return NotFound();
            }
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "AuthorChannelLink", tab.VideoId);
            return View(tab);
        }

        // POST: Tabs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TabId,SongPart,StrummingPattern,PicturePath,Link,Author,VideoId")] Tab tab)
        {
            if (id != tab.TabId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabExists(tab.TabId))
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
            ViewData["VideoId"] = new SelectList(_context.Videos, "VideoId", "AuthorChannelLink", tab.VideoId);
            return View(tab);
        }

        // GET: Tabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tab = await _context.Tabs
                .Include(t => t.Video)
                .FirstOrDefaultAsync(m => m.TabId == id);
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
            var tab = await _context.Tabs.FindAsync(id);
            _context.Tabs.Remove(tab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabExists(int id)
        {
            return _context.Tabs.Any(e => e.TabId == id);
        }
    }
}
