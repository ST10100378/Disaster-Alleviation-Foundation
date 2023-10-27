using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Disaster_Alleviation_Foundation.Data;
using Disaster_Alleviation_Foundation.Models;
using Microsoft.AspNetCore.Authorization;

namespace Disaster_Alleviation_Foundation.Controllers
{
    public class AllocateGoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllocateGoodsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: AllocateGoods
        public async Task<IActionResult> Index()
        {
              return _context.AllocateGood != null ? 
                          View(await _context.AllocateGood.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AllocateGood'  is null.");
        }
        [Authorize]
        // GET: AllocateGoods/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AllocateGood == null)
            {
                return NotFound();
            }

            var allocateGood = await _context.AllocateGood
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (allocateGood == null)
            {
                return NotFound();
            }

            return View(allocateGood);
        }
        [Authorize]
        // GET: AllocateGoods/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: AllocateGoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Date,ItemAmount,Category,DisasterType,DisasterId")] AllocateGood allocateGood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allocateGood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allocateGood);
        }
        [Authorize]
        // GET: AllocateGoods/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AllocateGood == null)
            {
                return NotFound();
            }

            var allocateGood = await _context.AllocateGood.FindAsync(id);
            if (allocateGood == null)
            {
                return NotFound();
            }
            return View(allocateGood);
        }
        [Authorize]
        // POST: AllocateGoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,Date,ItemAmount,Category,DisasterType,DisasterId")] AllocateGood allocateGood)
        {
            if (id != allocateGood.UserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocateGood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocateGoodExists(allocateGood.UserName))
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
            return View(allocateGood);
        }
        [Authorize]
        // GET: AllocateGoods/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AllocateGood == null)
            {
                return NotFound();
            }

            var allocateGood = await _context.AllocateGood
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (allocateGood == null)
            {
                return NotFound();
            }

            return View(allocateGood);
        }
        [Authorize]
        // POST: AllocateGoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AllocateGood == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AllocateGood'  is null.");
            }
            var allocateGood = await _context.AllocateGood.FindAsync(id);
            if (allocateGood != null)
            {
                _context.AllocateGood.Remove(allocateGood);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllocateGoodExists(string id)
        {
          return (_context.AllocateGood?.Any(e => e.UserName == id)).GetValueOrDefault();
        }
    }
}
