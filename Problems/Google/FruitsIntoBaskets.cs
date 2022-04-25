using System.Collections.Immutable;

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
        int max = 1;
        var dictionary = new Dictionary<int, int>();
        int i = 0;
        int j = 0;

        while (j < fruits.Length)
        {
            if (dictionary.Count <= 2)
            {
                if (dictionary.ContainsKey(fruits[j]))
                {
                    dictionary[fruits[j]] = j++;
                }
                else
                {
                    dictionary.Add(fruits[j], j++);
                }

            }

            if (dictionary.Count > 2)
            {
                int min = fruits.Length - 1;
                foreach (var value in dictionary.Values)
                {
                    min = Math.Min(min, value);
                }

                i = min + 1;
                dictionary.Remove(fruits[min]);
            }

            max = Math.Max(max, j - i);
        }

        return max;
    }
}