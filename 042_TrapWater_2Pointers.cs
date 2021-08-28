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
        
        int l = 0, r = height.Length-1, leftMax = 0, rightMax = 0;
        
        while(l < r)
        {
        	if(height[l] < height[r]) //some higher bar is on the right
        	{
        		if (height[l] >= leftMax)
                    leftMax = height[l];
                else
                    result += leftMax-height[l]; //if current is not the left side highest, can trap water                
        		
        		++l;
        	}
        	else //height[l] >= height[r], some higher bar is on the left
        	{
        		if (height[r] >= rightMax)
                    rightMax = height[r];
                else
                    result += rightMax-height[r]; //if current is not the right side highest, can trap water
        		
        		--r;
        	}
        }
        
        return result;
    }
}
