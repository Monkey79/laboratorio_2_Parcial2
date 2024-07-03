using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackLibs.Entities;

namespace BackLibs.Utils
{
    public static class ExtensoraRandom
    {
        public static int GenerarRandom(this List<Serie> series) {
            Random random = new Random();
            return random.Next(0, series.Count);
        }
    }
}
