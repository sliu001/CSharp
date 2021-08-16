using System.IO;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var res = TwoSum(new int[]{3,2,2,3,4,1}, 5);
    }
    
    public static List<int[]> TwoSum(int[] nums, int target) {
        var res = new List<int[]>();
        var numPos = new Dictionary<int, List<int>>();
        
        for (int i=0; i<nums.Length; i++)
        {
            if (numPos.ContainsKey(target - nums[i]))
            {
                numPos[target - nums[i]].ForEach(e=>{
                    res.Add(new int[2] {i, e});
                });                
            }
            
            if (!numPos.TryAdd(nums[i], new List<int> {i}))
            {
                numPos[nums[i]].Add(i);
            }
        }
        
        //res.ForEach(e =>{Console.WriteLine($"{e[0]}|{e[1]}");});
        return res;
    }
}
