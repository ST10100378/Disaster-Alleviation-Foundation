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
    public class MonetaryDonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonetaryDonationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: MonetaryDonations
        public async Task<IActionResult> Index()
        {
              return _context.MonetaryDonation != null ? 
                          View(await _context.MonetaryDonation.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MonetaryDonation'  is null.");
        }
        [Authorize]

        // GET: MonetaryDonations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.MonetaryDonation == null)
            {
                return NotFound();
            }

            var monetaryDonation = await _context.MonetaryDonation
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (monetaryDonation == null)
            {
                return NotFound();
            }

            return View(monetaryDonation);
        }
        [Authorize]

        // GET: MonetaryDonations/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]

        // POST: MonetaryDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,DonationDate,Amount")] MonetaryDonation monetaryDonation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monetaryDonation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monetaryDonation);
        }
        [Authorize]

        // GET: MonetaryDonations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.MonetaryDonation == null)
            {
                return NotFound();
            }

            var monetaryDonation = await _context.MonetaryDonation.FindAsync(id);
            if (monetaryDonation == null)
            {
                return NotFound();
            }
            return View(monetaryDonation);
        }
        [Authorize]

        // POST: MonetaryDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,DonationDate,Amount")] MonetaryDonation monetaryDonation)
        {
            if (id != monetaryDonation.UserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monetaryDonation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonetaryDonationExists(monetaryDonation.UserName))
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
            return View(monetaryDonation);
        }
        [Authorize]

        // GET: MonetaryDonations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.MonetaryDonation == null)
            {
                return NotFound();
            }

            var monetaryDonation = await _context.MonetaryDonation
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (monetaryDonation == null)
            {
                return NotFound();
            }

            return View(monetaryDonation);
        }
        [Authorize]

        // POST: MonetaryDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.MonetaryDonation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MonetaryDonation'  is null.");
            }
            var monetaryDonation = await _context.MonetaryDonation.FindAsync(id);
            if (monetaryDonation != null)
            {
                _context.MonetaryDonation.Remove(monetaryDonation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonetaryDonationExists(string id)
        {
          return (_context.MonetaryDonation?.Any(e => e.UserName == id)).GetValueOrDefault();
        }
    }
}
