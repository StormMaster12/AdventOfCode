using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AdventOfCode.Year2019.Interfaces;

namespace AdventOfCode.Year2019.Implementations
{
    public class OrbitalMapFacility : IOrbitalMapFacility
    {
        public int CalculateOrbits(List<(string parent, string body)> data)
        {
            var orbits = CreatePlanetList(data);
            foreach (var planet in orbits)
            {
                var count = 0;
                planet.OrbitCounts = FindHeirachy(planet, count, new List<Planet>());
            }

            return orbits.Sum(x => x.OrbitCounts);
        }

        public int CalculateOrbitalTransfers(List<(string parent, string body)> data, string startNode, string endNode)
        {
            var orbits = CreatePlanetList(data);
            var listStartNode = new List<Planet>();
            var listEndNode = new List<Planet>();

            var startPlanet = orbits.Find(x => x.Name == startNode);
            var endPlanet = orbits.Find(x => x.Name == endNode);

            FindHeirachy(startPlanet, 0, listStartNode);
            FindHeirachy(endPlanet, 0, listEndNode);

            var crossingPoint = listEndNode.Intersect(listStartNode).First();

            return GetSteps(startPlanet, crossingPoint, 0) + GetSteps(endPlanet, crossingPoint, 0);
        }

        private int GetSteps(Planet planet, Planet crossingPlanet, int steps)
        {
            if (planet.Parent.Equals(crossingPlanet))
                return steps;

            steps++;
            return GetSteps(planet.Parent, crossingPlanet, steps);
        }

        private List<Planet> CreatePlanetList(List<(string parent, string body)> data)
        {
            var orbits = new List<Planet>();
            orbits.Add(new Planet("COM", null));
            foreach (var valueTuple in data)
            {
                orbits.Add(new Planet(valueTuple.body, valueTuple.parent));
            }

            foreach (var orbit in orbits)
            {
                orbit.Parent = orbits.FirstOrDefault(x => x.Name == orbit.ParentName);
                orbit.Orbits = orbits.Where(x => x.ParentName == orbit.Name);
            }

            return orbits;
        }

        private int FindHeirachy(Planet planet, int count, List<Planet> planets)
        {
            if (string.IsNullOrEmpty(planet.ParentName))
            {
                return count;
            }

            count++;
            planets.Add(planet.Parent);
            return FindHeirachy(planet.Parent, count, planets);
        }
    }

    public class Planet : IEquatable<Planet>
    {
        public string Name { get; set; }
        public IEnumerable<Planet> Orbits { get; set; }
        public string ParentName { get; set; }
        public Planet Parent { get; set; }
        public int OrbitCounts { get; set; }

        public Planet(string name, string parent)
        {
            Name = name;
            ParentName = parent;
        }

        public bool Equals(Planet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Planet)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}