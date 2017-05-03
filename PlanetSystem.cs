using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithList
{
    class PlanetSystem
    {
        public string StarName { get; private set; }

        List<Planet> planets;

        public PlanetSystem(string starName)
        {
            StarName = starName;
            planets = new List<Planet>();
        }
    }
}
