using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize(Roles = "DbAdmin")]
    public class TabsController : Controller
    {
        private readonly IAppBLL _bll;

        public TabsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Tabs
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Tabs.AllAsyncWithInclude());
        }

        // GET: Tabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tab = await _bll.Tabs.FindAsync(id);
            if (tab == null)
            {
                return NotFound();
            }

            return View(tab);
        }

        // GET: Tabs/Create
        public async Task<IActionResult> Create()
        {
            var vm = new TabCreateEditViewModel();
            vm.VideoSelectList = new SelectList(await _bll.Videos.AllAsyncWithInclude(),
                nameof(Video.Id), nameof(Video.AuthorChannelLink));
            return View(vm);
        }

        // POST: Tabs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TabCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.Tabs.AddAsync(vm.Tab);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.VideoSelectList = new SelectList(await _bll.Videos.AllAsyncWithInclude(),
                nameof(Video.Id), nameof(Video.AuthorChannelLink));
            return View(vm);
        }

        // GET: Tabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tab = await _bll.Tabs.FindAsync(id);
            if (tab == null)
            {
                return NotFound();
            }
            var vm = new TabCreateEditViewModel();
            vm.Tab = tab;
            vm.VideoSelectList = new SelectList(await _bll.Videos.AllAsyncWithInclude(),
                nameof(Video.Id), nameof(Video.AuthorChannelLink), vm.Tab.VideoId);
            return View(vm);
        }

        // POST: Tabs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TabCreateEditViewModel vm)
        {
            if (id != vm.Tab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Tabs.Update(vm.Tab);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.VideoSelectList = new SelectList(await _bll.Videos.AllAsyncWithInclude(),
                nameof(Video.Id), nameof(Video.AuthorChannelLink), vm.Tab.VideoId);
            return View(vm);
        }

        // GET: Tabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tab = await _bll.Tabs.FindAsync(id);
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
            _bll.Tabs.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
