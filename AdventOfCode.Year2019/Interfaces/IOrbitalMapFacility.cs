using System.Collections.Generic;

namespace AdventOfCode.Year2019.Interfaces
{
    public interface IOrbitalMapFacility
    {
        int CalculateOrbits(List<(string parent, string body)> data);
        int CalculateOrbitalTransfers(List<(string parent, string body)> data, string startNode, string endNode);
    }
}