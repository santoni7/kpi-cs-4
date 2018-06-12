using System;
using System.Collections.Generic;
using System.Linq;
class Graph
{
    private const int INF = Int32.MaxValue/4;
    public int N;
    public List<int> V; // vertice 
    public List<Edge> E;
    public int[,] m;
    public int[,] d;

    public Graph(int vertices, int edges){
        N = vertices;
        V = new List<int>();
        for(int i = 0; i < N ; ++i){
            V.Add(1);
        }
        E = new List<Edge>(edges);
    }

    public Graph(List<int> V, List<Edge> E){
        N = V.Count;
        this.V = V;
        this.E = E;
    }

    public void InitMatrices(){
        m = new int[N, N];
        d = new int[N, N];
        for(int i = 0; i < N; ++i){
            for(int j = 0; j < N; ++j){
                m[i,j] = 0;
                d[i,j] = INF;
                if(i == j) d[i,j] = 0;
            }
        }
        for(int k = 0; k < E.Count; ++k){
            Edge e = E[k];
            m[e.a, e.b] = e.d;
            m[e.b, e.a] = e.d;
            d[e.a, e.b] = e.d;
            d[e.b, e.a] = e.d;
        }
        ApplyFloydWarshall();
    }
    public static Graph FromConsole(){
        Func<String, int> readInt = (caption) => {
                Console.Write(caption + ": "); 
                return Convert.ToInt32(Console.ReadLine()); 
            }; 
        Func<int[]> readRoad = () => Console.ReadLine()
                .Split(' ').ToList()
                .Where((string s) => !String.IsNullOrWhiteSpace(s))
                .Select((string s) => Convert.ToInt32(s))
                .ToArray();
        int n = readInt("N"),
            k = readInt("K");
        Graph g = new Graph(n, k);
        for(int i = 0; i < k; ++i){
            Console.Write("Input road #" + i + ": ");
            var road = readRoad();
            while(road.Length < 3)
            {
                Console.WriteLine("Error occured. Try again.");
                road = readRoad();
            }
            int a = road[0], b = road[1], d = road[2];
            Edge e = new Edge(a, b, d);;
            g.E.Add(e);
        }
        g.InitMatrices();
        return g;
    }

    public void ApplyFloydWarshall(){
        Log.d("Before Floyd-Warshall: ");
        DumpGraph();
        for(int k = 0; k < N; ++k){
            for(int i = 0; i < N; ++i){
                for(int j = 0; j < N; ++j){
                    //if(i == j) continue;
                    //if(d[i, j] != 0 && d[i, k] + d[k, j] != 0)
                        d[i, j] = Math.Min(d[i, j], d[i, k] + d[k, j]);
                    //else if(d[i, j] == 0)
                    //    d[i, j] = d[i, k] + d[k, j];
                }
            }
        }
        Log.d("Floyd-Warshall algorithm applied. Dumping result graph:");
        DumpGraph();
    }
    private void DumpGraph(){
        Log.dLine("=====================");
        for(int i = 0; i < N; ++i){
            for(int j = 0; j < N; ++j){
                Log.d(d[i, j] + " ");
            }
            Log.dLine("");
        }
        Log.dLine("=====================");
    }
    
    public struct Edge{
        public int a, b;
        public int d; //distance
        public Edge(int a, int b, int d)  {
            this.a = a;
            this.b = b;
            this.d = d;
        }
    }
}