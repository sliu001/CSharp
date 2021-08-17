//LC224
/*
s consists of digits, '+', '-', '(', ')', and ' '
'+' is not used as a unary operation.
'-' could be used as a unary operation but it has to be inside parentheses.
There will be no two consecutive operators in the input.

Input: s = "(1+(4+5+2)-3)+(6+8)"
Output: 23
*/
public class Solution {
    public int Calculate(string s) {        
        Stack<int> signs = new Stack<int>();
        int result = 0, sign = 1, idx=0;
        signs.Push(sign);
        
        while (idx < s.Length)
        {
            if (s[idx] == ' ')
                idx++;
            else if (s[idx] == '+')
            {
                sign = signs.Peek();
                idx++;
            }
            else if (s[idx] == '-')
            {
                sign = -1 * signs.Peek();
                idx++;
            }
            else if (s[idx] == '(')
            {
                signs.Push(sign);
                idx++;
            }
            else if (s[idx] == ')')
            {
                sign = signs.Pop();
                idx++;
            }
            else
            {
                var num = 0;
                while(idx < s.Length && s[idx]-'0' <= 9 && s[idx]-'0' >= 0)
                {
                    num = num*10 + (s[idx]-'0');
                    idx++;
                }
                
                result += sign * num;
            }
        }        
        return result;
    }
}
