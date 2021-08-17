/*
LC101
Input: root = [1,2,2,3,4,4,3]
Output: true
Input: root = [1,2,2,null,3,null,3]
Output: false
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
    public bool IsSymmetric(TreeNode root) {
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        q.Enqueue(root);
        
        while (q.Count > 0)
        {
            var leftSide = q.Dequeue();
            var rightSide = q.Dequeue();
            
            if (leftSide == null && rightSide == null) continue;
            if (leftSide?.val != rightSide?.val) return false;
            
            q.Enqueue(leftSide.left);
            q.Enqueue(rightSide.right);
            q.Enqueue(leftSide.right);
            q.Enqueue(rightSide.left);            
        }
        
        return true;        
    }
}
