using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    //Min Heap
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;

        public PriorityQueue()
        {
            data = new List<T>();
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int childIndex = data.Count - 1; // child index; start at end
            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2; // parent index
                if (data[childIndex].CompareTo(data[parentIndex]) >= 0) break; // child item is larger than (or equal) parent so we're done
                T tmp = data[childIndex]; data[childIndex] = data[parentIndex]; data[parentIndex] = tmp;
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            // assumes pq is not empty; up to calling code
            T frontItem = data[0];   // fetch the front

            int lastIndex = data.Count - 1; // last index (before removal)            
            data[0] = data[lastIndex];
            data.RemoveAt(lastIndex);
            lastIndex--; // last index (after removal)

            int parentIndex = 0; // parent index. start at front of pq
            while (true)
            {
                int leftChildIndex = parentIndex * 2 + 1; // left child index of parent
                if (leftChildIndex > lastIndex) break;  // no children so done

                int rightChildIndex = leftChildIndex + 1;     // right child
                if (rightChildIndex <= lastIndex && data[rightChildIndex].CompareTo(data[leftChildIndex]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                    leftChildIndex = rightChildIndex;
                if (data[parentIndex].CompareTo(data[leftChildIndex]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
                T tmp = data[parentIndex]; data[parentIndex] = data[leftChildIndex]; data[leftChildIndex] = tmp; // swap parent and child
                parentIndex = leftChildIndex;
            }
            return frontItem;
        }

        public T Peek()
        {
            T frontItem = data[0];
            return frontItem;
        }

        public int Count()
        {
            return data.Count;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < data.Count; ++i)
                s += data[i].ToString() + " ";
            s += "count = " + data.Count;
            return s;
        }

        public bool IsConsistent()
        {
            // is the heap property true for all data?
            if (data.Count == 0) return true;
            int lastIndex = data.Count - 1; // last index
            for (int parentIndex = 0; parentIndex < data.Count; ++parentIndex) // each parent index
            {
                int leftChildIndex = 2 * parentIndex + 1; // left child index
                int rightChildIndex = 2 * parentIndex + 2; // right child index

                if (leftChildIndex <= lastIndex && data[parentIndex].CompareTo(data[leftChildIndex]) > 0) return false; // if lc exists and it's greater than parent then bad.
                if (rightChildIndex <= lastIndex && data[parentIndex].CompareTo(data[rightChildIndex]) > 0) return false; // check the right child too.
            }
            return true; // passed all checks
        } // IsConsistent

    }
}
