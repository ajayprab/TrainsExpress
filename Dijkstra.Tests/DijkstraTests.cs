using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra.Tests
{
    [TestFixture]
    public class DijkstraTests
    {
        /* Takes adjacency matrix in the following format, for a directed graph (2-D array)
         * Ex. node 1 to 3 is accessible at a cost of 4
         *        0  1  2  3  4 
         *   0  { 0, 2, 5, 0, 0},
         *   1  { 0, 0, 0, 4, 0},
         *   2  { 0, 6, 0, 0, 8},
         *   3  { 0, 0, 0, 0, 9},
         *   4  { 0, 0, 0, 0, 0}
         */

        double[,] adjacencyMatrix = {  
                                    { 0, 2, 5, 0, 0},
                                    { 0, 0, 0, 4, 0},
                                    { 0, 6, 0, 0, 8},
                                    { 0, 0, 0, 0, 9},
                                    { 0, 0, 0, 0, 0} };

        [SetUp]
        public void Setup()
        {
          
        }


        [Test]
        public void VerifyShortestPointBetweenTwoEdgesWithMoreThanOneRoute()
        {
            Dijkstra dijsktra = new Dijkstra(adjacencyMatrix, 0);

            Console.Write("Path is  : ");
            foreach (int i in dijsktra.path)
            {
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();
            Console.Write("Dist is : ");
            foreach (int i in dijsktra.dist)
            {
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();

            Assert.That(dijsktra.path[4], Is.EqualTo(2));
            Assert.That(dijsktra.dist[4], Is.EqualTo(13));
        }

    }
}
