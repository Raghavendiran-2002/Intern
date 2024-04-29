namespace LinkedListCycle
{
    public class DetectCycleInLinkedList
    {
        ListNode node ;
        public int JoiningPoint;
        public DetectCycleInLinkedList()
        {
            node = new ListNode(10);
            node.next = new ListNode(20);
            node.next.next = new ListNode(30);
            node.next.next.next = new ListNode(40);
            node.next.next.next.next = new ListNode(50);
            node.next.next.next.next.next = new ListNode(60);
            node.next.next.next.next.next.next = node.next.next;
        }
        public bool HasCycle()
        {
            ListNode slow_pointer = node, fast_pointer = node;
            while (fast_pointer != null && fast_pointer.next != null)
            {
                slow_pointer = slow_pointer.next;
                fast_pointer = fast_pointer.next.next;
                if (slow_pointer == fast_pointer)
                {
                    JoiningPoint = slow_pointer.data;
                    return true;
                }
            }
            return false;
        }
    }
}
