namespace Problems.Contests;

public class MergeSimilarItems
{
    public IList<IList<int>> Merge(int[][] items1, int[][] items2)
    {
        var dic = new Dictionary<int, int>();
        foreach (var i in items1) dic.Add(i[0], i[1]);

        foreach (var i in items2)
            if (dic.ContainsKey(i[0]))
                dic[i[0]] += i[1];
            else
                dic.Add(i[0], i[1]);

        var result = new List<IList<int>>();
        foreach (var i in dic) result.Add(new List<int> {i.Key, i.Value});

        var comparer = Comparer<int>.Default;
        result.Sort((a, b) => comparer.Compare(a[0], b[0]));
        return result;
    }
}