/*
LC973. K Closest Points to Origin
Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane and an integer k, return the k closest points to the origin (0, 0).
Input: points = [[1,3],[-2,2]], k = 1
Output: [[-2,2]]
Input: points = [[3,3],[5,-1],[-2,4]], k = 2
Output: [[3,3],[-2,4]]

--solution: Quick Select & Tuple(original-points-index, point-distance)
--O(n) + O(logn) => O(n)
*/

public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        if (points.Length == 0) return new int[][] {};
        
        Tuple<int, int>[] dists = new Tuple<int, int>[points.Length];
        
        for (int i=0; i<points.Length; i++)
        {
            dists[i] = new Tuple<int, int> (i, points[i][0]*points[i][0] + points[i][1]*points[i][1]);
        }
        
        quickSelect(dists, k-1, 0, points.Length-1);
        
        int[][] res = new int[k][];
        for (int i=0; i<k; i++)
        {
            res[i] = points[dists[i].Item1];
        }
        
        return res;
    }
    
    private void quickSelect(Tuple<int, int>[] dists, int k, int left, int right)
    {
        int p = partition(dists, left, right);
        
        if (p == k)
            return;
        else if (p < k)
            quickSelect(dists, k, p+1, right);
        else
            quickSelect(dists, k, left, p-1);
    }
    
    private int partition(Tuple<int, int>[] dists, int left, int right)
    {
        if (dists == null || dists.Length <= 1) return 0;
        
        int first = left;
        int pivot = dists[first].Item2;
        left++;
        
        while (left <= right)
        {
            while (left <= right && pivot > dists[left].Item2)
                left++;
            
            while (left <= right && pivot <= dists[right].Item2)
                right--;    
            
            if (left < right)
                swap(dists, left, right);
        }
        swap(dists, first, right);
        return right;
    }
    
    private void swap(Tuple<int, int>[] dists, int i, int j)
    {
        var temp = dists[i];
        dists[i] = dists[j];
        dists[j] = temp;
    }
}
