using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRSW2.Entities;
using HRSW2.DatabaseContext;
using HRSW2.Models;

namespace HRSW2.Controllers
{
    public class SalariesController : Controller
    {
        private readonly HrDbContext _context;

        public SalariesController(HrDbContext context)
        {
            _context = context;
        }

        // GET: Salaries
        public async Task<IActionResult> Index()
        {
            var hrDbContext = _context.Salary.Include(s => s.Months).Include(s => s.Position);
            return View(await hrDbContext.ToListAsync());
        }

        // GET: Salaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.Salary
                .Include(s => s.Months)
                .Include(s => s.Position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // GET: Salaries/Create
        public IActionResult Create()
        {
            ViewData["MonthId"] = new SelectList(_context.Month, "Id", "MonthName");
            ViewData["PosId"] = new SelectList(_context.Position, "Id", "NamePos");
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BasicSalary,OTSalary,Bonus,TotalSalary,PosId,MonthId")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonthId"] = new SelectList(_context.Month, "Id", "Id", salary.MonthId);
            ViewData["PosId"] = new SelectList(_context.Position, "Id", "Id", salary.PosId);
            return View(salary);
        }

        // GET: Salaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.Salary.FindAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            ViewData["MonthId"] = new SelectList(_context.Month, "Id", "Id", salary.MonthId);
            ViewData["PosId"] = new SelectList(_context.Position, "Id", "Id", salary.PosId);
            return View(salary);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BasicSalary,OTSalary,Bonus,TotalSalary,PosId,MonthId")] Salary salary)
        {
            if (id != salary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryExists(salary.Id))
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
            ViewData["MonthId"] = new SelectList(_context.Month, "Id", "Id", salary.MonthId);
            ViewData["PosId"] = new SelectList(_context.Position, "Id", "Id", salary.PosId);
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.Salary
                .Include(s => s.Months)
                .Include(s => s.Position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var salary = await _context.Salary.FindAsync(id);
                _context.Salary.Remove(salary);
                await _context.SaveChangesAsync();
            }
            catch
            {
                RedirectToAction("Index", "Errors", new Errors("Delete fail"));
            }
          
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryExists(int id)
        {
            return _context.Salary.Any(e => e.Id == id);
        }
    }
}
