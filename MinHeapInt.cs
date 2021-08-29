public class MinHeap
{
    private List<int> nums;

    public MinHeap()
    {
        nums = new List<int>();
    }

    public int Count { get { return nums.Count; } }
    public int Top { get { return nums[0]; } }

    public void Add(int num)
    {
        nums.Add(num);
        int parentIdx = nums.Count == 1 ? 0 : nums.Count / 2 - 1;
        int childIdx = nums.Count - 1;

        while (parentIdx >= 0 && nums[parentIdx] > nums[childIdx])
        {
            swap(nums, parentIdx, childIdx);

            childIdx = parentIdx;
            parentIdx = (parentIdx - 1) / 2;
        }
    }

    public int RemoveTop()
    {
        int top = nums[0];
        nums[0] = nums[nums.Count - 1];
        nums.RemoveAt(nums.Count - 1);

        int parentIdx = 0;
        int leftCIdx = 1;

        while (leftCIdx < nums.Count)
        {
            int rightCIdx = leftCIdx + 1;

            if (nums.Count > rightCIdx && nums[leftCIdx] > nums[rightCIdx])
                leftCIdx = rightCIdx;

            if (nums[parentIdx] > nums[leftCIdx])
                swap(nums, parentIdx, leftCIdx);
                
            parentIdx = leftCIdx;
            leftCIdx = leftCIdx * 2 + 1;
        }

        return top;
    }

    public void RemoveTopAndAdd(int num)
    {
        nums[0] = num;
        int parentIdx = 0;
        int leftCIdx = 1;

        while (leftCIdx < nums.Count)
        {
            int rightCIdx = leftCIdx + 1;

            if (nums.Count > rightCIdx && nums[leftCIdx] > nums[rightCIdx])
                leftCIdx = rightCIdx;

            if (nums[parentIdx] > nums[leftCIdx])
                swap(nums, parentIdx, leftCIdx);
                
            parentIdx = leftCIdx;
            leftCIdx = leftCIdx * 2 + 1;
        }
    }

    private void swap(List<int> arr, int idx1, int idx2)
    {
        int tmp = arr[idx1];
        arr[idx1] = arr[idx2];
        arr[idx2] = tmp;
    }
}
