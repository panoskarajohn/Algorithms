namespace Problems.Google.LinkedList;

/// <summary>
/// This is how is set on leetcode.
/// This is a definition for a single linked list
/// </summary>
public class ListNode {
     public int val;
     public ListNode next;

     public ListNode(int val = 0, ListNode next = null)
     {
         this.val = val;
         this.next = next;
     }
}


/// <summary>
/// Helper methods that will help with testing and creating new list nodes
/// </summary>
public static class ListNodeExtensions
{
    public static bool IsIdentical(this ListNode node, ListNode nodeParam) {
        
        while (node != null && nodeParam != null)
        {
            if (node.val != nodeParam.val)
                return false;
            
            node = node.next;
            nodeParam = nodeParam.next;
        }

        return node is null && nodeParam is null;
    }

    public static ListNode Create(params int[] array)
    {
        ListNode node = new ListNode(array[0], null);
        var head = node;
        for (int i = 1; i < array.Length; i++)
        {
            node.next = new ListNode(array[i], null);
            node = node.next;
        }
        return head;
    }
}

