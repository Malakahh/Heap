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
                new Node(4),
                new Node(1),
                new Node(3),
                new Node(2),
                new Node(16),
                new Node(9),
                new Node(10),
                new Node(14),
                new Node(8),
                new Node(7),
            };
            Heap h = new Heap(list, Heap.HeapProperty.MinHeap);

            Console.WriteLine("Pre:\n" + h.ToString());
            Console.WriteLine("IsMinHeap: " + h.VerifyHeapProperty(Heap.HeapProperty.MinHeap));
            h.BuildHeap();
            Console.WriteLine("IsMinHeap: " + h.VerifyHeapProperty(Heap.HeapProperty.MinHeap));
            Console.WriteLine("Post:\n" + h.ToString());
            h.HeapInsert(new Node(6));
            Console.WriteLine("Insert:\n" + h.ToString());
            Console.WriteLine("IsMinHeap: " + h.VerifyHeapProperty(Heap.HeapProperty.MinHeap));


            Console.ReadKey();


        }

        class Node : HeapNode
        {
            public double key { get; set; }

            public Node(double k)
            {
                this.key = k;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            /// <returns>
            ///         If less than 0 the current object preceeds the given object.
            ///         If equal to 0 the current object is in the same position as the given object.
            ///         If greater than 0 the current object follows the given object.
            /// </returns>
            public int CompareTo(object obj)
            {
                HeapNode other = obj as HeapNode;
                if (other != null)
                {
                    return key.CompareTo(other.key);
                }
                else
                {
                    throw new ArgumentException("Object is not a HeapNode");
                }
            }
        }
    }
}
