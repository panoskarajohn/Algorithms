namespace Problems.Work;

public class TreeProductSolution
{
    /// <summary>
    /// https://app.codility.com/programmers/trainings/2/tree_product/
    /// </summary>
    /// <param name="numsA"></param>
    /// <param name="numsB"></param>
    /// <returns></returns>
    public static int TreeProduct(int[] numsA, int[] numsB)
    {
        var graph = BuildGraph(numsA, numsB);
        var groups = GetAllSubtreesWithTwoCuts(graph);
        
        int maxProduct = 0;
        foreach (var group in groups)
        {
            if (group.Count == 3)
            {
                int product = 1;
                foreach (var subtree in group)
                {
                    product *= subtree.Count;
                }
                maxProduct = Math.Max(maxProduct, product);
            }
        }
        
        
        return maxProduct;
    }
    
    private static List<List<List<int>>> GetAllSubtreesWithTwoCuts(Dictionary<int, List<int>> graph)
    {
        var result = new List<List<List<int>>>();
        var uniqueEdges = GetUniqueEdges(graph);
        
        //iterate over all unique edges
        for (int i = 0; i < uniqueEdges.Count; i++)
        {
            for (int j = i + 1; j < uniqueEdges.Count; j++)
            {
                var edge1 = uniqueEdges[i];
                var edge2 = uniqueEdges[j];
                
                RemoveEdge(graph, edge1);
                RemoveEdge(graph, edge2);
                
                var components = GetComponents(graph);
                if (components.Count == 3)
                {
                    result.Add(components);
                }
                
                AddEdge(graph, edge1);
                AddEdge(graph, edge2);
            }
        }
        
        return result;
    }
    
    private static List<List<int>> GetComponents(Dictionary<int, List<int>> graph)
    {
        var visited = new HashSet<int>();
        var components = new List<List<int>>();
        
        foreach (var node in graph.Keys)
        {
            if (!visited.Contains(node))
            {
                var component = new List<int>();
                Dfs(graph, node, visited, component);
                components.Add(component);
            }
        }
        
        return components;
    }

    private static void Dfs(Dictionary<int, List<int>> graph, int node, HashSet<int> visited, List<int> components)
    {
        var stack = new Stack<int>();
        stack.Push(node);
        visited.Add(node);

        while (stack.Count > 0)
        {
            int currnent = stack.Pop();
            components.Add(currnent);
            foreach (var neighbor in graph[currnent])
            {
                if (visited.Add(neighbor))
                {
                    stack.Push(neighbor);
                }
            }
        }
    }
    
    private static void AddEdge(Dictionary<int, List<int>> graph, (int start, int finish) edge)
    {
        if (graph.ContainsKey(edge.start) && !graph[edge.start].Contains(edge.finish))
        {
            graph[edge.start].Add(edge.finish);
        }
        
        if (graph.ContainsKey(edge.finish) && !graph[edge.finish].Contains(edge.start))
        {
            graph[edge.finish].Add(edge.start);
        }
    }
    
    private static void RemoveEdge(Dictionary<int, List<int>> graph, (int start, int finish) edge)
    {
        if (graph.ContainsKey(edge.start))
        {
            graph[edge.start].Remove(edge.finish);
        }
        if (graph.ContainsKey(edge.finish))
        {
            graph[edge.finish].Remove(edge.start);
        }
    }

    static List<(int start, int finish)> GetUniqueEdges(Dictionary<int, List<int>> graph)
    {
        var edges = new List<(int, int)>();
        foreach (var kvp in graph)
        {
            foreach(var neighbor in kvp.Value)
            {
                var startingEdge = kvp.Key;
                if (startingEdge < neighbor) // to avoid duplicates
                {
                    edges.Add((kvp.Key, neighbor));
                }
            }
        }
        
        return edges;
    }
 
    static Dictionary<int, List<int>> BuildGraph(int[] numsA, int[] numsB)
    {
        var graph = new Dictionary<int, List<int>>();
        for (int i = 0; i < numsA.Length; i++)
        {
            AddEdge(graph,(numsA[i],numsB[i]));
            if (!graph.ContainsKey(numsA[i]))
            {
                graph[numsA[i]] = new List<int>();
            }
            graph[numsA[i]].Add(numsB[i]);
            if (!graph.ContainsKey(numsB[i]))
            {
                graph[numsB[i]] = new List<int>();
            }
            graph[numsB[i]].Add(numsA[i]);
        }

        return graph;
    }

    
}