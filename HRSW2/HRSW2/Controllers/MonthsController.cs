using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRSW2.Entities;
using HRSW2.DatabaseContext;

namespace HRSW2.Controllers
{
    public class MonthsController : Controller
    {
        private readonly HrDbContext _context;

        public MonthsController(HrDbContext context)
        {
            _context = context;
        }

        // GET: Months
        public async Task<IActionResult> Index()
        {
            return View(await _context.Month.ToListAsync());
        }

        // GET: Months/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var months = await _context.Month
                .FirstOrDefaultAsync(m => m.Id == id);
            if (months == null)
            {
                return NotFound();
            }

            return View(months);
        }

        // GET: Months/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Months/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Month,MonthName")] Months months)
        {
            if (ModelState.IsValid)
            {
                _context.Add(months);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(months);
        }

        // GET: Months/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var months = await _context.Month.FindAsync(id);
            if (months == null)
            {
                return NotFound();
            }
            return View(months);
        }

        // POST: Months/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Month,MonthName")] Months months)
        {
            if (id != months.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(months);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthsExists(months.Id))
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
            return View(months);
        }

        // GET: Months/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var months = await _context.Month
                .FirstOrDefaultAsync(m => m.Id == id);
            if (months == null)
            {
                return NotFound();
            }

            return View(months);
        }

        // POST: Months/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var months = await _context.Month.FindAsync(id);
            _context.Month.Remove(months);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonthsExists(int id)
        {
            return _context.Month.Any(e => e.Id == id);
        }
    }
}
