namespace Problems.Google.Recursion;

public class WordSearch
{
    private readonly int[][] _directions =
    {
        new[] {-1, 0},
        new[] {0, 1},
        new[] {1, 0},
        new[] {0, -1}
    };

    private char[][] _board;
    private int _sizeCol;

    private int _sizeRow;

    /// <summary>
    ///     And of course this throws a time limit exceeded
    /// </summary>
    /// <param name="board"></param>
    /// <param name="words"></param>
    /// <returns></returns>
    public IList<string> FindWords(char[][] board, string[] words)
    {
        var result = new List<string>();
        foreach (var word in words)
            if (Exists(board, word))
                result.Add(word);

        return result;
    }

    public bool Exists(char[][] board, string word)
    {
        _sizeRow = board.Length;
        _sizeCol = board[0].Length;
        _board = board;

        if (_sizeCol * _sizeRow < word.Length)
            return false;

        if (_sizeCol == 1 && _sizeRow == 1)
            if (word.Length == 1)
                return word[0] == _board[0][0];

        for (var i = 0; i < _sizeRow; i++)
        for (var j = 0; j < _sizeCol; j++)
            if (Exists(i, j, word, 0))
                return true;

        return false;
    }

    private bool Exists(int row, int col, string word, int step)
    {
        if (step >= word.Length)
            return true;

        if (_board[row][col] != word[step])
            return false;

        var ret = false;
        _board[row][col] = '#';

        foreach (var direction in GetDirections(row, col))
        {
            ret = Exists(direction.row, direction.col, word, step + 1);
            if (ret) break;
        }

        _board[row][col] = word[step];
        return ret;
    }

    private List<(int row, int col)> GetDirections(int row, int col)
    {
        var result = new List<(int row, int col)>();

        foreach (var direction in _directions)
        {
            var newRow = row + direction[0];
            var newCol = col + direction[1];

            if (newRow < 0 || newRow >= _sizeRow)
                continue;

            if (newCol < 0 || newCol >= _sizeCol)
                continue;

            result.Add((newRow, newCol));
        }

        return result;
    }
}

public class Trie
{
    public Dictionary<char, Trie> Children { get; set; } = new();
    public string Word { get; set; }
}

public class WordSearchTwo
{
    private readonly int[][] _directions =
    {
        new[] {-1, 0},
        new[] {0, 1},
        new[] {1, 0},
        new[] {0, -1}
    };

    private readonly List<string> _result = new();
    private char[][] _board;
    private int _sizeCol;
    private int _sizeRow;

    public IList<string> FindWords(char[][] board, string[] words)
    {
        _sizeRow = board.Length;
        _sizeCol = board[0].Length;
        _board = board;

        // Build the trie
        var root = new Trie();
        foreach (var word in words)
        {
            var node = root;
            foreach (var character in word)
                if (node.Children.ContainsKey(character))
                {
                    node = node.Children[character];
                }
                else
                {
                    var newNode = new Trie();
                    node.Children.Add(character, newNode);
                    node = newNode;
                }

            node.Word = word;
        }

        for (var i = 0; i < _sizeRow; i++)
        for (var j = 0; j < _sizeCol; j++)
            Backtracking(i, j, root);

        return _result;
    }

    private void Backtracking(int row, int col, Trie parent)
    {
        var current = _board[row][col];
        var currentNode = parent.Children.GetValueOrDefault(current);

        if (currentNode is null)
            return;

        if (currentNode.Word is not null)
        {
            _result.Add(currentNode.Word);
            currentNode.Word = null;
        }

        // Mark as visited
        _board[row][col] = '#';

        foreach (var direction in GetDirections(row, col))
            if (currentNode.Children.ContainsKey(_board[direction.row][direction.col]))
                Backtracking(direction.row, direction.col, currentNode);

        //restore original value
        _board[row][col] = current;

        //Optimize: incrementally remove the leaf node
        if (!currentNode.Children.Any()) parent.Children.Remove(current);
    }

    private List<(int row, int col)> GetDirections(int row, int col)
    {
        var result = new List<(int row, int col)>();

        foreach (var direction in _directions)
        {
            var newRow = row + direction[0];
            var newCol = col + direction[1];

            if (newRow < 0
                || newRow >= _sizeRow
                || newCol < 0
                || newCol >= _sizeCol)
                continue;

            result.Add((newRow, newCol));
        }

        return result;
    }
}