using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Admin.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class NotesController : Controller
    {
        private readonly IAppBLL _bll;

        public NotesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Notes.AllAsync());
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _bll.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] BLL.App.DTO.DomainEntityDTOs.Note note)
        {
            if (ModelState.IsValid)
            {
                await _bll.Notes.AddAsync(note);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForChord(ChordWithNoteViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.Chords.AddNoteToChord(await _bll.Chords.FindAsync(vm.ChordId), vm.Note);
                await _bll.SaveChangesAsync();
                return RedirectToAction(controllerName: "Chords", actionName: "Details", routeValues: new {Id = vm.ChordId});
            }
            return RedirectToAction();
        }
        
        public async Task<IActionResult> CreateNoteForChord(int chordId)
        {
            var chord = await _bll.Chords.FindAsync(chordId);
            var vm = new ChordWithNoteViewModel {
                ChordId = chordId,
                ChordName = chord.Name
            };
            return View(vm);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _bll.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] BLL.App.DTO.DomainEntityDTOs.Note note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    _bll.Notes.Update(note);
                    await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _bll.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.Notes.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
