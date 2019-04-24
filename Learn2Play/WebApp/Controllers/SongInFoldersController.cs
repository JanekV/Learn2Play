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
    public class SongInFoldersController : Controller
    {
        private readonly IAppBLL _bll;

        public SongInFoldersController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: SongInFolders
        public async Task<IActionResult> Index()
        {
            return View(await _bll.SongInFolders.AllAsyncWithInclude());
        }

        // GET: SongInFolders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songInFolder = await _bll.SongInFolders.FindAsync(id);
            if (songInFolder == null)
            {
                return NotFound();
            }

            return View(songInFolder);
        }

        // GET: SongInFolders/Create
        public async Task<IActionResult> Create()
        {
            var vm = new SongInFolderCreateEditViewModel();
            vm.FolderSelectList = new SelectList(await _bll.Folders.AllAsync(),
                nameof(Folder.Id), nameof(Folder.Name), vm.SongInFolder.FolderId);
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.SongInFolder.SongId);

            return View(vm);
        }

        // POST: SongInFolders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongInFolderCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.SongInFolders.AddAsync(vm.SongInFolder);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            vm.FolderSelectList = new SelectList(await _bll.Folders.AllAsync(),
                nameof(Folder.Id), nameof(Folder.Name), vm.SongInFolder.FolderId);
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.SongInFolder.SongId);

            return View(vm);
        }

        // GET: SongInFolders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songInFolder = await _bll.SongInFolders.FindAsync(id);
            if (songInFolder == null)
            {
                return NotFound();
            }

            var vm = new SongInFolderCreateEditViewModel();
            vm.SongInFolder = songInFolder;
            vm.FolderSelectList = new SelectList(await _bll.Folders.AllAsync(),
                nameof(Folder.Id), nameof(Folder.Name), vm.SongInFolder.FolderId);
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.SongInFolder.SongId);

            return View(vm);
        }

        // POST: SongInFolders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SongInFolderCreateEditViewModel vm)
        {
            if (id != vm.SongInFolder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.SongInFolders.Update(vm.SongInFolder);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.FolderSelectList = new SelectList(await _bll.Folders.AllAsync(),
                nameof(Folder.Id), nameof(Folder.Name), vm.SongInFolder.FolderId);
            vm.SongSelectList = new SelectList(await _bll.Songs.AllAsyncWithInclude(),
                nameof(Song.Id), nameof(Song.Author), vm.SongInFolder.SongId);
            
            return View(vm);
        }

        // GET: SongInFolders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var songInFolder = await _bll.SongInFolders.FindAsync(id);
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
            _bll.SongInFolders.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
