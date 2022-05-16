namespace Problems.Google.GraphsTrees;

public static class EvaluateEquation
{
    public static double[] CalcEquation(IList<IList<string>> equations, 
        double[] values, 
        IList<IList<string>> queries)
    {
        var graph = BuildGraph(equations, values);
        Span<double> answers = stackalloc double[queries.Count];
        int i = 0;

        foreach (var query in queries)
        {
            var visited = new HashSet<string>();
            if (query[0] == query[1])
            {
                // If answer does not exist in the graph then we should input  -1
                answers[i++] = graph.ContainsKey(query[0])
                    ? 1.0 : -1.0;
                continue;
            }

            double result = DFS(query[0], query[1], graph, visited);
            answers[i++] = result;
        }
        
        return answers.ToArray();
    }

    private static double DFS(string start, string end, 
        Dictionary<string,Dictionary<string,double>> graph, 
        HashSet<string> visited)
    {
        if (!graph.ContainsKey(start))
            return -1.0;

        if (graph[start].ContainsKey(end))
        {
            return graph[start][end];
        }

        visited.Add(start);
        var startMap = graph[start];
        foreach (var entry in startMap)
        {
            if (!visited.Contains(entry.Key))
            {
                double current = DFS(entry.Key, end, graph, visited);

                if (current != -1.0)
                    return current * entry.Value;
            }
        }
        
        return -1.0;
    }


    private static Dictionary<string, Dictionary<string, double>> BuildGraph(IList<IList<string>> equations
        , double[] values)
    {
        var graph = new Dictionary<string, Dictionary<string, double>>();
        int n = equations.Count;

        for (int i = 0; i < n; i++)
        {
            var equation = equations[i];
            string num = equation[0];
            string den = equation[1];

            var current = values[i];

            if (!graph.ContainsKey(num))
            {
                graph.Add(num, new Dictionary<string, double>());
            }
            
            if (!graph.ContainsKey(den))
            {
                graph.Add(den, new Dictionary<string, double>());
            }
            
            graph[num].Add(den, current); // a/b = 2
            graph[den].Add(num, 1 / current); // inverse the result b/a = 1/2
        }

        return graph;
    }


}