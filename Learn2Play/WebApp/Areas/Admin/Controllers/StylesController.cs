using System.Threading.Tasks;
using BLL.App.DTO.DomainEntityDTOs;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Areas.Admin.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class StylesController : Controller
    {
        private readonly IAppBLL _bll;

        public StylesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Styles
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Styles.AllAsync());
        }

        // GET: Styles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var style = await _bll.Styles.FindAsync(id.Value);
            if (style == null)
            {
                return NotFound();
            }

            return View(style);
        }

        // GET: Styles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Styles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] BLL.App.DTO.DomainEntityDTOs.Style style)
        {
            if (ModelState.IsValid)
            {
                await _bll.Styles.AddAsync(style);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(style);
        }

        // GET: Styles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var style = await _bll.Styles.FindAsync(id.Value);
            if (style == null)
            {
                return NotFound();
            }
            return View(style);
        }

        // POST: Styles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] BLL.App.DTO.DomainEntityDTOs.Style style)
        {
            if (id != style.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Styles.Update(style);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(style);
        }

        // GET: Styles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var style = await _bll.Styles.FindAsync(id.Value);
            if (style == null)
            {
                return NotFound();
            }

            return View(style);
        }

        // POST: Styles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.Styles.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AddStyleToSong(int songId)
        {
            var song = await _bll.Songs.FindAsync(songId);
            var vm = new SongWithStyleViewModel()
            {
                SongId = songId,
                SongName = song.Name,
                StyleSelectList = new SelectList(
                    await _bll.Styles.AllAsync(),
                    nameof(Style.Id), nameof(Style.Name))
            };
            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToSong(SongWithStyleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.Songs.AddStyleToSongAsync(
                    await _bll.Songs.FindAsync(vm.SongId),
                    await _bll.Styles.FindAsync(vm.StyleId));
                await _bll.SaveChangesAsync();
                return RedirectToAction(controllerName: "Songs", actionName: "Details", routeValues: new {Id = vm.SongId});
            }
            return RedirectToAction();
        }

        public async Task<IActionResult> Remove(int songId, int styleId)
        {
            var songStyle = await _bll.SongStyles.FindByStyleAndSongIdAsync(styleId, songId);
            _bll.SongStyles.Remove(songStyle.Id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(controllerName: "Songs", actionName: "Details", routeValues: new {Id = songId});
        }
    }
}
