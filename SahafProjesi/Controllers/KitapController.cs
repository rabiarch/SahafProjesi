using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SahafProjesi.CustomFilters;
using SahafProjesi.Data;
using SahafProjesi.Models;
using SahafProjesi.Models.ViewModels;

namespace SahafProjesi.Controllers
{
    [SessionKontrolEt]
    public class KitapController : Controller
    {
        private readonly SahafDbContext _context;

        public KitapController(SahafDbContext context)
        {
            _context = context;
        }

        // GET: Kitap
        public async Task<IActionResult> Index(int? minFiyat, int? maxFiyat)
        {
            var kitaplar = _context.Kitaplar.Include(x => x.Kategori).Include(x => x.Yayinevi).Include(x => x.Yazar);

            if(minFiyat is null || maxFiyat is null)
            {
                return View(kitaplar);
            }
            
            return View(kitaplar.Where(x=>x.Fiyat>=minFiyat && x.Fiyat<=maxFiyat));
        }

        public IActionResult SonEklenenler()
        {
            //ID'ler eklendikçe her urun için unique otomatik oluşmaktadır.Bu yüzden tersine ıd sıralamasında son 10 tanesi en güncel eklenen kitaplar olacaktır.

            var sonKitaplar = _context.Kitaplar.Include(k => k.Kategori).Include(k => k.Yayinevi).Include(k => k.Yazar).OrderByDescending(x => x.KitapID).Take(10);

            return View(sonKitaplar);
        }

        // GET: Kitap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar
                .Include(k => k.Kategori)
                .Include(k => k.Yayinevi)
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.KitapID == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // GET: Kitap/Create
        public IActionResult Create()
        {
            KitapEklemeEkrani_VM kitapEklemeEkrani_VM = new KitapEklemeEkrani_VM();
            kitapEklemeEkrani_VM.Kategoriler = new SelectList(_context.Kategoriler, "KategoriID", "KategoriAdi");
            kitapEklemeEkrani_VM.Yayinevleri = new SelectList(_context.Yayinevleri, "YayineviID", "YayineviAdi");
            kitapEklemeEkrani_VM.Yazarlar = new SelectList(_context.Yazarlar, "YazarID", "YazarAdi");
            return View(kitapEklemeEkrani_VM);
        }

        // POST: Kitap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KitapEkle_VM kitap)
        {
            if (ModelState.IsValid)
            {
                int? kullaniciID = HttpContext.Session.GetInt32("kullaniciId");

                if(kullaniciID.HasValue)
                {
                    string strFilePath = "wwwroot/images/" + kitap.KapakResmi.FileName;
                    FileStream fs = new FileStream(strFilePath,FileMode.Create);
                    kitap.KapakResmi.CopyTo(fs);
                    fs.Close();


                    Kitap yeniKitap = new Kitap()
                    {
                        KitapAdi = kitap.KitapAdi,
                        Fiyat = kitap.Fiyat,
                        YayineviID = kitap.YayineviID,
                        YazarID = kitap.YazarID,
                        KategoriID = kitap.KategoriID,
                        BasimYili = kitap.BasimYili,
                        BaskiSayisi = kitap.BaskiSayisi,
                        KitapOzeti = kitap.KitapOzeti,
                        KullaniciID = kullaniciID,
                        KapakResmi = kitap.KapakResmi.FileName
                    };

                    _context.Kitaplar.Add(yeniKitap);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Hata","Kullanıcı bulunamadı...");
                }
            }

            KitapEklemeEkrani_VM kitapEklemeEkrani_VM = new KitapEklemeEkrani_VM();
            kitapEklemeEkrani_VM.Kategoriler = new SelectList(_context.Kategoriler, "KategoriID", "KategoriAdi", kitap.KategoriID);
            kitapEklemeEkrani_VM.Yayinevleri = new SelectList(_context.Yayinevleri, "YayineviID", "YayineviAdi", kitap.YayineviID);
            kitapEklemeEkrani_VM.Yazarlar = new SelectList(_context.Yazarlar, "YazarID", "YazarAdi", kitap.YazarID);
            return View(kitap);
        }

        // GET: Kitap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }

            KitapEkle_VM kitapEkleVM = new KitapEkle_VM() 
            { 
                KitapAdi = kitap.KitapAdi, 
                KategoriID = kitap.KategoriID, 
                Fiyat = kitap.Fiyat, 
                YayineviID = kitap.YayineviID, 
                YazarID = kitap.YazarID, 
                BasimYili = kitap.BasimYili, 
                BaskiSayisi = kitap.BaskiSayisi, 
                KitapOzeti = kitap.KitapOzeti, 
                KullaniciID = kitap.KullaniciID 
            };

            KitapEklemeEkrani_VM kitapEklemeEkrani_VM = new KitapEklemeEkrani_VM();
            kitapEklemeEkrani_VM.Kategoriler = new SelectList(_context.Kategoriler, "KategoriID", "KategoriAdi", kitap.KategoriID);
            kitapEklemeEkrani_VM.Yayinevleri = new SelectList(_context.Yayinevleri, "YayineviID", "YayineviAdi", kitap.YayineviID);
            kitapEklemeEkrani_VM.Yazarlar = new SelectList(_context.Yazarlar, "YazarID", "YazarAdi", kitap.YazarID);
            kitapEklemeEkrani_VM.Kitap = kitapEkleVM;
            return View(kitapEklemeEkrani_VM);
        }

        // POST: Kitap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,KitapEkle_VM kitap)
        {
            //if (id != kitap.KitapID)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    string strFilePath = "wwwroot/images/" + kitap.KapakResmi.FileName;
                    FileStream fs = new FileStream(strFilePath, FileMode.Create);
                    kitap.KapakResmi.CopyTo(fs);
                    fs.Close();

                    Kitap yeniKitap = new Kitap() 
                    { 
                        KitapID = id, 
                        KitapAdi = kitap.KitapAdi, 
                        Fiyat = kitap.Fiyat, 
                        YayineviID = kitap.YayineviID, 
                        YazarID = kitap.YazarID, 
                        KategoriID = kitap.KategoriID, 
                        BasimYili = kitap.BasimYili, 
                        BaskiSayisi = kitap.BaskiSayisi, 
                        KitapOzeti = kitap.KitapOzeti, 
                        KapakResmi = kitap.KapakResmi.FileName,
                        KullaniciID = kitap.KullaniciID
                    };

                    _context.Update(yeniKitap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!KitapExists(kitap.KitapID))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                        throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }

            KitapEklemeEkrani_VM kitapEklemeEkrani_VM = new KitapEklemeEkrani_VM();
            kitapEklemeEkrani_VM.Kategoriler = new SelectList(_context.Kategoriler, "KategoriID", "KategoriAdi", kitap.KategoriID);
            kitapEklemeEkrani_VM.Yayinevleri = new SelectList(_context.Yayinevleri, "YayineviID", "YayineviAdi", kitap.YayineviID);
            kitapEklemeEkrani_VM.Yazarlar = new SelectList(_context.Yazarlar, "YazarID", "YazarAdi", kitap.YazarID);
            return View(kitapEklemeEkrani_VM);

        }

        // GET: Kitap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar
                .Include(k => k.Kategori)
                .Include(k => k.Yayinevi)
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.KitapID == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // POST: Kitap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap != null)
            {
                _context.Kitaplar.Remove(kitap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitapExists(int id)
        {
            return _context.Kitaplar.Any(e => e.KitapID == id);
        }
    }
}
