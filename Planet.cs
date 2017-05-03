using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithList
{
    class Planet
    {
        public string Name     { get; private set; }
        public double Mass     { get; private set; }
        public double Radius   { get; private set; }
        public double Distance { get; private set; }

        public Planet nextMassPl     { get; set; }
        public Planet nextRadiusPl   { get; set; }
        public Planet nextDistancePl { get; set; }

        public PlanetSystem plSystem { get; set; }

        public Planet(string name, double mass, double radius, double distance)
        {
            Name = name; Mass = mass; Radius = radius; Distance = distance;
        }

        public override string ToString()
        {
            if(plSystem != null)
                return string.Format("Planet {0} has m = {1} kg and r = {2} km and is located in {3} km from {4}",
                                    Name, Mass, Radius, Distance, plSystem.StarName);

            return string.Format("Planet {0} has m = {1} kg and r = {2} km. System unknown",
                                    Name, Mass, Radius);
        }
    }
}
