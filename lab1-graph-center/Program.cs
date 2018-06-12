using System;

namespace lab1_graph_center
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.DisableDebug();
            Console.WriteLine("Input Graph: ");
            Graph G = Graph.FromConsole();
            
            var res = GraphCenter.Find(G);
            
            string o = String.Format("Graph center is on edge ({0}->{1} = {2}) at eps={3} with radius={4}",
                    res.e.a, res.e.b, res.e.d, res.eps, res.minVal);
            Console.WriteLine(o);
        }
    }
}
