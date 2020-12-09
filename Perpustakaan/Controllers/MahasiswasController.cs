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
    public class MahasiswasController : Controller
    {
        private readonly PERPUSTAKAAN_PAWContext _context;

        public MahasiswasController(PERPUSTAKAAN_PAWContext context)
        {
            _context = context;
        }

        // GET: Mahasiswas
        public async Task<IActionResult> Index()
        {
            var pERPUSTAKAAN_PAWContext = _context.Mahasiswa.Include(m => m.NoGenderNavigation);
            return View(await pERPUSTAKAAN_PAWContext.ToListAsync());
        }

        // GET: Mahasiswas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mahasiswa = await _context.Mahasiswa
                .Include(m => m.NoGenderNavigation)
                .FirstOrDefaultAsync(m => m.NoAnggota == id);
            if (mahasiswa == null)
            {
                return NotFound();
            }

            return View(mahasiswa);
        }

        // GET: Mahasiswas/Create
        public IActionResult Create()
        {
            ViewData["NoGender"] = new SelectList(_context.Gender, "NoGender", "NoGender");
            return View();
        }

        // POST: Mahasiswas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoAnggota,Nim,Nama,NoGender,NoHp,Alamat")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mahasiswa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NoGender"] = new SelectList(_context.Gender, "NoGender", "NoGender", mahasiswa.NoGender);
            return View(mahasiswa);
        }

        // GET: Mahasiswas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mahasiswa = await _context.Mahasiswa.FindAsync(id);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            ViewData["NoGender"] = new SelectList(_context.Gender, "NoGender", "NoGender", mahasiswa.NoGender);
            return View(mahasiswa);
        }

        // POST: Mahasiswas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoAnggota,Nim,Nama,NoGender,NoHp,Alamat")] Mahasiswa mahasiswa)
        {
            if (id != mahasiswa.NoAnggota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mahasiswa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MahasiswaExists(mahasiswa.NoAnggota))
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
            ViewData["NoGender"] = new SelectList(_context.Gender, "NoGender", "NoGender", mahasiswa.NoGender);
            return View(mahasiswa);
        }

        // GET: Mahasiswas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mahasiswa = await _context.Mahasiswa
                .Include(m => m.NoGenderNavigation)
                .FirstOrDefaultAsync(m => m.NoAnggota == id);
            if (mahasiswa == null)
            {
                return NotFound();
            }

            return View(mahasiswa);
        }

        // POST: Mahasiswas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mahasiswa = await _context.Mahasiswa.FindAsync(id);
            _context.Mahasiswa.Remove(mahasiswa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MahasiswaExists(int id)
        {
            return _context.Mahasiswa.Any(e => e.NoAnggota == id);
        }
    }
}
