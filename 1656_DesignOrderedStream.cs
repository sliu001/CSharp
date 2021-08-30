/*
LC1656 - Design an Ordered Stream
https://leetcode.com/problems/design-an-ordered-stream/

There is a stream of n (idKey, value) pairs arriving in an arbitrary order, where idKey is an integer between 1 and n and value is a string. 
No two pairs have the same id.

Design a stream that returns the values in increasing order of their IDs by returning a chunk (list) of values after each insertion. 
The concatenation of all the chunks should result in a list of the sorted values.

Implement the OrderedStream class:
OrderedStream(int n) Constructs the stream to take n values.
String[] insert(int idKey, String value) Inserts the pair (idKey, value) into the stream, then returns the largest possible chunk of currently inserted values that appear next in the order.

Input
["OrderedStream", "insert", "insert", "insert", "insert", "insert"]
[[5], [3, "ccccc"], [1, "aaaaa"], [2, "bbbbb"], [5, "eeeee"], [4, "ddddd"]]
Output
[null, [], ["aaaaa"], ["bbbbb", "ccccc"], [], ["ddddd", "eeeee"]]
*/

public class OrderedStream {
    
    private int pointer;
    string[] values;
    
    public OrderedStream(int n) {
        pointer = 0;
        values = new string[n+1];
    }
    
    public IList<string> Insert(int idKey, string value) {
        values[idKey] = value;
        
        if (idKey == pointer+1)
        {
            pointer++;
            
            if (pointer == values.Length-1) 
                return new List<string> { value };
            
                
            while (!string.IsNullOrEmpty(values[pointer+1]))
            {
                pointer++;
                if (pointer == values.Length-1)
                    break;                    
            }
            
            return values[idKey..(pointer+1)].ToList();
        }
        else
            return new List<string>();
    }
}

/**
 * Your OrderedStream object will be instantiated and called as such:
 * OrderedStream obj = new OrderedStream(n);
 * IList<string> param_1 = obj.Insert(idKey,value);
 */
