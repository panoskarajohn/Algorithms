using System.Text;

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

        int level = 0;

        while (queue.Any())
        {
            int size = queue.Count;
            level++;
            for (int i = 0; i < size; i++)
            {
                string current = queue.Dequeue();
                if (current == endWord) return level;

                IList<string> neighbors = GetNeighbors(current);
                foreach (var neighbor in neighbors)
                {
                    if (words.Contains(neighbor))
                    {
                        words.Remove(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
        return 0;
    }

    private IList<string> GetNeighbors(string wordNode)
    {
        char[] chars = wordNode.ToCharArray();
        var result = new List<string>();

        for (int i = 0; i < chars.Length; i++)
        {
            char temp = chars[i];
            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                chars[i] = ch;
                string neighbor = new string(chars);
                result.Add(neighbor);
            }

            chars[i] = temp;
        }

        return result;
    }


}