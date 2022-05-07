namespace Problems.Google.LinkedList;

public static class MergeTwoLists
{
    public static ListNode Merge(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode(-1,null);
        var dummyReturn = dummy;
        while (list1 != null || list2 != null)
        {
            var value1 = list1?.val ?? int.MaxValue;
            var value2 = list2?.val ?? int.MaxValue;

            if (value1 < value2)
            {
                dummy.next = new ListNode(value1, null);
                list1 = list1.next;
            }
            else
            {
                dummy.next = new ListNode(value2, null);
                list2 = list2.next;
            }

            dummy = dummy.next;
        }

        return dummyReturn.next;


    }
}