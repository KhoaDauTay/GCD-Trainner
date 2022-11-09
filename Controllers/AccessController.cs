using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_app_gcd.Data;
using web_app_gcd.Models;

namespace web_app_gcd.Controllers
{
    public class AccessController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccessController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Access
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Accesses.Include(a => a.Document).Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Access/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accesses == null)
            {
                return NotFound();
            }

            var access = await _context.Accesses
                .Include(a => a.Document)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (access == null)
            {
                return NotFound();
            }

            return View(access);
        }

        // GET: Access/Create
        public IActionResult Create()
        {
            ViewData["DocumentId"] = new SelectList(_context.Documents, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Access/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,DocumentId,ExpDate,Status")] Access access)
        {
            if (ModelState.IsValid)
            {
                _context.Add(access);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocumentId"] = new SelectList(_context.Documents, "Id", "Id", access.DocumentId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", access.UserId);
            return View(access);
        }

        // GET: Access/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accesses == null)
            {
                return NotFound();
            }

            var access = await _context.Accesses.FindAsync(id);
            if (access == null)
            {
                return NotFound();
            }
            ViewData["DocumentId"] = new SelectList(_context.Documents, "Id", "Id", access.DocumentId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", access.UserId);
            return View(access);
        }

        // POST: Access/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,DocumentId,ExpDate,Status")] Access access)
        {
            if (id != access.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(access);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessExists(access.Id))
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
            ViewData["DocumentId"] = new SelectList(_context.Documents, "Id", "Id", access.DocumentId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", access.UserId);
            return View(access);
        }

        // GET: Access/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accesses == null)
            {
                return NotFound();
            }

            var access = await _context.Accesses
                .Include(a => a.Document)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (access == null)
            {
                return NotFound();
            }

            return View(access);
        }

        // POST: Access/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accesses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Accesses'  is null.");
            }
            var access = await _context.Accesses.FindAsync(id);
            if (access != null)
            {
                _context.Accesses.Remove(access);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessExists(int id)
        {
          return (_context.Accesses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
