using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSW2.DatabaseContext;
using HRSW2.Entities;
using HRSW2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HRSW2.Controllers
{
    public class SalaryReportController : Controller
    {
        private readonly HrDbContext _context;

        public SalaryReportController(HrDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var salaryReport = new SalaryReport();
            salaryReport.MonthList = new SelectList(_context.Month, "Id", "MonthName");
            salaryReport.DepartmentList = new SelectList(_context.Department, "Id", "DepName");
            return View(salaryReport);
        }
        [HttpPost]
        public IActionResult GetReport([Bind("EmpId,EmpName,DepId,DepName,PosName,MonthId,TotalSalary")] SalaryReport oSalaryReport )
        {
            var MonthId = oSalaryReport.MonthId;
            var DepId = oSalaryReport.DepId;

           

            // get DepId == Pos
            var Report = from p in _context.Position.ToList()
                          join d in _context.Department.ToList() on p.DepId equals d.Id
                          join e in _context.EmpInfo.ToList() on p.Id equals e.PosId
                          join es in _context.MonthsSalary.ToList() on e.Id equals es.EmpId
                          join s in _context.Salary.ToList() on es.SalaryId equals s.Id
                          join m in _context.Month.ToList() on s.MonthId equals m.Id
                          where d.Id == DepId && m.Id == MonthId
                          select new SalaryReport()
                          {
                            EmpId = int.Parse( e.IdEmp),
                            EmpName =  e.Name,
                            DepId = int.Parse( d.DepId),
                            DepName =  d.DepName,
                            PosName =   p.NamePos,
                            MonthId = m.Id,
                            MonthName =  m.MonthName,
                             TotalSalary= s.TotalSalary
                          };


            return View(Report);
        }
        
    }
}
