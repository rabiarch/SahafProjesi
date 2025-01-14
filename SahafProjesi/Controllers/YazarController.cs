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
    public class YazarController : Controller
    {
        private readonly SahafDbContext _context;

        public YazarController(SahafDbContext context)
        {
            _context = context;
        }

        // GET: Yazar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yazarlar.ToListAsync());
        }

        public IActionResult Kitaplar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitaplar = _context.Kitaplar.Include(x => x.Kategori).Include(x => x.Yayinevi).Include(x => x.Yazar).Where(x => x.YazarID == id);

            return View(kitaplar);
        }

        // GET: Yazar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yazar = await _context.Yazarlar
                .FirstOrDefaultAsync(m => m.YazarID == id);
            if (yazar == null)
            {
                return NotFound();
            }

            return View(yazar);
        }

        // GET: Yazar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yazar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YazarID,YazarAdi,YazarSoyadi")] Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yazar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yazar);
        }

        // GET: Yazar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yazar = await _context.Yazarlar.FindAsync(id);
            if (yazar == null)
            {
                return NotFound();
            }
            return View(yazar);
        }

        // POST: Yazar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YazarID,YazarAdi,YazarSoyadi")] Yazar yazar)
        {
            if (id != yazar.YazarID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yazar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YazarExists(yazar.YazarID))
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
            return View(yazar);
        }

        // GET: Yazar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yazar = await _context.Yazarlar
                .FirstOrDefaultAsync(m => m.YazarID == id);
            if (yazar == null)
            {
                return NotFound();
            }

            return View(yazar);
        }

        // POST: Yazar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yazar = await _context.Yazarlar.FindAsync(id);
            if (yazar != null)
            {
                _context.Yazarlar.Remove(yazar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YazarExists(int id)
        {
            return _context.Yazarlar.Any(e => e.YazarID == id);
        }
    }
}
