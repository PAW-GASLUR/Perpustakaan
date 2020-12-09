using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Perpustakaan.Models;

namespace Perpustakaan.Controllers
{
    public class PeminjamenController : Controller
    {
        private readonly PERPUSTAKAAN_PAWContext _context;

        public PeminjamenController(PERPUSTAKAAN_PAWContext context)
        {
            _context = context;
        }

        // GET: Peminjamen
        public async Task<IActionResult> Index()
        {
            var pERPUSTAKAAN_PAWContext = _context.Peminjaman.Include(p => p.NoAnggotaNavigation).Include(p => p.NoBukuNavigation);
            return View(await pERPUSTAKAAN_PAWContext.ToListAsync());
        }

        // GET: Peminjamen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjaman = await _context.Peminjaman
                .Include(p => p.NoAnggotaNavigation)
                .Include(p => p.NoBukuNavigation)
                .FirstOrDefaultAsync(m => m.NoPeminjaman == id);
            if (peminjaman == null)
            {
                return NotFound();
            }

            return View(peminjaman);
        }

        // GET: Peminjamen/Create
        public IActionResult Create()
        {
            ViewData["NoAnggota"] = new SelectList(_context.Mahasiswa, "NoAnggota", "NoAnggota");
            ViewData["NoBuku"] = new SelectList(_context.Buku, "NoBuku", "NoBuku");
            return View();
        }

        // POST: Peminjamen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoPeminjaman,TglPeminjaman,NoBuku,NoAnggota")] Peminjaman peminjaman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peminjaman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NoAnggota"] = new SelectList(_context.Mahasiswa, "NoAnggota", "NoAnggota", peminjaman.NoAnggota);
            ViewData["NoBuku"] = new SelectList(_context.Buku, "NoBuku", "NoBuku", peminjaman.NoBuku);
            return View(peminjaman);
        }

        // GET: Peminjamen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjaman = await _context.Peminjaman.FindAsync(id);
            if (peminjaman == null)
            {
                return NotFound();
            }
            ViewData["NoAnggota"] = new SelectList(_context.Mahasiswa, "NoAnggota", "NoAnggota", peminjaman.NoAnggota);
            ViewData["NoBuku"] = new SelectList(_context.Buku, "NoBuku", "NoBuku", peminjaman.NoBuku);
            return View(peminjaman);
        }

        // POST: Peminjamen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoPeminjaman,TglPeminjaman,NoBuku,NoAnggota")] Peminjaman peminjaman)
        {
            if (id != peminjaman.NoPeminjaman)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peminjaman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeminjamanExists(peminjaman.NoPeminjaman))
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
            ViewData["NoAnggota"] = new SelectList(_context.Mahasiswa, "NoAnggota", "NoAnggota", peminjaman.NoAnggota);
            ViewData["NoBuku"] = new SelectList(_context.Buku, "NoBuku", "NoBuku", peminjaman.NoBuku);
            return View(peminjaman);
        }

        // GET: Peminjamen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjaman = await _context.Peminjaman
                .Include(p => p.NoAnggotaNavigation)
                .Include(p => p.NoBukuNavigation)
                .FirstOrDefaultAsync(m => m.NoPeminjaman == id);
            if (peminjaman == null)
            {
                return NotFound();
            }

            return View(peminjaman);
        }

        // POST: Peminjamen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);
            _context.Peminjaman.Remove(peminjaman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeminjamanExists(int id)
        {
            return _context.Peminjaman.Any(e => e.NoPeminjaman == id);
        }
    }
}
