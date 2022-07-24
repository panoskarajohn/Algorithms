using System.Collections;

namespace Problems.Google.Recursion;

public class WordSearch
{
    private readonly int[][] _directions = new int[][]
    {
        new int[] { -1, 0 },
        new int[] { 0, 1 },
        new int[] { 1, 0 },
        new int[] { 0, -1 }
    };

    private int _sizeRow;
    private int _sizeCol;
    private char[][] _board;

    /// <summary>
    /// And of course this throws a time limit exceeded
    /// </summary>
    /// <param name="board"></param>
    /// <param name="words"></param>
    /// <returns></returns>
    public IList<string> FindWords(char[][] board, string[] words)
    {
        var result = new List<string>();
        foreach (var word in words)
        {
            if(Exists(board,word))
                result.Add(word);
        }

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
        {
            if (word.Length == 1)
            {
                return word[0] == _board[0][0];
            }
        }
        
        for (int i = 0; i < _sizeRow; i++)
        {
            for (int j = 0; j < _sizeCol; j++)
            {
                if (Exists( i, j, word, 0))
                    return true;
            }
        }

        return false;
    }

    private bool Exists(int row, int col ,string word, int step)
    {
        if (step >= word.Length)
            return true;

        if (_board[row][col] != word[step])
            return false;

        bool ret = false;
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
            
            if(newRow < 0 || newRow >= _sizeRow)
                continue;
            
            if(newCol < 0 || newCol >= _sizeCol)
                continue;
            
            result.Add((newRow, newCol));
        }

        return result;

    }
}