using System.Text;

namespace Problems.Google.Recursion;

public class WordSquares
{
    private readonly Dictionary<string, List<string>> _prefixMap = new();
    private int _size;
    private string[] _words;

    public IList<IList<string>> Get(string[] words)
    {
        _size = words[0].Length;
        _words = words;

        var result = new List<IList<string>>();
        BuildPrefixMap();

        foreach (var word in _words)
        {
            var wordSquares = new LinkedList<string>();
            wordSquares.AddLast(word);
            Backtrack(1, wordSquares, result);
        }


        return result;
    }

    private void Backtrack(int step, LinkedList<string> wordSquares, List<IList<string>> result)
    {
        if (step == _size)
        {
            result.Add(wordSquares.ToList());
            return;
        }

        var prefix = new StringBuilder();

        foreach (var wordSquare in wordSquares) prefix.Append(wordSquare[step]);

        foreach (var candidate in GetWordsFromPrefix(prefix.ToString()))
        {
            wordSquares.AddLast(candidate);
            Backtrack(step + 1, wordSquares, result);
            wordSquares.RemoveLast();
        }
    }

    private void BuildPrefixMap()
    {
        foreach (var word in _words)
            for (var i = 1; i < _size; i++)
            {
                var prefix = word.Substring(0, i);
                var containsPrefix = _prefixMap.ContainsKey(prefix);
                if (!containsPrefix) _prefixMap.Add(prefix, new List<string>());

                _prefixMap[prefix].Add(word);
            }
    }

    private List<string> GetWordsFromPrefix(string prefix)
    {
        return _prefixMap.GetValueOrDefault(prefix) ?? new List<string>();
    }
}