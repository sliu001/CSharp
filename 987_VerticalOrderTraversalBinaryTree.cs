/*
LC987 https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/
Input: root = [3,9,20,null,null,15,7]
Output: [[9],[3,15],[20],[7]]
Explanation:
Column -1: Only node 9 is in this column.
Column 0: Nodes 3 and 15 are in this column in that order from top to bottom.
Column 1: Only node 20 is in this column.
Column 2: Only node 7 is in this column.

*/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
 
public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        
        IList<IList<int>> res = new List<IList<int>>();
        if (root == null) return res;
        
        SortedDictionary<int, List<Tuple<int, int>>> nodes = new SortedDictionary<int, List<Tuple<int, int>>>(); //[col, (row, value)]
        
        Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)>(); //(TreeNode, col)
        q.Enqueue((root, 0));
        int currLevel = 0;
        
        while (q.Count > 0)
        {
            int levelLen = q.Count;
            for (int i=0; i<levelLen; i++)
            {
                var curr = q.Dequeue();
                var nodeItem = new Tuple<int, int>(currLevel, curr.Item1.val);
                
                if (nodes.ContainsKey(curr.Item2))
                    nodes[curr.Item2].Add(nodeItem);
                else
                    nodes.Add(curr.Item2, new List<Tuple<int, int>> {nodeItem});
                
                
                if (curr.Item1.left != null)
                    q.Enqueue((curr.Item1.left, curr.Item2-1));
                
                if (curr.Item1.right != null)
                    q.Enqueue((curr.Item1.right, curr.Item2+1));                
            }
            currLevel++;
        }
        
        foreach (var vals in nodes.Values)
        {
            res.Add(vals.OrderBy(e=>e.Item1).ThenBy(e=>e.Item2).Select(e => e.Item2).ToList());
        }
        
        return res;
    }
}
