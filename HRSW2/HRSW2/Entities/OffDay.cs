using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities
{
    public class OffDay
    {
        public int Id { get; set; }
       
        public DateTime FromDay { get; set; }
        public DateTime ToDay { get; set; }
        public string  Description { get; set; }

        public DateTime Updated { get; set; }
        public int EmployeeId { get; set; }
        public EmpInfo EmpInfo { get; set; }
    }
}
