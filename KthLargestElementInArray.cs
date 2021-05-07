/*
LC215
Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
Output: 4
*/
public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        if (nums.Length==1 && k==1) return nums[0];
        
        int smallIdx = nums.Length - k;
        return quickSelect(nums, smallIdx, 0, nums.Length-1);
    }
        
    private static int quickSelect(int[] nums, int k, int left, int right)
    {
        int pos = partition(nums, left, right);
        if (pos == k)
            return nums[pos];
        else if (pos > k)
            return quickSelect(nums, k, left, pos-1);
        else
            return quickSelect(nums, k, pos+1, right);
    }
    
    private static int partition(int[] nums, int left, int right)
    {
        if (nums == null || nums.Length <= 1) return 0;

        int first = left;
        int pivot = nums[first];
        left++;

        while (left <= right)
        {
            while (left <= right && nums[left] < pivot)
                left++;

            while (left <= right && nums[right] >= pivot)
                right--;

            if (left < right)
                swap(nums, left, right);
        }
        swap(nums, first, right);
        return right;
    }

    private static void swap(int[] nums, int left, int right)
    {
        int tmp = nums[left];
        nums[left] = nums[right];
        nums[right] = tmp;
    }    
}
