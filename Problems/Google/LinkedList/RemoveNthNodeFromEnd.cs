using System.ComponentModel;

namespace Problems.Google.LinkedList;

public class RemoveNthNodeFromEnd
{
    
    public static ListNode Remove(ListNode head, int n)
    {
        var dummy = new ListNode(0);
        dummy.next = head;

        ListNode slow = dummy;
        ListNode fast = dummy;

        for (int i = 0; i <= n; i++)
        {
            fast = fast.next;
        }

        while (fast != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        slow.next = slow.next.next;
        return dummy.next;
    }
}