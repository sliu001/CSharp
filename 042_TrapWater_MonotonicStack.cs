  
/*
LC42. Trapping Rain Water - Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.
Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6
Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.
*/
//using monotonic decreasing stack
//height of popped point = Min(left side first larger(top item after pop()), right side first larger (height[current])) - height[popped]
//width = Index of left side first larger - Index of right side first larger (height[current]) - 1
//area = height * width

public class Solution {
    public int Trap(int[] height) {
        int result = 0;
        
        var stk = new Stack<int>();
        for (int i = 0; i < height.Length; i++)
        {
            while (stk.Count > 0 && height[stk.Peek()] < height[i])
            {
                int current = stk.Peek();
                stk.Pop(); 
                if (stk.Count == 0) break;
                
                int l = stk.Peek();
                int r = i;
                int h = Math.Min(height[l], height[r]) - height[current];
                
                result += (r - l - 1) * h;
            }
            stk.Push(i);
        }
        
        return result;
    }
}
