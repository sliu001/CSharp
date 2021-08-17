/*
LC300: Given an integer array nums, return the length of the longest strictly increasing subsequence.

A subsequence is a sequence that can be derived from an array by deleting some or no elements 
without changing the order of the remaining elements. 
For example, [3,6,2,7] is a subsequence of the array [0,3,1,6,2,2,7].
O(nlogn)
*/
public class Solution {
    public int LengthOfLIS(int[] nums) {
        var lenList = new List<int>(){nums[0]};

        for (int i=1; i<nums.Length; i++)
        {
            if (nums[i] > lenList[lenList.Count - 1])
                lenList.Add(nums[i]);
            else
            {
                var pos = binarySearch(nums[i], lenList);
                lenList[pos] = nums[i];
            }
        }

        return lenList.Count;
    }

    private int binarySearch(int num, List<int> arr)
    {
        int left = 0;
        int right = arr.Count - 1;
        while (left <= right)
        {
            int mid = left + (right - left)/2;
            
            if (arr[mid] == num)
                return mid;
            else if (arr[mid] > num)
                right = mid - 1;
            else
                left = mid + 1;            
        }

        return left;
    }
}
