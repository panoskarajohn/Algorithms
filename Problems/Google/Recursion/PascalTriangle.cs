namespace Problems.Google.Recursion;

public class PascalTriangle
{
    public IList<int> GetRow(int input)
    {
        var result = new List<IList<int>>();
        
        result.Add(new List<int>() {1});

        for (int i = 1; i < input + 1; i++)
        {
            var currRow = new List<int>();
            var prevRow = result[i - 1];
            
            currRow.Add(1);
            
            for (int j = 1; j < prevRow.Count; j++)
            {
                currRow.Add( prevRow[j - 1] + prevRow[j]);
            }
            
            currRow.Add(1);
            
            result.Add(currRow);
        }
        return result[input];
    }

    /// <summary>
    /// Dynamic programming approach
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public IList<IList<int>> GetRows(int input)
    {
        var result = new List<IList<int>>();
        
        result.Add(new List<int>() {1});

        for (int i = 1; i < input; i++)
        {
            var currRow = new List<int>();
            var prevRow = result[i - 1];
            
            currRow.Add(1);
            
            for (int j = 1; j < prevRow.Count; j++)
            {
                currRow.Add( prevRow[j - 1] + prevRow[j]);
            }
            currRow.Add(1);
            result.Add(currRow);
        }
        return result;
    }

    
}