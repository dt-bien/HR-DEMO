using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string NamePos { get; set; }
        public string Description { get; set; }

        public DateTime Updated { get; set; }
        public ICollection<EmpInfo> EmpInfo { get; set; }

        public Department Department { get; set; }
        public int DepId { get; set; }

        public ICollection<Salary> Salary { get; set; }
    }
}
