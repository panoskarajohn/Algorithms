namespace Problems.Google.GraphsTrees;

public class MinimumHeightTrees
{
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        if (n < 2) return Enumerable.Range(0, n).ToList();

        // Build the adjacency list
        var neighbors = new HashSet<int>[n];
        for (var i = 0; i < n; i++)
            neighbors[i] = new HashSet<int>();

        foreach (var edge in edges)
        {
            var start = edge[0];
            var end = edge[1];

            neighbors[start].Add(end);
            neighbors[end].Add(start);
        }

        //Initialize the first layer of leaves
        var leaves = new List<int>();
        for (var i = 0; i < n; i++)
            if (neighbors[i].Count == 1)
                leaves.Add(i);

        //Trim the leaves until reaching the centroids
        var remainingNodes = n;

        while (remainingNodes > 2)
        {
            remainingNodes -= leaves.Count;
            var newLeaves = new List<int>();

            foreach (var leaf in leaves)
            {
                using var enumerator = neighbors[leaf].GetEnumerator();
                enumerator.MoveNext();
                var neig = enumerator.Current;

                neighbors[neig].Remove(leaf);
                if (neighbors[neig].Count == 1)
                    newLeaves.Add(neig);
            }

            leaves = newLeaves;
        }

        return leaves;
    }
}