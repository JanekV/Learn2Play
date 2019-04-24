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
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class VideosController : Controller
    {
        private readonly IAppBLL _bll;

        public VideosController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Videos.AllAsyncWithInclude());
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var video = await _bll.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Videos/Create
        public async Task<IActionResult> Create()
        {
            var vm = new VideoCreateEditViewModel();
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.Video.SongId);
            return View(vm);        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VideoCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.Videos.AddAsync(vm.Video);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.Video.SongId);
            return View(vm);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _bll.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            var vm = new VideoCreateEditViewModel();
            vm.Video = video;
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.Video.SongId);
            return View(vm);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VideoCreateEditViewModel vm)
        {
            if (id != vm.Video.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Videos.Update(vm.Video);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.Video.SongId);
            return View(vm);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var video = await _bll.Videos.FindAsync(id);
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
            _bll.Videos.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
