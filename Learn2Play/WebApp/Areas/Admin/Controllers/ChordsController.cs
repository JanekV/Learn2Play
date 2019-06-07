using System.Collections.Generic;
using System.Linq;
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
    public class ChordsController : Controller
    {
        private readonly IAppBLL _bll;

        public ChordsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Chords
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Chords.GetAllChordsWithNotesAsync());
        }

        // GET: Chords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chordWithNotes = await _bll.Chords.GetChordWithNotesAsync(id.Value);
            if (chordWithNotes == null)
            {
                return NotFound();
            }

            return View(chordWithNotes);
        }

        // GET: Chords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ShapePicturePath,Id")] BLL.App.DTO.DomainEntityDTOs.Chord chord)
        {
            if (ModelState.IsValid)
            {
                await _bll.Chords.AddAsync(chord);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chord);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNoteForChord(ChordCreateEditViewModel vm)
        {
            await _bll.Chords.AddNoteToChord(vm.Chord, vm.Note);
            vm.Notes.Add(vm.Note);
            vm.Note = null;
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Details), vm);
        }

        // GET: Chords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chord = await _bll.Chords.FindAsync(id);
            if (chord == null)
            {
                return NotFound();
            }
            return View(chord);
        }

        // POST: Chords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ShapePicturePath,Id")] BLL.App.DTO.DomainEntityDTOs.Chord chord)
        {
            if (id != chord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Chords.Update(chord);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chord);
        }

        // GET: Chords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chord = await _bll.Chords
                .FindAsync(id);
            if (chord == null)
            {
                return NotFound();
            }

            return View(chord);
        }

        //:TODO also delete ChordNotes before Chord!
        // POST: Chords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.Chords.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AddChordToSong(int songId)
        {
            var song = await _bll.Songs.FindAsync(songId);
            var vm = new SongWithChordViewModel()
            {
                SongId = songId,
                SongName = song.Name,
                ChordSelectList = new SelectList(
                    await _bll.Chords.AllAsync(),
                    nameof(Chord.Id), nameof(Chord.Name))
            };
            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToSong(SongWithChordViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.Songs.AddChordToSongAsync(
                    await _bll.Songs.FindAsync(vm.SongId),
                    await _bll.Chords.FindAsync(vm.ChordId));
                await _bll.SaveChangesAsync();
                return RedirectToAction(controllerName: "Songs", actionName: "Details", routeValues: new {Id = vm.SongId});
            }
            return RedirectToAction();
        }

        public async Task<IActionResult> Remove(int songId, int chordId)
        {
            var songChord = await _bll.SongChords.FindByChordAndSongIdAsync(chordId, songId);
            _bll.SongChords.Remove(songChord.Id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(controllerName: "Songs", actionName: "Details", routeValues: new {Id = songId});
        }
    }
}
