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

        public String Adress { get; set; }

        public float Lat { get; set; }

        public float Long { get; set; }

        public int Rating { get; set; }

        public int Zoom { get; set; }


    }
}
