using System;
using System.Collections.Generic;
using System.Linq;
using TrainsExpress.Common.Contracts;
using TrainsExpress.Common.Entities;

namespace TrainsExpress
{
    public interface IRouteFinderInterface
    {
        Tuple<string, string> GetStationsFromConsole();
        Tuple<IEnumerable<string>, int> FindBestRoute(string fromStation, string toStation);
        void DisplayResults(Tuple<IEnumerable<string>, int> results);
    }

    public class RouteFinderInterface : IRouteFinderInterface
    {
        private IRouteFinder routeFinder;
        private Route[] routes;
        private IEnumerable<string> stations; 

        public RouteFinderInterface(IRouteFinder routeFinder, Route[] routes)
        {
            this.routeFinder = routeFinder;
            this.routes = routes;
            stations = routes.Select(x => x.From)
                .Intersect(routes.Select(x => x.To))
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        public Tuple<string,string> GetStationsFromConsole()
        {
            Console.WriteLine("Please enter the station you want to travel from : ");
            string fromStation;
            while (!stations.Contains(fromStation = Console.ReadLine()))
            {
                Console.WriteLine("Invalid station, try again");
            }

            Console.WriteLine("Please enter the station you want to travel to : ");
            string toStation;
            while (!stations.Contains(toStation = Console.ReadLine()))
            {
                Console.WriteLine("Invalid station, try again");
            }

            return Tuple.Create(fromStation, toStation);
        }

        public Tuple<IEnumerable<string>, int> FindBestRoute(string fromStation, string toStation)
        {
            return routeFinder.FindShortestRoute(routes, fromStation, toStation);
        }

        public void DisplayResults(Tuple<IEnumerable<string>, int> results)
        {
            Console.Write("The optimal route is  : ");
            foreach (var station in results.Item1)
            {
                Console.Write(station+" ");
            }
            Console.Write(", this should take you {0} minutes.", results.Item2);
        }
    }
}