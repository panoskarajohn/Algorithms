namespace Problems.Google.LinkedList;

public class AddTwoNumbers
{
    /// <summary>
    /// Given two <see cref="ListNode"/> with numbers in reverse order.
    /// Add them
    /// </summary>
    /// <param name="l1"></param>
    /// <param name="l2"></param>
    /// <returns></returns>
    public static ListNode Add(ListNode l1, ListNode l2)
    {
        var dummy = new ListNode(0);
        var l3 = dummy;

        int carry = 0;

        while (l1 != null || l2 != null)
        {
            int l1Val = l1?.val ?? 0;
            int l2Val = l2?.val ?? 0;

            int sum = l1Val + l2Val + carry;
            carry = sum / 10;
            int lastDigit = sum % 10;

            ListNode newNode = new ListNode(lastDigit);
            l3.next = newNode;

            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
            l3 = l3.next;

        }

        if (carry > 0)
            l3.next = new ListNode(carry);

        return dummy.next;
    }

}