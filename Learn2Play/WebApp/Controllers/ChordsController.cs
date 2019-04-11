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

namespace WebApp.Controllers
{
    public class ChordsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ChordsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Chords
        public async Task<IActionResult> Index()
        {
            return View(await _uow.Chords.AllAsync());
        }

        // GET: Chords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chord = await _uow.Chords
                .FindAsync(id);
            if (chord == null)
            {
                return NotFound();
            }

            return View(chord);
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
        public async Task<IActionResult> Create([Bind("Name,ShapePicturePath,Id")] Chord chord)
        {
            if (ModelState.IsValid)
            {
                await _uow.Chords.AddAsync(chord);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chord);
        }

        // GET: Chords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chord = await _uow.Chords.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Name,ShapePicturePath,Id")] Chord chord)
        {
            if (id != chord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Chords.Update(chord);
                await _uow.SaveChangesAsync();
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

            var chord = await _uow.Chords
                .FindAsync(id);
            if (chord == null)
            {
                return NotFound();
            }

            return View(chord);
        }

        // POST: Chords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Chords.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}