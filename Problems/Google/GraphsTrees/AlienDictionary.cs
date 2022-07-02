using System.Text;

namespace Problems.Google.GraphsTrees;

/// <summary>
/// Check Dfs Comments
/// </summary>
public class AlienDictionary
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="words"></param>
    /// <returns>Graph or null if invalid</returns>
    private Dictionary<char, HashSet<char>> CreateGraph(string[] words)
    {
        // Example: wrt , wrf
        // Based on the above input
        // we are certain that t comes BEFORE f
        
        // create adjacency list
        // add all characters with a new hashset of chars
        var adjacencyList = new Dictionary<char, HashSet<char>>();
        foreach (var word in words)
        foreach (var ch in word)
            adjacencyList.TryAdd(ch, new HashSet<char>());

        for (int i = 0; i < words.Length - 1; i++)
        {
            var wordOne = words[i];
            var wordTwo = words[i + 1];
            var minLength = Math.Min(wordOne.Length, wordTwo.Length);

            //if the two words have the same prefix
            // but wordOne is larger that wordTwo
            // This is invalid since the words should be lexicographically sorted
            // Example: You would expect to find in a dictionary the word tech
            // -------  before technology
            // No solution should apply to this edge case
            var haveTheSamePrefix = wordOne[..minLength] == wordTwo[..minLength];
            var wordOneIsLarger = wordOne.Length > wordTwo.Length;
            if (wordOneIsLarger && haveTheSamePrefix)
                return null;

            //We actually insert to the adjacency list
            for (int j = 0; j < minLength; j++)
            {
                if (wordOne[j] != wordTwo[j])
                {
                    adjacencyList[wordOne[j]].Add(wordTwo[j]);
                    break; // we break since there is no way to know order after inequality
                }
            }
        }

        return adjacencyList;
    }

    private Dictionary<char, HashSet<char>> CreateGraph(string[] words, Dictionary<char, int> inDegree)
    {
        var adjacencyList = new Dictionary<char, HashSet<char>>();

        foreach (var word in words)
        foreach (var ch in word)
        {
            adjacencyList.TryAdd(ch, new HashSet<char>());
            inDegree.TryAdd(ch, 0);
        }

        for (int i = 0; i < words.Length - 1; i++)
        {
            var wordOne = words[i];
            var wordTwo = words[i + 1];
            var minLength = Math.Min(wordOne.Length, wordTwo.Length);

            var wordOneIsLarger = wordOne.Length > wordTwo.Length;
            var hasSamePrefix = wordOne[..minLength] == wordTwo[..minLength];
            if (wordOneIsLarger && hasSamePrefix) return null;

            for (int j = 0; j < minLength; j++)
            {
                if (wordOne[j] != wordTwo[j])
                {
                    if (adjacencyList[wordOne[j]].Contains(wordTwo[j])) break;
                    adjacencyList[wordOne[j]].Add(wordTwo[j]);
                    inDegree[wordTwo[j]]++;
                    break;
                }
            }
        }
        return adjacencyList;
    }

    /// <summary>
    /// Given words represented in a sorted order using the english letters
    /// Based on the info given we have to return the order of the words
    /// We have to find how to sort the letters
    /// </summary>
    /// <param name="words"></param>
    /// <returns></returns>
    public string GetOrderDfs(string[] words)
    {
        if (words is null || words.Length == 0)
            return string.Empty;

        var adjacencyList = CreateGraph(words);

        if (adjacencyList is null) 
            return string.Empty;
        
        var visited = new Dictionary<char, bool>(); // False = visited, True=current path
        var result = new StringBuilder();
        
        foreach (var ch in adjacencyList.Keys)
        {
            if (Dfs(ch)) // Detected a loop
            {
                return System.String.Empty;
            }
        }

        bool Dfs(char c)
        {
            if (visited.ContainsKey(c)) 
                return visited[c];
            visited.Add(c, true);
            
            foreach(var neighbor in adjacencyList[c])
                if (Dfs(neighbor))
                    return true;

            visited[c] = false;
            result.Append(c);
            return false;
        }
        // Edge case 1: based on the first example
        // We can see that if we have the below order
        // w -> e -> r -> t -> f
        // if a f points to w
        // Then we have to return no solution
        // Since a cycle has been detected
        // No way of proving order
        
        // Use post order dfs!!!
        // This will result with the reverse order
        // we have to reverse the string returned
        return new string(result.ToString().Reverse().ToArray());
    }
    
    /// <summary>
    /// Given words represented in a sorted order using the english letters
    /// Based on the info given we have to return the order of the words
    /// We have to find how to sort the letters
    /// </summary>
    /// <param name="words"></param>
    /// <returns></returns>
    public string GetOrderBfs(string[] words)
    {
        if (words is null || words.Length == 0)
            return string.Empty;

        var inDegree = new Dictionary<char, int>();
        var adjacencyList = CreateGraph(words,inDegree);

        var queue = new Queue<char>();
        var sb = new StringBuilder();

        foreach (var ch in inDegree.Keys)
        {
            if(inDegree[ch] == 0) queue.Enqueue(ch);
        }

        while (queue.Any())
        {
            var current = queue.Dequeue();
            sb.Append(current);

            foreach (var neighbor in adjacencyList[current])
            {
                inDegree[neighbor]--;
                if(inDegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }

        if (sb.Length < inDegree.Keys.Count) return string.Empty;

        return sb.ToString();
    }
    
}