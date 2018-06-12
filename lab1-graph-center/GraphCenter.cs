using System;

/*
 * Hakimi method to find absolute graph center.
 * See more: http://rain.ifmo.ru/cat/data/theory/graph-location/centers-2006/article.pdf
 */
class GraphCenter{
    private static int INF = Int32.MaxValue /4;
    public static (Graph.Edge e, int eps, int minVal) Find(Graph G){
        int totalMin = 99999, totalMinK = -1, totalMinEps = -1, totalMinI = -1;
        for(int k = 0; k < G.E.Count; ++k){
            Graph.Edge ak = G.E[k];
            Log.dLine(String.Format("Processing edge #{0}: {1}->{2}={3}", k, ak.a, ak.b, ak.d));
            //s(yk) =  max[vi * d(yk, xi)];
            int curMin = INF, curMinI = -1, curMinEps = 0;
            for(int eps = 0; eps <= ak.d; ++eps){
                int max = -1, maxi = -1;
                for(int i = 0; i < G.N; ++i){
                    if(i == ak.a || i == ak.b) continue;
                    int val = G.V[i] * Math.Min(eps + G.d[ak.b, i], ak.d - eps + G.d[ak.a, i]);
                    Log.dLine(
                        String.Format("i={5}, {0}->{1}={2}, eps={3}, val={4}", ak.a, ak.b, ak.d, eps, val, i)
                    );
                    if(val > max){
                        max = val;
                        maxi = i;
                    }
                }
                Log.dLine("-----------");
                if(max < curMin){
                    curMin = max;
                    curMinI = maxi;
                    curMinEps = eps;
                }
            }
            Log.dLine(
                String.Format("Edge processed. curMax={0} at i={1}, eps={2}", curMin, curMinI, curMinEps)  
            );
            Log.dLine("=================");
            if(curMin < totalMin){
                totalMin = curMin; 
                totalMinI = curMinI;
                totalMinK = k;
                totalMinEps = curMinEps;
            }
        }
        return (G.E[totalMinK], totalMinEps, totalMin);
    }
}