using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities
{
    public class Salary
    {
        public int Id { get; set; }

        public double BasicSalary { get; set; }
        public double OTSalary { get; set; }
        public double Bonus { get; set; }
        public double TotalSalary { get; set; }

        public DateTime Updated { get; set; }
        public Position Position { get; set; }
        public int PosId { get; set; }

        public Months Months { get; set; }
        public int MonthId { get; set; }
        public ICollection<MonthsSalary> MonthsSalary { get; set; }
    }
}
