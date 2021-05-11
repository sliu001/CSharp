/*
LC295
Input
["MedianFinder", "addNum", "addNum", "findMedian", "addNum", "findMedian"]
[[], [1], [2], [], [3], []]
Output
[null, null, null, 1.5, null, 2.0]

Explanation
MedianFinder medianFinder = new MedianFinder();
medianFinder.addNum(1);    // arr = [1]
medianFinder.addNum(2);    // arr = [1, 2]
medianFinder.findMedian(); // return 1.5 (i.e., (1 + 2) / 2)
medianFinder.addNum(3);    // arr[1, 2, 3]
medianFinder.findMedian(); // return 2.0
*/
public class MedianFinder {
        private Heap minh = null;
        private Heap maxh = null;
        private int counter = 0;
        private int firstNum = 0;
        /** initialize your data structure here. */
        public MedianFinder()
        {
            minh = new Heap(HeapType.Min);
            maxh = new Heap(HeapType.Max);
        }

        public void AddNum(int num)
        {
            counter++;
            if (counter == 1)
                firstNum = num;
            else if (counter == 2)
            {
                maxh.Add(Math.Min(firstNum, num));
                minh.Add(Math.Max(firstNum, num));
            }
            else
            {
                if (maxh.Count == minh.Count)
                {
                    if (num < (minh.Top + maxh.Top) / 2.0)
                        maxh.Add(num);
                    else
                        minh.Add(num);
                }
                else if (maxh.Count > minh.Count)
                {
                    if (num > maxh.Top)
                        minh.Add(num);
                    else
                    {
                        minh.Add(maxh.Top);
                        maxh.RemoveTopAndAdd(num);
                    }
                }
                else
                {
                    if (num < minh.Top)
                        maxh.Add(num);
                    else
                    {
                        maxh.Add(minh.Top);
                        minh.RemoveTopAndAdd(num);
                    }
                }
            }
        }

        public double FindMedian()
        {
            if (counter == 1)
                return firstNum;
            else if (counter == counter/2*2)
            {
                return (minh.Top + maxh.Top) / 2.0;
            }
            else
            {
                if (maxh.Count > (counter / 2))
                    return maxh.Top;
                else
                    return minh.Top;
            }
        }
}


    public class Heap
    {
        private HeapType heapType;
        private List<int> nums;

        public Heap(HeapType type)
        {
            heapType = type;
            nums = new List<int>();
        }

        private bool needToSwitch(int parent, int child)
        {
            return ((heapType == HeapType.Max && parent < child) || (heapType == HeapType.Min && parent > child));
        }

        public void Add(int num)
        {
            nums.Add(num);
            int parentIdx = nums.Count == 1 ? 0 : nums.Count / 2 - 1;
            int childIdx = nums.Count - 1;
            
            while (parentIdx>=0 && needToSwitch(nums[parentIdx], nums[childIdx]))
            {
                int tmp = nums[parentIdx];
                nums[parentIdx] = nums[childIdx];
                nums[childIdx] = tmp;

                childIdx = parentIdx;
                parentIdx = (parentIdx-1)/2;
            }
        }

        public void RemoveTopAndAdd(int num)
        {
            nums[0] = num;
            int parentIdx = 0;
            int leftCIdx = 1;

            while (leftCIdx < nums.Count)
            {
                int rightCIdx = leftCIdx + 1;

                if (nums.Count > rightCIdx && needToSwitch(nums[leftCIdx], nums[rightCIdx]))
                    leftCIdx = rightCIdx;

                if (needToSwitch(nums[parentIdx], nums[leftCIdx]))
                {
                    int tmp = nums[parentIdx];
                    nums[parentIdx] = nums[leftCIdx];
                    nums[leftCIdx] = tmp;
                }
                parentIdx = leftCIdx;
                leftCIdx = leftCIdx * 2 + 1;
            }
        }

        public int Count { get { return nums.Count; } }
        public int Top { get { return nums[0]; } }
    }

    public enum HeapType
    {
        Min = 1,
        Max = 2
    }
/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
