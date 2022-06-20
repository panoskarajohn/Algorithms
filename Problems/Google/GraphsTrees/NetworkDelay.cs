using System.Collections;

namespace Problems.Google.GraphsTrees;

public class NetworkDelay
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        List<(int node, int weight)>[] adjList = new List<(int node, int weight)>[n+1];
        
        for(var i =0; i<= n; i++ ){
            adjList[i] = new List<(int node, int weight)>();
        }
        
        foreach( var time in times){
            adjList[time[0]].Add((time[1],time[2]));
        }
        
        bool[] visited = new bool[n+1];
        
        PriorityQueue<int,int> pq = new PriorityQueue<int,int>();
        
        pq.Enqueue(k,0);
        int result = 0;
        int visitedCount = 0;
        while(pq.TryDequeue(out int node, out int weight)){
            if(visited[node]) continue;
            visitedCount++;
            visited[node] = true;
            result = Math.Max(result,weight);
            foreach(var adj in adjList[node]){
                var totalWeight = weight + adj.weight;
                pq.Enqueue(adj.node,totalWeight);
            }
        }
        return visitedCount == n ? result : -1;
    }
        
}
    