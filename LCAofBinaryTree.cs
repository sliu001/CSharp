/*
LC236
Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
Output: 3
Explanation: The LCA of nodes 5 and 1 is 3.
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null) return null;
        
        if (root.val == p.val || root.val == q.val) return root;
        
        TreeNode lres = LowestCommonAncestor(root.left, p, q);
        TreeNode rres = LowestCommonAncestor(root.right, p, q);
        
        if (lres != null && rres != null) return root;
        
        return lres != null ? lres : rres;        
    }
}
