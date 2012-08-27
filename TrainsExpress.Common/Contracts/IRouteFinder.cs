using System;
using System.Collections.Generic;
using TrainsExpress.Common.Entities;

namespace TrainsExpress.Common.Contracts
{
    public interface IRouteFinder
    {
        Tuple<IEnumerable<string>, int> FindShortestRoute(IEnumerable<Route> routes, string from, string to);
    }
}
