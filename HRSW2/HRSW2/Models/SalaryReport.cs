using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Models
{
    public class SalaryReport
    {
        public SalaryReport()
        {

        }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int DepId { get; set; }
        public string DepName { get; set; }
        public string PosName { get; set; }
       
        public int MonthId { get; set; }
        public string    MonthName { get; set; }
        public double TotalSalary { get; set; }

        public SelectList DepartmentList { get; set; }
        public SelectList MonthList { get; set; }


    }
}
