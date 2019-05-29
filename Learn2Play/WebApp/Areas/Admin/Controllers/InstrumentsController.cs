using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class InstrumentsController : Controller
    {
        private readonly IAppBLL _bll;

        public InstrumentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Instruments
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Instruments.AllAsync());
        }

        // GET: Instruments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _bll.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        // GET: Instruments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instruments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] BLL.App.DTO.DomainEntityDTOs.Instrument instrument)
        {
            if (ModelState.IsValid)
            {
                await _bll.Instruments.AddAsync(instrument);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrument);
        }

        // GET: Instruments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _bll.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }
            return View(instrument);
        }

        // POST: Instruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] BLL.App.DTO.DomainEntityDTOs.Instrument instrument)
        {
            if (id != instrument.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                    _bll.Instruments.Update(instrument);
                    await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrument);
        }

        // GET: Instruments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _bll.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.Instruments.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
