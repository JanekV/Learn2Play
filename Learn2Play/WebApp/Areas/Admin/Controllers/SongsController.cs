using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Areas.Admin.ViewModels;
using Chord = BLL.App.DTO.DomainEntityDTOs.Chord;
using Instrument = BLL.App.DTO.DomainEntityDTOs.Instrument;
using Style = BLL.App.DTO.DomainEntityDTOs.Style;
using Video = BLL.App.DTO.DomainEntityDTOs.Video;

namespace WebApp.Areas.Admin.Controllers
{
    //[Authorize]
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
            var song = await _bll.Songs.GetSongWithEverythingAsync(id.Value);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public async Task<IActionResult> Create()
        {
            var vm = new SongCreateViewModel();
            vm.SongKeySelectList = new SelectList(await _bll.SongKeys.AllAsyncWithInclude(),
                nameof(SongKey.Id), nameof(SongKey.Description));
            return View(vm);
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongCreateViewModel vm)
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

            var song = await _bll.Songs.GetSongWithEverythingAsync(id.Value);
            if (song == null)
            {
                return NotFound();
            }
            /*song.SongKeySelectList = new SelectList(
                await _bll.SongKeys.AllAsync(),
                nameof(BLL.App.DTO.DomainEntityDTOs.SongKey.Id), nameof(BLL.App.DTO.DomainEntityDTOs.SongKey.Description),
                song.SongKeyId);
            song.InstrumentMultiSelectList = new MultiSelectList(
                await _bll.Instruments.AllAsync(),
                nameof(Instrument.Id), nameof(Instrument.Name),
                song.Instruments);
            song.StyleMultiSelectList = new MultiSelectList(
                await _bll.Styles.AllAsync(),
                nameof(Style.Id), nameof(Style.Name),
                song.Styles);
            song.ChordMultiSelectList = new MultiSelectList(
                await _bll.Chords.AllAsync(),
                nameof(Chord.Id), nameof(Chord.Name),
                song.Chords);*/
            
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BLL.App.DTO.SongWithEverything swe)
        {
            if (id != swe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _bll.Songs.UpdateSongWithEverything(swe);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(swe);
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
