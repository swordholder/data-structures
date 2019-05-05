using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Queue
    {
        private QNode head;
        private int size=0;

        public void Enqueue(int item)
        {
            if (head == null)
            {
                head = new QNode(item);
                head.Next = null;                
            }
            else
            {
                var temp = head;
               
                head = new QNode(item);
                head.Next = temp;
            }
            size++;
        }

        public int? Dequeue()
        {
            if (head == null)
                return null;

            if (size == 0)
                return null;

            var node = head;
            var previous = node;

            while (node.Next != null)
            {
                previous = node;
                node = node.Next;
            }

            size--;
            var retVal = node.Data;
            //node = null;
            previous.Next = null;

            return retVal;
        }
    }

    public class QNode
    {
        public int Data;
        public QNode Next;

        public QNode(int val)
        {
            Data = val;
        }
    }
}
