using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Areas.Admin.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SongsController : Controller
    {
        private readonly IAppBLL _bll;

        public SongsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Songs.AllAsyncWithInclude());
        }
        
        public async Task<IActionResult> Search([Bind("search")] string search)
        {
            var res = await _bll.Songs.SearchSongs(search);
            
            return View(res);
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var song = await _bll.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public async Task<IActionResult> Create()
        {
            var vm = new SongCreateEditViewModel();
            vm.SongKeySelectList = new SelectList(await _bll.SongKeys.AllAsyncWithInclude(),
                nameof(SongKey.Id), nameof(SongKey.Description));
            return View(vm);
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.Songs.AddAsync(vm.Song);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.SongKeySelectList = new SelectList(await _bll.SongKeys.AllAsyncWithInclude(),
                nameof(SongKey.Id), nameof(SongKey.Description));
            return View(vm);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _bll.Songs.GetSongWithEverythingAsync((int) id);
            if (song == null)
            {
                return NotFound();
            }
            /*song.Instruments = song.Instruments.Select(i => new SelectListItem {Text = i.Name, Value = i.Id})*/
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SongCreateEditViewModel vm)
        {
            if (id != vm.Song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Songs.Update(vm.Song);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.SongKeySelectList = new SelectList(await _bll.SongKeys.AllAsyncWithInclude(),
                nameof(SongKey.Id), nameof(SongKey.Description), vm.Song.SongKeyId);
            return View(null);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var song = await _bll.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.Songs.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
