/*
LC2 - Add Two Numbers from 2 linked list
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, 
and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
 
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        
        ListNode head = new ListNode();
        ListNode curr = head;
        bool carry = false;
        
        while (l1 != null || l2 != null || carry)
        {
            curr.val = (l1?.val ?? 0) + (l2?.val ?? 0) + (carry ? 1 : 0);
            if (curr.val >= 10)
            {
                curr.val -= 10;
                carry = true;
            }
            else
                carry = false;
            
            l1 = l1?.next;
            l2 = l2?.next;
            
            if (l1 != null || l2 != null || carry)
            {
                curr.next = new ListNode();
                curr = curr.next;
            }
        }
        
        return head;
    }
}
