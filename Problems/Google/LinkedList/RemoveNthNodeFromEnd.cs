namespace Problems.Google.LinkedList;

public class RemoveNthNodeFromEnd
{
    public static ListNode Remove(ListNode head, int n)
    {
        var dummy = new ListNode();
        dummy.next = head;

        var slow = dummy;
        var fast = dummy;

        for (var i = 0; i <= n; i++) fast = fast.next;

        while (fast != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        slow.next = slow.next.next;
        return dummy.next;
    }
}