using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRSW2.DatabaseContext;
using HRSW2.Entities;

namespace HRSW2.Controllers
{
    public class MonthsSalariesController : Controller
    {
        private readonly HrDbContext _context;

        public MonthsSalariesController(HrDbContext context)
        {
            _context = context;
        }

        // GET: MonthsSalaries
        public async Task<IActionResult> Index()
        {
            var hrDbContext = _context.MonthsSalary.Include(m => m.EmpInfo.Position).Include(m => m.Salary);
           
            return View(await hrDbContext.ToListAsync());
        }

        // GET: MonthsSalaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthsSalary = await _context.MonthsSalary
                .Include(m => m.EmpInfo)
                .Include(m => m.Salary)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monthsSalary == null)
            {
                return NotFound();
            }

            return View(monthsSalary);
        }

        // GET: MonthsSalaries/Create
        public IActionResult Create()
        {
            ViewData["EmpId"] = new SelectList(_context.EmpInfo, "Id", "IdEmp");
            ViewData["EmpName"] = new SelectList(_context.EmpInfo, "Id", "Name");
            ViewData["SalaryId"] = new SelectList(_context.Salary, "Id", "Id");
            ViewData["TotalSalary"] = new SelectList(_context.Salary, "Id", "TotalSalary");
            
            return View();
        }

        // POST: MonthsSalaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpId,SalaryId")] MonthsSalary monthsSalary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monthsSalary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpId"] = new SelectList(_context.EmpInfo, "Id", "Address", monthsSalary.EmpId);
            ViewData["SalaryId"] = new SelectList(_context.Salary, "Id", "Id", monthsSalary.SalaryId);
            return View(monthsSalary);
        }

        // GET: MonthsSalaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthsSalary = await _context.MonthsSalary.FindAsync(id);
            if (monthsSalary == null)
            {
                return NotFound();
            }
            ViewData["EmpId"] = new SelectList(_context.EmpInfo, "Id", "Address", monthsSalary.EmpId);
            ViewData["SalaryId"] = new SelectList(_context.Salary, "Id", "Id", monthsSalary.SalaryId);
            return View(monthsSalary);
        }

        // POST: MonthsSalaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpId,SalaryId")] MonthsSalary monthsSalary)
        {
            if (id != monthsSalary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monthsSalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthsSalaryExists(monthsSalary.Id))
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
            ViewData["EmpId"] = new SelectList(_context.EmpInfo, "Id", "Address", monthsSalary.EmpId);
            ViewData["SalaryId"] = new SelectList(_context.Salary, "Id", "Id", monthsSalary.SalaryId);
            return View(monthsSalary);
        }

        // GET: MonthsSalaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthsSalary = await _context.MonthsSalary
                .Include(m => m.EmpInfo)
                .Include(m => m.Salary)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monthsSalary == null)
            {
                return NotFound();
            }

            return View(monthsSalary);
        }

        // POST: MonthsSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monthsSalary = await _context.MonthsSalary.FindAsync(id);
            _context.MonthsSalary.Remove(monthsSalary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonthsSalaryExists(int id)
        {
            return _context.MonthsSalary.Any(e => e.Id == id);
        }
    }
}
