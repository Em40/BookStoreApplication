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
    public class NotebooksController : Controller
    {
        private readonly BookStoreApplicationDbContext _context;

        public NotebooksController(BookStoreApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notebooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notebooks.Include(n => n.Brand).ToListAsync());
        }

        // GET: Notebooks/SearchForm
        public IActionResult SearchForm()
        {
            return View();
        }

        // POST: Notebooks/SearchResults
        public async Task<IActionResult> SearchResults(string searchPhrase)
        {
            return View("Index", await _context.Notebooks.Where(t => t.Type.Contains(searchPhrase)).ToListAsync());
        }

        // GET: Notebooks/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebooks.Include(n => n.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notebook == null)
            {
                return NotFound();
            }

            return View(notebook);
        }

        // GET: Notebooks/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            IEnumerable<Brand> brands = _context.Brands.Select(brand => new Brand { Id = brand.Id, Name = brand.Name }).ToList();
            ViewBag.Brands = brands;
            return View();
        }

        // POST: Notebooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Format,Type,NumberOfPages,Price,CountInStock,BrandId")] Notebook notebook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notebook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notebook);
        }

        // GET: Notebooks/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            IEnumerable<Brand> brands = _context.Brands.Select(brand => new Brand { Id = brand.Id, Name = brand.Name }).ToList();
            ViewBag.Brands = brands;
            if (id == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebooks.FindAsync(id);
            if (notebook == null)
            {
                return NotFound();
            }
            return View(notebook);
        }

        // POST: Notebooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Format,Type,NumberOfPages,Price,CountInStock,BrandId")] Notebook notebook)
        {
            if (id != notebook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notebook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotebookExists(notebook.Id))
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
            return View(notebook);
        }

        // GET: Notebooks/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notebook == null)
            {
                return NotFound();
            }

            return View(notebook);
        }

        // POST: Notebooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notebook = await _context.Notebooks.FindAsync(id);
            _context.Notebooks.Remove(notebook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotebookExists(int id)
        {
            return _context.Notebooks.Any(e => e.Id == id);
        }
    }
}
