using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithList
{
    class PlanetSystem: IEnumerable<Planet>
    {
        public string StarName { get; private set; }

        List<Planet> planets;

        public PlanetSystem(string starName)
        {
            StarName = starName;
            planets = new List<Planet>();
        }

        public void AddPlanet(Planet newPlanet)
        {
            planets.Add(newPlanet);
            newPlanet.plSystem = this;
        }


        IEnumerator<Planet> IEnumerable<Planet>.GetEnumerator()
        {
            return ((IEnumerable<Planet>)planets).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Planet>)this).GetEnumerator();
        }
    }
}
