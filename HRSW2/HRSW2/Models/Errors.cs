using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Models
{
    public class Errors
    {

        public Errors()
        {

        }
        public Errors(string msg)
        {
            MessageError = msg;
        }
        public string MessageError { get; set; }
    }
}
