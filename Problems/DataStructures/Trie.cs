namespace Problems.DataStructures;

public class Trie
{
    private readonly TrieNode _root;

    public Trie()
    {
        _root = new TrieNode();
    }

    public void Insert(string word)
    {
        if (string.IsNullOrEmpty(word))
            return;
        var current = _root;

        foreach (var c in word)
        {
            if (!current.Children.ContainsKey(c))
                current.Children[c] = new TrieNode();
            current = current.Children[c];
        }

        current.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        if (string.IsNullOrEmpty(word))
            return false;
        var current = _root;
        foreach (var c in word)
        {
            if (!current.Children.ContainsKey(c))
                return false;
            current = current.Children[c];
        }

        return current.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        if (string.IsNullOrEmpty(prefix))
            return false;
        var current = _root;
        foreach (var c in prefix)
        {
            if (!current.Children.ContainsKey(c))
                return false;
            current = current.Children[c];
        }

        return true;
    }
}

public class TrieNode
{
    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
    }

    public Dictionary<char, TrieNode> Children { get; }

    public bool IsEndOfWord { get; set; }
}