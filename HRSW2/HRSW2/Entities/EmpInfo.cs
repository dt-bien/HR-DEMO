using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities
{
    public class EmpInfo
    {
        public int Id { get; set; }
        public string IdEmp { get; set; }
        public int SocialNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public DateTime Updated { get; set; }
        public DateTime JoinDay { get; set; }
        public DateTime LeaveDay { get; set; }

        //FK position
        public int PosId { get; set; }
        public Position Position { get; set; }

        public ICollection<OffDay> OffDay { get; set; }
        public ICollection<MonthsSalary> MonthsSalary { get; set; }
       
    }
}
