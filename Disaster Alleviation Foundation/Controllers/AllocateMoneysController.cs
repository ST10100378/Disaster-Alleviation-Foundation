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
    public class AllocateMoneysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllocateMoneysController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: AllocateMoneys
        public async Task<IActionResult> Index()
        {
              return _context.AllocateMoney != null ? 
                          View(await _context.AllocateMoney.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AllocateMoney'  is null.");
        }
        [Authorize]
        // GET: AllocateMoneys/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AllocateMoney == null)
            {
                return NotFound();
            }

            var allocateMoney = await _context.AllocateMoney
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (allocateMoney == null)
            {
                return NotFound();
            }

            return View(allocateMoney);
        }
        [Authorize]
        // GET: AllocateMoneys/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: AllocateMoneys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Amount,DonationDate,DisaterType,DisasterId")] AllocateMoney allocateMoney)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allocateMoney);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allocateMoney);
        }
        [Authorize]
        // GET: AllocateMoneys/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AllocateMoney == null)
            {
                return NotFound();
            }

            var allocateMoney = await _context.AllocateMoney.FindAsync(id);
            if (allocateMoney == null)
            {
                return NotFound();
            }
            return View(allocateMoney);
        }
        [Authorize]
        // POST: AllocateMoneys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,Amount,DonationDate,DisaterType,DisasterId")] AllocateMoney allocateMoney)
        {
            if (id != allocateMoney.UserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocateMoney);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocateMoneyExists(allocateMoney.UserName))
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
            return View(allocateMoney);
        }
        [Authorize]
        // GET: AllocateMoneys/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AllocateMoney == null)
            {
                return NotFound();
            }

            var allocateMoney = await _context.AllocateMoney
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (allocateMoney == null)
            {
                return NotFound();
            }

            return View(allocateMoney);
        }
        [Authorize]
        // POST: AllocateMoneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AllocateMoney == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AllocateMoney'  is null.");
            }
            var allocateMoney = await _context.AllocateMoney.FindAsync(id);
            if (allocateMoney != null)
            {
                _context.AllocateMoney.Remove(allocateMoney);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllocateMoneyExists(string id)
        {
          return (_context.AllocateMoney?.Any(e => e.UserName == id)).GetValueOrDefault();
        }
    }
}
