using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;


namespace AD
{
    public partial class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;
        public Dictionary<string, Vertex> vertexMap;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Graph()
        {
            vertexMap = new Dictionary<string, Vertex>();
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Adds a vertex to the graph. If a vertex with the given name
        ///    already exists, no action is performed.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public void AddVertex(string name)
        {
            if (vertexMap.ContainsKey(name)) return;
            vertexMap.Add(name, new Vertex(name));
        }

        /// <summary>
        ///    Gets a vertex from the graph by name. If no such vertex exists,
        ///    a new vertex will be created and returned.
        /// </summary>
        /// <param name="name">The name of the vertex</param>
        /// <returns>The vertex withe the given name</returns>
        public Vertex GetVertex(string name)
        {
            if (vertexMap.ContainsKey(name)) return vertexMap[name];
            AddVertex(name);
            return vertexMap[name];
        }


        /// <summary>
        ///    Creates an edge between two vertices. Vertices that are non existing
        ///    will be created before adding the edge.
        ///    There is no check on multiple edges!
        /// </summary>
        /// <param name="source">The name of the source vertex</param>
        /// <param name="dest">The name of the destination vertex</param>
        /// <param name="cost">cost of the edge</param>
        public void AddEdge(string source, string dest, double cost = 1)
        {
            Vertex s = GetVertex(source);
            Vertex d = GetVertex(dest);
            s.adj.AddLast(new Edge(d, cost));
        }


        /// <summary>
        ///    Clears all info within the vertices. This method will not remove any
        ///    vertices or edges.
        /// </summary>
        public void ClearAll()
        {
            foreach(Vertex v in vertexMap.Values)
            {
                v.Reset();
            }
        }

        /// <summary>
        ///    Performs the Breath-First algorithm for unweighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Unweighted(string name)
        {
            ClearAll(); // reset all distances and knowns
            
            Queue<Vertex> queue = new Queue<Vertex>();
            Vertex start = GetVertex(name); // get start vertex
            
            start.distance = 0; // distance to start vertex is 0
            
            queue.Enqueue(start); // add start vertex to queue

            while (queue.Any()) // while there are vertexes in queue
            {
                Vertex prev = queue.Dequeue(); // get Vertex from front of queue
                
                foreach (Edge e in prev.adj) // for all connected vertexes
                {
                    Vertex next = e.dest;
                    if (next.distance == INFINITY) // if distance is not already set
                    {
                        next.distance = prev.distance + 1; // add previous vertex distance plus 1
                        queue.Enqueue(next); // add next to queue
                    }
                }
            }

        }

        /// <summary>
        ///    Performs the Dijkstra algorithm for weighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Dijkstra(string name)
        {
            ClearAll(); // reset al distances and knowns
            
            PriorityQueue<Vertex> queue = new PriorityQueue<Vertex>();
            Vertex start = GetVertex(name); // get start vertex
            
            start.distance = 0; // distance to start vertex is 0
            
            queue.Add(start); // add start vertex to queue

            while (!queue.IsEmpty()) // while there are vertex in queue
            {
                Vertex prev = queue.Remove(); // get vertex with smallest distance
                if (prev.known == false) // if not already visited, continue
                {
                    prev.known = true; // visited is true

                    foreach (Edge edge in prev.adj) // for all connected vertexes
                    {
                        Vertex next = edge.dest;
                        double newDistance = prev.distance + edge.cost; // distance from previous vertex

                        if (newDistance < next.distance) // if the new calculated distance is shorter then the registered distance
                        {
                            next.distance = newDistance; // set new distance
                            next.prev = prev; // set new previous vertex
                        }
                        queue.Add(next); // add next vertex to queue
                    }
                }
            }
        }

        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Graph to its string representation.
        ///    It will call the ToString method of each Vertex. The output is
        ///    ascending on vertex name.
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns>
        public override string ToString()
        {
            string result = "";
            foreach (string key in vertexMap.Keys.OrderBy(x => x))
            {
                result += vertexMap[key].ToString();
            }

            return result;
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------



        public bool IsConnected()
        {
            throw new System.NotImplementedException();
        }

    }
}