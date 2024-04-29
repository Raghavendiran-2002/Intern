using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListCycle
{
   
    public class ListNode
    {
        public int data;
        public ListNode next;
        public ListNode(int x)
        {
            data = x;
            next = null;
        }
    }
}
