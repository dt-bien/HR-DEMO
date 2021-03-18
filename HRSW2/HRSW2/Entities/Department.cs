using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string DepId { get; set; }
        public string DepName { get; set; }

       
        public DateTime Updated { get; set; }

        public ICollection<Position> Position { get; set; }



    }
}
