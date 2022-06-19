namespace Problems.Google.LinkedList;

public class MergeKSortedLists
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        var pq = new PriorityQueue<ListNode, int>();

        for (var i = 0; i < lists.Length; i++)
        {
            var currentNode = lists[i];
            while (currentNode != null)
            {
                pq.Enqueue(currentNode, currentNode.val);
                currentNode = currentNode.next;
            }
        }

        ListNode head, listNodeToReturn = null;

        if (pq.Count == 0)
            return null;

        var node = pq.Dequeue();
        head = node;
        listNodeToReturn = head;

        while (pq.Count != 0)
        {
            node = pq.Dequeue();
            head.next = node;
            head = head.next;
        }

        head.next = null;

        return listNodeToReturn;
    }
}