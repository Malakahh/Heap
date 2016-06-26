using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            List<HeapNode> list = new List<HeapNode>()
            {
                new HeapNode(4),
                new HeapNode(1),
                new HeapNode(3),
                new HeapNode(2),
                new HeapNode(16),
                new HeapNode(9),
                new HeapNode(10),
                new HeapNode(14),
                new HeapNode(8),
                new HeapNode(7),
            };
            Heap h = new Heap(list);

            Console.WriteLine("Pre:\n" + h.ToString());
            Console.WriteLine("IsMaxHeap: " + h.VerifyMaxHeapProperty());
            h.BuildMaxHeap();
            Console.WriteLine("IsMaxHeap: " + h.VerifyMaxHeapProperty());
            Console.WriteLine("Post:\n" + h.ToString());
            h.MaxHeapInsert(new HeapNode(6));
            Console.WriteLine("Insert:\n" + h.ToString());
            Console.WriteLine("IsMaxHeap: " + h.VerifyMaxHeapProperty());


            Console.ReadKey();


        }
    }
}
