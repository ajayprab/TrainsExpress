using NUnit.Framework;
using TrainsExpress.Common.Contracts;
using TrainsExpress.Common.Entities;
using System.Linq;


namespace DijkstraRouteFinder.Tests
{
    [TestFixture]
    public class DijsktraRouteFinderTests
    {
        private Route[] routes = new[]
                                     {
                                         new Route("A","B",3),
                                         new Route("B","A",3),
                                         new Route("A","D",6),
                                         new Route("B","C",7),
                                         new Route("C","D",8),
                                         new Route("D","E",9),
                                         new Route("E","D",9),
                                         new Route("D","C",9),
                                         new Route("D","B",5),
                                         new Route("C","E",3)
                                     };
        [Test]
        public void FindsShortestRouteBetweenTwoStationsNoChange()
        {
            IRouteFinder routeFinder = new DijkstraRouteFinder();
            var routeAtoB = routeFinder.FindShortestRoute(routes, "A", "B");
            Assert.That(routeAtoB.Item1, Has.Count.EqualTo(2));
            Assert.That(routeAtoB.Item1.ElementAt(0), Has.Count.EqualTo("A"));
            Assert.That(routeAtoB.Item1.ElementAt(1), Has.Count.EqualTo("B"));
            Assert.That(routeAtoB.Item2, Is.EqualTo(3));
        }

        [Test]
        public void FindsShortestRouteBetweenTwoStationsMoreThanOneChange()
        {
            IRouteFinder routeFinder = new DijkstraRouteFinder();
            var routeAtoB = routeFinder.FindShortestRoute(routes, "D", "A");
            Assert.That(routeAtoB.Item1, Has.Count.EqualTo(3));
            Assert.That(routeAtoB.Item1.ElementAt(0), Has.Count.EqualTo("D"));
            Assert.That(routeAtoB.Item1.ElementAt(1), Has.Count.EqualTo("B"));
            Assert.That(routeAtoB.Item1.ElementAt(2), Has.Count.EqualTo("A"));
            Assert.That(routeAtoB.Item2, Is.EqualTo(3));
        }
    }
}
