using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Heap
{
    class Heap
    {
        List<HeapNode> nodes;

        public Heap(IEnumerable<HeapNode> nodes)
        {
            this.nodes = new List<HeapNode>(nodes);
        }

        // Copy constructor
        public Heap(Heap toCopy)
        {
            this.nodes = new List<HeapNode>(toCopy.nodes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int Parent(int i)
        {
            return i / 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int Left(int i)
        {
            return i * 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int Right(int i)
        {
            return i * 2 + 1;
        }

        #region Max Heap

        /// <summary>
        ///     Maintains the max-heap property.
        ///     Assumes Left(i) and Right(i) are max heaps.
        /// </summary>
        /// <param name="i">Index into nodes. This might be smaller than its children.</param>
        void MaxHeapify(int i)
        {
            int l = Left(i);
            int r = Right(i);

            int largest = i;

            if (l < nodes.Count && nodes[l].CompareTo(nodes[largest]) > 0)
            {
                largest = l;
            }

            if (r < nodes.Count && nodes[r].CompareTo(nodes[largest]) > 0)
            {
                largest = r;
            }

            if (largest != i)
            {
                Swap(i, largest);
                MaxHeapify(largest);
            }
        }

        /// <summary>
        /// Iterates through all non-leaves of the tree, and runs MaxHeapify on each one.
        /// </summary>
        public void BuildMaxHeap()
        {
            for (int i = (nodes.Count - 1) / 2; i >= 0; i--)
            {
                MaxHeapify(i);
            }
        }

        /// <summary>
        /// Increases a key's value whilst maintaining the max-heap property
        /// </summary>
        /// <param name="i">Index of key to increase</param>
        /// <param name="key">new value of key</param>
        void HeapIncreaseKey(int i, double key)
        {
            if (key < nodes[i].key)
            {
                throw new ArgumentException("new key is smaller than current key");
            }

            nodes[i].key = key;
            while (i > 0 && nodes[Parent(i)].CompareTo(nodes[i]) < 0)
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        /// <summary>
        /// Inserts a new node into the heap whilst maintaining the max-heap property
        /// </summary>
        /// <param name="newNode"></param>
        public void MaxHeapInsert(HeapNode newNode)
        {
            nodes.Add(newNode);
            HeapIncreaseKey(nodes.Count - 1, newNode.key);
        }

        /// <summary>
        /// Verifies the Max Heap property
        /// </summary>
        /// <returns>If this is a max heap</returns>
        public bool VerifyMaxHeapProperty()
        {
            bool isMaxHeap = true;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[Parent(i)].CompareTo(nodes[i]) < 0)
                {
                    isMaxHeap = false;
                }
            }

            return isMaxHeap;
        }

        #endregion

        /// <summary>
        /// Swaps two nodes' position.
        /// </summary>
        /// <param name="a">Index of first node.</param>
        /// <param name="b">Index of second node.</param>
        void Swap(int a, int b)
        {
            HeapNode temp = nodes[b];
            nodes[b] = nodes[a];
            nodes[a] = temp;
        }

        public override string ToString()
        {
            string s = "Nodes: ";

            for (int i = 0; i < nodes.Count; i++)
            {
                s += nodes[i].key + ", ";
            }

            return s;
        }
    }

    class HeapNode : IComparable
    {
        public double key;

        public HeapNode(double k)
        {
            key = k;
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
