using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    //Classe Mapa
    public class Mapa
    {
        public int Id { get; set; }

        public String Address { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public int Rating { get; set; }

        public int Zoom { get; set; }


    }
}
