namespace Problems.Google.Sorting;

public class CountOfSmallerNumberAfterSelf
{
    /// <summary>
    /// Segment Tree solution.
    /// Super hard solution
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public IList<int> Count(int[] nums)
    {
        int offset = 10000; //offset negative to non-negative
        int size = 2 * offset + 1; // total possible values in nums
        int[] tree = new int[size * 2]; // segment tree TODO: Look it up again
        List<int> result = new List<int>();

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            int smallerCount = Query(0, nums[i] + offset, tree, size);
            result.Add(smallerCount);
            Update(nums[i] + offset, 1, tree, size);
        }

        result.Reverse();
        return result;
    }

    private void Update(int index, int value, int[] tree, int size)
    {
        index += size; //shift the index of the leaf
        //update from leaf to root
        tree[index] += value;
        while (index > 1)
        {
            index /= 2;
            tree[index] = tree[index * 2] + tree[index * 2 + 1];
        }
    }

    private int Query(int left, int right, int[] tree, int size)
    {
        int result = 0;
        left += size;
        right += size; // shift the index of the leaf

        while (left < right)
        {
            //if the left is the right node
            // bring the value and move to parent's right node
            if (left % 2 == 1)
            {
                result += tree[left];
                left++;
            }
            
            //else directly move to parent
            left /= 2;
            
            //if right is a right node
            // bring the value of the left node and move to parent
            if (right % 2 == 1)
            {
                right--;
                result += tree[right];
            }
            // else directly move to parent
            right /= 2;
        }

        return result;

    }

}