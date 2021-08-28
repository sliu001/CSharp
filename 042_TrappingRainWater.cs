/*
LC42. Trapping Rain Water - Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.

Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6
Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.
*/
//Get max height of left side and max height of right side for each point.
//water volume at each point = Max(left_max, right_max)-height[current]
//Time complexity = O(n)

public class Solution {
    public int Trap(int[] height) {
        int result = 0;
        
        int[] leftMaxArr = new int[height.Length];
        int[] rightMaxArr = new int[height.Length];
        leftMaxArr[0] = 0;
        rightMaxArr[height.Length-1] = 0;
        
        for (int i=1; i<height.Length; i++)
        {            
            leftMaxArr[i] = Math.Max(leftMaxArr[i-1], height[i-1]);                        
            rightMaxArr[height.Length - i - 1] = Math.Max(rightMaxArr[height.Length - i], height[height.Length - i]);
        }
        
        for (int i=0; i<height.Length; i++)
        {
            result += Math.Max(Math.Min(leftMaxArr[i], rightMaxArr[i]) - height[i], 0);
        }
        
        return result;
    }
}
