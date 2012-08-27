using System;
using System.Collections.Generic;
using TrainsExpress.Common.Entities;

namespace TrainsExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            var routes = new[]
                             {
                                 new Route("A", "B", 3),
                                 new Route("B", "A", 3),
                                 new Route("A", "D", 6),
                                 new Route("B", "C", 7),
                                 new Route("C", "D", 8),
                                 new Route("D", "E", 9),
                                 new Route("E", "D", 9),
                                 new Route("D", "C", 9),
                                 new Route("D", "B", 5),
                                 new Route("C", "E", 3)
                             };
            IRouteFinderInterface routeFinderInterface = new RouteFinderInterface(new DijkstraRouteFinder.DijkstraRouteFinder(), routes);
            var fromAndToStations = routeFinderInterface.GetStationsFromConsole();
            var bestRoute = routeFinderInterface.FindBestRoute(fromAndToStations.Item1, fromAndToStations.Item2);
            routeFinderInterface.DisplayResults(bestRoute);
            Console.ReadLine();
        }

    }

}
