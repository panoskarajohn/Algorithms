namespace Problems.Google.GraphsTrees;

public class WordLadder
{
    private Dictionary<char, Dictionary<char, int>> _graph = new();

    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        if (!wordList.Contains(endWord))
            return 0;
        var queue = new Queue<string>();
        var words = new HashSet<string>(wordList);

        words.Remove(beginWord);
        queue.Enqueue(beginWord);

        var level = 0;

        while (queue.Any())
        {
            var size = queue.Count;
            level++;
            for (var i = 0; i < size; i++)
            {
                var current = queue.Dequeue();
                if (current == endWord) return level;

                var neighbors = GetNeighbors(current);
                foreach (var neighbor in neighbors)
                    if (words.Contains(neighbor))
                    {
                        words.Remove(neighbor);
                        queue.Enqueue(neighbor);
                    }
            }
        }

        return 0;
    }

    private IList<string> GetNeighbors(string wordNode)
    {
        var chars = wordNode.ToCharArray();
        var result = new List<string>();

        for (var i = 0; i < chars.Length; i++)
        {
            var temp = chars[i];
            for (var ch = 'a'; ch <= 'z'; ch++)
            {
                chars[i] = ch;
                var neighbor = new string(chars);
                result.Add(neighbor);
            }

            chars[i] = temp;
        }

        return result;
    }
}