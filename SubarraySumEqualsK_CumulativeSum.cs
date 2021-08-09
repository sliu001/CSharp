/*
LC 560
Given an array of integers nums and an integer k, return the total number of continuous subarrays whose sum equals to k.
Input: nums = [1,1,1], k = 2
Output: 2
Input: nums = [1,-1,0], k = 0
Output: 3
*/

//cumulative sum solution:
public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int res = 0, currentSum = 0;
        Dictionary<int, int> prevSumsCount = new Dictionary<int, int>();
                
        for (int i=0; i<nums.Length; i++)
        {
            currentSum += nums[i];
            
            if (currentSum == k)
                res++;
            
            if (prevSumsCount.TryGetValue(currentSum-k, out int prevCount))
                res += prevCount;

            if (!prevSumsCount.TryAdd(currentSum, 1))
                prevSumsCount[currentSum]++;
        }
        
        return res;
    }
}
