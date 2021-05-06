//LC239, Monotonic Queue
/*
Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
Output: [3,3,5,5,6,7]
Explanation: 
Window position                Max
---------------               -----
[1  3  -1] -3  5  3  6  7       3
 1 [3  -1  -3] 5  3  6  7       3
 1  3 [-1  -3  5] 3  6  7       5
 1  3  -1 [-3  5  3] 6  7       5
 1  3  -1  -3 [5  3  6] 7       6
 1  3  -1  -3  5 [3  6  7]      7
*/
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if (nums.Length == 1 || k==1) return nums;
        if (nums.Length == k) return new int[] {nums.Max(e=>e)};
        
        int[] result = new int[nums.Length-k+1];
        LinkedList<int> win = new LinkedList<int>();
        
        win.AddLast(0);
        for (int i=1; i<k; i++)
        {
            while (win.Count >0 && nums[win.Last.Value] < nums[i]) win.RemoveLast();
            win.AddLast(i);
        }
        result[0] = nums[win.First.Value];
        
        for (int i=1; i<=nums.Length-k; i++)
        {            
            if (win.First.Value == i-1) win.RemoveFirst();
            
            while (win.Count > 0 && nums[win.Last.Value] < nums[i+k-1]) win.RemoveLast();
            win.AddLast(i+k-1);
                        
            result[i] = nums[win.First.Value];
        }
        
        return result;
    }
}
