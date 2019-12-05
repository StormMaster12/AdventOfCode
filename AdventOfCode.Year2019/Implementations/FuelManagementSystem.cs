using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using AdventOfCode.Business.Enums;
using AdventOfCode.Business.Extensions;
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

        public double GetFrontPanelWiresClosestCrossingPoint(IEnumerable<string> wire1, IEnumerable<string> wire2)
        {
            var path1 = CreatePath(wire1);
            var path2 = CreatePath(wire2);

            var intersections = path1.Keys.Intersect(path2.Keys);

            return intersections.Min(x => Math.Abs(x.x) + Math.Abs(x.y));
        }

        public double GetFrontPanelWiresShortestPathCrossingPoint(IEnumerable<string> wire1, IEnumerable<string> wire2)
        {
            var path1 = CreatePath(wire1);
            var path2 = CreatePath(wire2);

            var intersections = path1.Keys.Intersect(path2.Keys);

            return intersections.Min(x => path1[x] + path2[x]);
        }

        private Dictionary<(int x, int y), int> CreatePath(IEnumerable<string> input)
        {
            var regex = new Regex(@"([a-zA-Z]+)(\d+)");
            var path = new Dictionary<(int x, int y), int>();
            var pathCount = 0;
            int x = 0, y = 0;

            foreach (var s in input)
            {
                var result = regex.Match(s);

                var alphaPart = result.Groups[1].Value;
                var numberPart = int.Parse(result.Groups[2].Value);

                for (int i = 0; i < numberPart; i++)
                {
                    var directionEnum = alphaPart.GetValueFromDescription<VectorDirectionEnum>();

                    var v = directionEnum switch
                    {
                        VectorDirectionEnum.Right => (++x, y),
                        VectorDirectionEnum.Left => (--x, y),
                        VectorDirectionEnum.Down => (x, --y),
                        VectorDirectionEnum.Up => (x, ++y),
                        _ => throw new ArgumentOutOfRangeException()
                    };

                    path.TryAdd(v, ++pathCount);
                }
            }

            return path;
        }
    }
}