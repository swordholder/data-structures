using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{

    class Solution
    {
        static void Main(string[] args)
        {



            var queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            int? item;
            while ((item = queue.Dequeue()) != null)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

        }
    }

}