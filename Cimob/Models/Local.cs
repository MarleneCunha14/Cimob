using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    public class Local
    {
        public int Id { get; set; }

        public String Address { get; set; }

        public String Lat{ get; set; }

        public String Long { get; set; }

        public int Rating { get; set; }

        public int Zoom { get; set; }
    }
}
