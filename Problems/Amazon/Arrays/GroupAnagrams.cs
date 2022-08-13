namespace Problems.Amazon.Arrays;

public class GroupAnagrams
{
    private readonly Dictionary<string, List<string>> _map = new();

    public IList<IList<string>> Group(string[] strs)
    {
        var result = new List<IList<string>>();

        foreach (var str in strs)
        {
            var strArray = str.ToCharArray();
            System.Array.Sort(strArray);
            var sorted = new string(strArray);

            if (_map.ContainsKey(sorted))
                _map[sorted].Add(str);
            else
                _map[sorted] = new List<string> {str};
        }

        foreach (var key in _map.Keys) result.Add(_map[key]);

        return result;
    }
}