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
using Domain.Identity;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class UserInstrumentsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public UserInstrumentsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: UserInstruments
        public async Task<IActionResult> Index()
        {
            return View(await _uow.UserInstruments.AllAsyncWithInclude());
        }

        // GET: UserInstruments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userInstrument = await _uow.UserInstruments.FindAsync(id);
            if (userInstrument == null)
            {
                return NotFound();
            }

            return View(userInstrument);
        }

        // GET: UserInstruments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserInstruments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserInstrumentCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
               await _uow.UserInstruments.AddAsync(vm.UserInstrument);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _uow.AppUsers.AllAsync(),
                "Id", "Id", userInstrument.AppUserId);
            vm.InstrumentSelectList = new SelectList(_context.Instruments,
                "InstrumentId", "Name", userInstrument.InstrumentId);
            return View(vm);
        }

        // GET: UserInstruments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInstrument = await _uow.UserInstruments.FindAsync(id);
            if (userInstrument == null)
            {
                return NotFound();
            }
            /*ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", userInstrument.AppUserId);
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", userInstrument.InstrumentId);
            */
            return View(userInstrument);
        }

        // POST: UserInstruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AppUserId,InstrumentId,Comment")] UserInstrument userInstrument)
        {
            if (id != userInstrument.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.UserInstruments.Update(userInstrument);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", userInstrument.AppUserId);
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "InstrumentId", "Name", userInstrument.InstrumentId);
            */
            return View(userInstrument);
        }

        // GET: UserInstruments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var userInstrument = await _context.UserInstruments
                .Include(u => u.AppUser)
                .Include(u => u.Instrument)
                .FirstOrDefaultAsync(m => m.UserInstrumentId == id);*/
            var userInstrument = await _uow.UserInstruments.FindAsync(id);
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
            _uow.UserInstruments.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
