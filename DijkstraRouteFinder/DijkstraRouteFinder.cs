using System;
using System.Collections.Generic;
using System.Linq;
using TrainsExpress.Common.Contracts;
using TrainsExpress.Common.Entities;

namespace DijkstraRouteFinder
{
    public class DijkstraRouteFinder : IRouteFinder
    {
        public Tuple<IEnumerable<string>, int> FindShortestRoute(IEnumerable<Route> routes, string from, string to)
        {
            Dijkstra.Dijkstra dijkstra;
            //Form adjacency matrix
            var stations = routes.Select(x => x.From)
                .Intersect(routes.Select(x => x.To))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var numberOfStations = stations.Count();

            var adjacencyMatrix = new double[numberOfStations,numberOfStations];
            foreach (var route in routes)
            {
                adjacencyMatrix[stations.IndexOf(route.From), stations.IndexOf(route.To)] = route.TimeTaken;
            }

            var fromStationIndex = stations.IndexOf(from);
            var toStationIndex = stations.IndexOf(to);


            dijkstra = new Dijkstra.Dijkstra(adjacencyMatrix, fromStationIndex);

            var routeToDestination = new List<string>();
            for (var currentNode = toStationIndex; currentNode != -1; currentNode = dijkstra.path[currentNode])
            {
                routeToDestination.Add(stations[currentNode]);
            }

            routeToDestination.Reverse();
            return Tuple.Create<IEnumerable<string>, int>(routeToDestination, (int)dijkstra.dist[toStationIndex]);
        }
    }
}
