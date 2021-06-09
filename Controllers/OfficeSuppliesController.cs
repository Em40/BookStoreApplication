using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreApplication.Data;
using BookStoreApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApplication.Controllers
{
    public class OfficeSuppliesController : Controller
    {
        private readonly BookStoreApplicationDbContext _context;

        public OfficeSuppliesController(BookStoreApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OfficeSupplies
        public async Task<IActionResult> Index()
        {
            return View(await _context.OfficeSupplies.ToListAsync());
        }

        // GET: OfficeSupplies/SearchForm
        public IActionResult SearchForm()
        {
            return View();
        }

        // POST: OfficeSupplies/SearchResults
        public async Task<IActionResult> SearchResults(string searchPhrase)
        {
            return View("Index", await _context.OfficeSupplies.Where(n => n.Name.Contains(searchPhrase)).ToListAsync());
        }

        // GET: OfficeSupplies/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeSupply = await _context.OfficeSupplies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (officeSupply == null)
            {
                return NotFound();
            }

            return View(officeSupply);
        }

        // GET: OfficeSupplies/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfficeSupplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,CountInStock")] OfficeSupply officeSupply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(officeSupply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(officeSupply);
        }

        // GET: OfficeSupplies/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeSupply = await _context.OfficeSupplies.FindAsync(id);
            if (officeSupply == null)
            {
                return NotFound();
            }
            return View(officeSupply);
        }

        // POST: OfficeSupplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CountInStock")] OfficeSupply officeSupply)
        {
            if (id != officeSupply.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(officeSupply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficeSupplyExists(officeSupply.Id))
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
            return View(officeSupply);
        }

        // GET: OfficeSupplies/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeSupply = await _context.OfficeSupplies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (officeSupply == null)
            {
                return NotFound();
            }

            return View(officeSupply);
        }

        // POST: OfficeSupplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officeSupply = await _context.OfficeSupplies.FindAsync(id);
            _context.OfficeSupplies.Remove(officeSupply);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeSupplyExists(int id)
        {
            return _context.OfficeSupplies.Any(e => e.Id == id);
        }
    }
}
