using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Create()
        {
            var vm = new UserInstrumentCreateEditViewModel();
            vm.AppUserSelectList = new SelectList(await _uow.AppUsers.AllAsync(),
                nameof(AppUser.Id), nameof(AppUser.Email), vm.UserInstrument.AppUserId);
            vm.InstrumentSelectList = new SelectList(await _uow.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name), vm.UserInstrument.InstrumentId);
            return View(vm);
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
                nameof(AppUser.Id), nameof(AppUser.Email), vm.UserInstrument.AppUserId);
            vm.InstrumentSelectList = new SelectList(await _uow.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name), vm.UserInstrument.InstrumentId);
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
            var vm = new UserInstrumentCreateEditViewModel();
            vm.UserInstrument = userInstrument;
            vm.AppUserSelectList = new SelectList(await _uow.AppUsers.AllAsync(),
                nameof(AppUser.Id), nameof(AppUser.Email), vm.UserInstrument.AppUserId);
            vm.InstrumentSelectList = new SelectList(await _uow.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name), vm.UserInstrument.InstrumentId);
            return View(vm);
        }

        // POST: UserInstruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserInstrumentCreateEditViewModel vm)
        {
            if (id != vm.UserInstrument.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.UserInstruments.Update(vm.UserInstrument);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _uow.AppUsers.AllAsync(),
                nameof(AppUser.Id), nameof(AppUser.Email), vm.UserInstrument.AppUserId);
            vm.InstrumentSelectList = new SelectList(await _uow.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name), vm.UserInstrument.InstrumentId);
            return View(vm);
        }

        // GET: UserInstruments/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
