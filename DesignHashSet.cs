//705
public class MyHashSet {
    
    private const int MOD = 10000;
    private Node[] hashset;
    
    /** Initialize your data structure here. */
    public MyHashSet() {
        hashset = new Node[MOD];
    }
    
    public void Add(int key) {
        var nodeHead = hashset[key%MOD];
        
        if (nodeHead == null)
        {
            hashset[key%MOD] = new Node(key, null);            
        }
        else
        {
            while (nodeHead != null)
            {
                if (nodeHead.val == key) 
                    return;
                else
                {
                    if (nodeHead.next != null)
                        nodeHead = nodeHead.next;
                    else
                        nodeHead.next = new Node(key, null);
                }                    
            }
        }
    }
    
    public void Remove(int key) {
        var nodeHead = hashset[key%MOD];
        
        if (nodeHead == null)
        {
            return;            
        }
        else
        {            
            Node curr = nodeHead;
            if (curr.val == key)
                nodeHead = nodeHead.next;
            else
            {
                while (curr.next != null)
                {
                    if (curr.next.val == key)
                    {
                        curr.next = curr.next.next;
                        break;
                    }
                    curr = curr.next;
                }
            }

            hashset[key%MOD] = nodeHead;
        }        
    }
    
    /** Returns true if this set contains the specified element */
    public bool Contains(int key) {
        var nodeHead = hashset[key%MOD];
        while (nodeHead != null)
        {
            if (nodeHead.val == key)
                return true;
            else
                nodeHead = nodeHead.next;
        }
        return false;
    }
}

public class Node {
    public int val;
    public Node next;
    public Node(int _val=0, Node _next=null)
    {
        this.val = _val;
        this.next = _next;
    }
}
/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */
