using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SahafProjesi.CustomFilters;
using SahafProjesi.Data;
using SahafProjesi.Models;

namespace SahafProjesi.Controllers
{
    [SessionKontrolEt]
    public class YayineviController : Controller
    {
        private readonly SahafDbContext _context;

        public YayineviController(SahafDbContext context)
        {
            _context = context;
        }

        // GET: Yayinevi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yayinevleri.ToListAsync());
        }

        public IActionResult Kitaplar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitaplar = _context.Kitaplar.Include(x => x.Kategori).Include(x => x.Yayinevi).Include(x => x.Yazar).Where(x => x.YayineviID == id);

            return View(kitaplar);
        }

        // GET: Yayinevi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yayinevi = await _context.Yayinevleri
                .FirstOrDefaultAsync(m => m.YayineviID == id);
            if (yayinevi == null)
            {
                return NotFound();
            }

            return View(yayinevi);
        }

        // GET: Yayinevi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yayinevi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YayineviID,YayineviAdi")] Yayinevi yayinevi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yayinevi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yayinevi);
        }

        // GET: Yayinevi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yayinevi = await _context.Yayinevleri.FindAsync(id);
            if (yayinevi == null)
            {
                return NotFound();
            }
            return View(yayinevi);
        }

        // POST: Yayinevi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YayineviID,YayineviAdi")] Yayinevi yayinevi)
        {
            if (id != yayinevi.YayineviID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yayinevi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YayineviExists(yayinevi.YayineviID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(yayinevi);
        }

        // GET: Yayinevi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yayinevi = await _context.Yayinevleri
                .FirstOrDefaultAsync(m => m.YayineviID == id);
            if (yayinevi == null)
            {
                return NotFound();
            }

            return View(yayinevi);
        }

        // POST: Yayinevi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yayinevi = await _context.Yayinevleri.FindAsync(id);
            if (yayinevi != null)
            {
                _context.Yayinevleri.Remove(yayinevi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YayineviExists(int id)
        {
            return _context.Yayinevleri.Any(e => e.YayineviID == id);
        }
    }
}
