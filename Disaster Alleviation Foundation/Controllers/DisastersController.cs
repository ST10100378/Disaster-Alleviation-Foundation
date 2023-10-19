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
    public class DisastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisastersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]

        // GET: Disasters
        public async Task<IActionResult> Index()
        {
              return _context.Disaster != null ? 
                          View(await _context.Disaster.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Disaster'  is null.");
        }
        [Authorize]

        // GET: Disasters/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Disaster == null)
            {
                return NotFound();
            }

            var disaster = await _context.Disaster
                .FirstOrDefaultAsync(m => m.Type == id);
            if (disaster == null)
            {
                return NotFound();
            }

            return View(disaster);
        }
        [Authorize]

        // GET: Disasters/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]

        // POST: Disasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type,StartDate,EndDate,Location,Discription,AidType")] Disaster disaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disaster);
        }
        [Authorize]

        // GET: Disasters/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Disaster == null)
            {
                return NotFound();
            }

            var disaster = await _context.Disaster.FindAsync(id);
            if (disaster == null)
            {
                return NotFound();
            }
            return View(disaster);
        }
        [Authorize]

        // POST: Disasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Type,StartDate,EndDate,Location,Discription,AidType")] Disaster disaster)
        {
            if (id != disaster.Type)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisasterExists(disaster.Type))
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
            return View(disaster);
        }
        [Authorize]

        // GET: Disasters/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Disaster == null)
            {
                return NotFound();
            }

            var disaster = await _context.Disaster
                .FirstOrDefaultAsync(m => m.Type == id);
            if (disaster == null)
            {
                return NotFound();
            }

            return View(disaster);
        }
        [Authorize]

        // POST: Disasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Disaster == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Disaster'  is null.");
            }
            var disaster = await _context.Disaster.FindAsync(id);
            if (disaster != null)
            {
                _context.Disaster.Remove(disaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisasterExists(string id)
        {
          return (_context.Disaster?.Any(e => e.Type == id)).GetValueOrDefault();
        }
    }
}
