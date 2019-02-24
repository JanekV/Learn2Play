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
    public class UserInstrumentsController : Controller
    {
        private readonly AppDbContext _context;

        public UserInstrumentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserInstruments
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UserInstruments.Include(u => u.AppUser).Include(u => u.Instrument);
            return View(await appDbContext.ToListAsync());
        }

        // GET: UserInstruments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInstrument = await _context.UserInstruments
                .Include(u => u.AppUser)
                .Include(u => u.Instrument)
                .FirstOrDefaultAsync(m => m.UserInstrumentId == id);
            if (userInstrument == null)
            {
                return NotFound();
            }

            return View(userInstrument);
        }

        // GET: UserInstruments/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name");
            return View();
        }

        // POST: UserInstruments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserInstrumentId,AppUserId,InstrumentId,Comment")] UserInstrument userInstrument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userInstrument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", userInstrument.AppUserId);
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", userInstrument.InstrumentId);
            return View(userInstrument);
        }

        // GET: UserInstruments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInstrument = await _context.UserInstruments.FindAsync(id);
            if (userInstrument == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", userInstrument.AppUserId);
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", userInstrument.InstrumentId);
            return View(userInstrument);
        }

        // POST: UserInstruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserInstrumentId,AppUserId,InstrumentId,Comment")] UserInstrument userInstrument)
        {
            if (id != userInstrument.UserInstrumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInstrument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInstrumentExists(userInstrument.UserInstrumentId))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", userInstrument.AppUserId);
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", userInstrument.InstrumentId);
            return View(userInstrument);
        }

        // GET: UserInstruments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInstrument = await _context.UserInstruments
                .Include(u => u.AppUser)
                .Include(u => u.Instrument)
                .FirstOrDefaultAsync(m => m.UserInstrumentId == id);
            if (userInstrument == null)
            {
                return NotFound();
            }

            return View(userInstrument);
        }

        // POST: UserInstruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userInstrument = await _context.UserInstruments.FindAsync(id);
            _context.UserInstruments.Remove(userInstrument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInstrumentExists(int id)
        {
            return _context.UserInstruments.Any(e => e.UserInstrumentId == id);
        }
    }
}
