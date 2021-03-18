using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities
{
    public class Months
    {

        public int Id { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public DateTime Updated { get; set; }
        public ICollection<Salary> Salary { get; set; }

    }
}
