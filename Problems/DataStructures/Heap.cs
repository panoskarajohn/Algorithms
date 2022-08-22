namespace Problems.DataStructures;

public class Heap
{
    public class MinHeap
    {
        /// <summary>
        ///     The number of elements is need when instantiating an array
        ///     heapSize records sth size of the array
        /// </summary>
        private readonly int heapSize;

        /// <summary>
        ///     Create a complete binary tree using an array
        ///     Then use the binary tree to construct a Heap
        /// </summary>
        private readonly int[] minHeap;

        public MinHeap(int heapSize)
        {
            this.heapSize = heapSize;
            minHeap = new int[heapSize + 1];

            //To better track the indices of the binary tree, 
            // we will not use the 0-th element in the array
            // You can fill it with any value
            minHeap[0] = 0;
        }

        public int Peek => minHeap[1];

        /// <summary>
        ///     realSize records the number of elements in the Heap
        /// </summary>
        public int Size { get; private set; }

        public void Add(int element)
        {
            Size++;
            if (Size > heapSize)
            {
                Size--;
                throw new InvalidOperationException("Added too many elements");
            }

            //add the element into the array
            minHeap[Size] = element;
            //index of the newly added element
            var index = Size;

            // Parent node of the newly added element
            // Note if we use an array to represent the complete binary tree
            // and store the root node at index 1
            // index of the parent node of any node is [index of the node / 2]
            // index of the left child node is [index of the node * 2]
            // index of the right child node is [index of the node * 2 + 1]
            var parent = index / 2;

            // if the newly added element is smaller than its parent node,
            // its value will be exchanged with that of the parent node

            while (minHeap[index] < minHeap[parent] && index > 1)
            {
                (minHeap[index], minHeap[parent]) = (minHeap[parent], minHeap[index]);
                index = parent;
            }
        }

        public int Pop()
        {
            if (Size < 1) throw new ArgumentOutOfRangeException("Don't have any elements!");

            // when there are still elements in the Heap
            // realSize >= 1
            var removeElement = minHeap[1];
            //put the last element in the Heap to the top of the Heap
            minHeap[1] = minHeap[Size];
            Size--;
            var index = 1;

            while (index < Size / 2)
            {
                // the left child of the deleted element
                var left = index * 2;
                //the right child of the deleted element
                var right = index * 2 + 1;

                //if the value element is larger than the left or right child
                //its value needs to be exchanged with the smaller value
                //of the left and right child

                if (minHeap[index] > minHeap[left] || minHeap[index] > minHeap[right])
                {
                    if (minHeap[left] < minHeap[right])
                    {
                        (minHeap[left], minHeap[index]) = (minHeap[index], minHeap[left]);
                        index = left;
                    }
                    else
                    {
                        (minHeap[right], minHeap[index]) = (minHeap[right], minHeap[index]);
                        index = right;
                    }
                }
                else
                {
                    break;
                }
            }

            return removeElement;
        }
    }
}