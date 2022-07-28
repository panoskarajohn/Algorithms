namespace Problems.Google.GraphsTrees;

public class ParallelCourses
{
    #region Kahn's Algorithm

    public int MinNumberOfSemesters(int n, int[][] relations)
    {
        var graph = CreateGraph(n, relations, out var inDegree);
        var semesters = 0;
        var numberOfClasses = 0;

        var zeroDegree = BuildZeroDegreeQueue(inDegree);

        while (zeroDegree.Any())
        {
            semesters++;
            var newQueue = new Queue<int>();

            foreach (var zero in zeroDegree)
            {
                numberOfClasses++;
                foreach (var neighbor in graph[zero])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0) newQueue.Enqueue(neighbor);
                }
            }

            zeroDegree = newQueue;
        }

        return numberOfClasses == n ? semesters : -1;
    }

    private Queue<int> BuildZeroDegreeQueue(Dictionary<int, int> inDegree)
    {
        var zeroDegree = new Queue<int>();

        foreach (var i in inDegree)
            if (i.Value == 0)
                zeroDegree.Enqueue(i.Key);

        return zeroDegree;
    }

    private Dictionary<int, HashSet<int>> CreateGraph(int n, int[][] relations, out Dictionary<int, int> inDegree)
    {
        var adjacencyList = new Dictionary<int, HashSet<int>>();
        inDegree = new Dictionary<int, int>();
        for (var i = 1; i < n + 1; i++) //problem never starts from 0 no need to check that
        {
            inDegree.Add(i, 0);
            adjacencyList.Add(i, new HashSet<int>());
        }

        foreach (var relation in relations)
        {
            adjacencyList[relation[0]].Add(relation[1]);
            inDegree[relation[1]]++;
        }

        return adjacencyList;
    }

    #endregion

    #region DFS

    public int MinNumberOfSemestersDfs(int n, int[][] relations)
    {
        var graph = BuildDfsGraph(n, relations);
        // We need to break the problem into two parts
        //Detect a cycle
        var visited = new int[n + 1];
        for (var i = 1; i < n + 1; i++)
            if (CheckDfsCycle(i, graph, visited) == -1)
                return -1;

        //We have not detected a cycle
        //Calculate the length of the longest path
        var visitedLength = new int[n + 1];
        var maxLength = 1;
        for (var i = 1; i < n + 1; i++)
        {
            var length = DfsMaxPath(i, graph, visitedLength);
            maxLength = Math.Max(length, maxLength);
        }

        return maxLength;
    }

    private int DfsMaxPath(int node, Dictionary<int, HashSet<int>> graph, int[] visitedLength)
    {
        if (visitedLength[node] != 0)
            return visitedLength[node];

        var max = 1;
        foreach (var neighbors in graph[node])
        {
            var length = DfsMaxPath(neighbors, graph, visitedLength);
            max = Math.Max(length + 1, max);
        }

        visitedLength[node] = max;
        return max;
    }

    private int CheckDfsCycle(int node, Dictionary<int, HashSet<int>> graph, int[] visited)
    {
        if (visited[node] != 0)
            return visited[node];
        visited[node] = -1; //mark as visiting

        foreach (var neighbor in graph[node])
            if (CheckDfsCycle(neighbor, graph, visited) == -1)
                return -1;

        visited[node] = 1; //mark as visited
        return 1;
    }

    private Dictionary<int, HashSet<int>> BuildDfsGraph(int n, int[][] relations)
    {
        Dictionary<int, HashSet<int>> adj = new();
        for (var i = 1; i < n + 1; i++) adj.Add(i, new HashSet<int>());

        foreach (var relation in relations) adj[relation[0]].Add(relation[1]);

        return adj;
    }

    #endregion
}