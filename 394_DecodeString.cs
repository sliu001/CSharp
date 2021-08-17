/*
LC394
The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.
Example 1:
Input: s = "3[a]2[bc]"
Output: "aaabcbc"
Example 2:
Input: s = "3[2[a]e2[cd]]"
Output: "aaecdcdaaecdcdaaecdcd"
*/
//using Stack<Tuple<int, List<char>>> to handle embedded brackets. 
//int is for the repeated times, List<char> is for the string needed to be repeated.

public class Solution {
    public string DecodeString(string s) {
        
        List<char> res = new List<char>();
        Stack<Tuple<int, List<char>>> stk = new Stack<Tuple<int, List<char>>>();
        
        List<char> currStr = new List<char>();
        int currMult = 0;
        
        for (int i=0; i<s.Length; i++)
        {
            if (s[i] >= '0' && s[i] <= '9')
            {
                if (currStr.Count > 0 || (i>0 && s[i-1]=='['))
                { 
                    stk.Push(new Tuple<int, List<char>> (currMult, new List<char>(currStr)));
                    currStr.Clear();
                    currMult = 0;
                }                
                
                currMult = currMult*10 + (s[i] - '0');
            }
            else if (s[i] >= 'a' && s[i] <= 'z')
            {
                if (currMult == 0 && stk.Count == 0)
                    res.Add(s[i]);
                else if (currMult == 0 && stk.Count > 0)
                {
                    var item = stk.Pop();
                    item.Item2.Add(s[i]);
                    stk.Push(item);
                }
                else
                    currStr.Add(s[i]);
            }
            else if (s[i] == ']')
            {
                if (currStr.Count > 0)
                {
                    stk.Push(new Tuple<int, List<char>> (currMult, new List<char>(currStr)));
                    currStr.Clear();
                    currMult = 0;
                }
                
                var item = stk.Pop();
                if (stk.Count > 0)
                {
                    var nextItem = stk.Pop();
                    for (int j=0; j<item.Item1; j++)
                    {
                        nextItem.Item2.AddRange(item.Item2);
                    }  
                    stk.Push(nextItem);                    
                }
                else
                {
                    for (int j=0; j<item.Item1; j++)
                    {
                        res.AddRange(item.Item2);
                    }
                }                
            }
        }
        
        return new string(res.ToArray());
    }
}
