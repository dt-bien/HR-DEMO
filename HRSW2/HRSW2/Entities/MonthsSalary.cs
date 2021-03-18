using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities
{
    public class MonthsSalary
    {
        public int Id { get; set; }
      
        public int EmpId { get; set; }
        public EmpInfo  EmpInfo { get; set; }
        public int SalaryId { get; set; }
        public Salary Salary { get; set; }
    }
}
