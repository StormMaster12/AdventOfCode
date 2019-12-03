using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AdventOfCode.Year2019.Interfaces;

namespace AdventOfCode.Year2019.Implementations
{
    public class FuelManagementSystem : IFuelManagementSystem
    {
        public double GetRequiredFuel(in double input)
        {
            return Math.Floor(input / 3d) - 2;
        }

        public double GetRequiredFuleForMultipleModules(IEnumerable<int> modules)
        {
            return modules.Sum(x => GetRequiredFuel(x));
        }

        public double GetRequiredFuleForModulesAndFuel(double input)
        {
            var fuel = GetRequiredFuel(input);
            if (fuel <= 0)
                return 0;
            return fuel + GetRequiredFuleForModulesAndFuel(fuel);
        }

        public double GetRequiredFuleForAllModulesAndFuel(IEnumerable<int> modules)
        {
            return modules.Sum(x => GetRequiredFuleForModulesAndFuel(x));
        }

        public double GetFrontPanelWiresClosestCrossingPoint(IEnumerable<IEnumerable<Vector2>> wires)
        {
            var vectorPoints = new List<Vector2>();

            foreach (var wire in wires)
            {
                var wirePos = new Vector2();
                foreach (var wireVector in wire)
                {
                    wirePos.X += wireVector.X;
                    wirePos.Y += wireVector.Y;

                    var matchingPoints = vectorPoints.Where(x => x.Equals(wirePos) && x.X != 0 && x.Y != 0);

                    if (matchingPoints != null && matchingPoints.Any())
                    {
                        var closestPoint = matchingPoints.Aggregate((curMin, x) =>
                            curMin.X < x.X && curMin.Y < x.Y ? x : curMin);

                        if (closestPoint != null)
                        {
                            return 100;
                        }
                    }
                    else
                    {
                        vectorPoints.Add(wirePos);
                    }
                }
            }

            Console.WriteLine(string.Join(',',vectorPoints.Take(301).ToList()));
            Console.WriteLine("--------------");
            Console.WriteLine(string.Join(',', vectorPoints.TakeLast(301).ToList()));
            Console.ReadLine();
            return 0;
        }
    }
}