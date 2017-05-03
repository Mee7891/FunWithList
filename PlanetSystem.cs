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

        SortState sortState = SortState.byDistance; 

        public PlanetSystem(string starName)
        {
            StarName = starName;
            planets = new List<Planet>();
        }

        public void AddPlanet(Planet newPlanet)
        {
            planets.Add(newPlanet);
            newPlanet.plSystem = this;

            switch(sortState)
            {
                case SortState.byMass:
                    {
                        SortByMass();
                        break;
                    }
                case SortState.byRadius:
                    {
                        SortByRadius();
                        break;
                    }
                case SortState.byDistance:
                    {
                        SortByDistance();
                        break;
                    }
            }
        }

        public void SortByMass()
        {
            if (planets.Count > 0)
            {
                List<Planet> planetsOrdered  =  planets.OrderBy(p => p.Mass).ToList();

                planets = planetsOrdered;

                for (int i = planets.Count; --i > 0;)
                {
                    planets[i - 1].nextMassPl = planets[i];
                }
            }

            sortState = SortState.byMass;
        }

        public void SortByRadius()
        {
            if (planets.Count > 0)
            {
                List<Planet> planetsOrdered = planets.OrderBy(p => p.Radius).ToList();

                planets = planetsOrdered;

                for (int i = planets.Count; --i > 0;)
                {
                    planets[i - 1].nextRadiusPl = planets[i];
                }
            }

            sortState = SortState.byRadius;
        }

        public void SortByDistance()
        {
            if (planets.Count > 0)
            {
                List<Planet> planetsOrdered = planets.OrderBy(p => p.Distance).ToList();

                planets = planetsOrdered;

                for (int i = planets.Count; --i > 0;)
                {
                    planets[i - 1].nextDistancePl = planets[i];
                }
            }

            sortState = SortState.byDistance;
        }

        IEnumerator<Planet> IEnumerable<Planet>.GetEnumerator()
        {
            return ((IEnumerable<Planet>)planets).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Planet>)this).GetEnumerator();
        }

        enum SortState { byMass, byRadius, byDistance };
    }
}
