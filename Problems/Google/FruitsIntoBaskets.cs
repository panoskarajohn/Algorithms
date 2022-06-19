namespace Problems.Google;

public static class FruitsIntoBaskets
{
    public static int TotalFruit(int[] fruits)
    {
        if (fruits.Length == 0)
            return 0;

        // each indice is a tree
        // each tree[i] is a type of fruit
        // We have two baskets, each basket can only hold a single type of fruit
        //basically asks the longest common substring with at most 2 characters
        var max = 1;
        var dictionary = new Dictionary<int, int>();
        var left = 0;
        var right = 0;

        while (right < fruits.Length)
        {
            if (dictionary.Count <= 2)
            {
                if (dictionary.ContainsKey(fruits[right]))
                    dictionary[fruits[right]] = right++;
                else
                    dictionary.Add(fruits[right], right++);
            }

            if (dictionary.Count > 2)
            {
                var min = fruits.Length - 1;
                foreach (var value in dictionary.Values) min = Math.Min(min, value);

                left = min + 1;
                dictionary.Remove(fruits[min]);
            }

            max = Math.Max(max, right - left);
        }

        return max;
    }
}