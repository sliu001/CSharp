//LC227
/*
s consists of integers and operators ('+', '-', '*', '/') separated by some number of spaces.
*/
public class Solution {
    public int Calculate(string s) {
        
        Stack<int> nums = new Stack<int>();
        int sign = 1, idx=0, currNum = 0;
        
        while (idx < s.Length)
        {
            if (s[idx] == '+')
            {
                sign = 1;
                idx++;
            }
            else if (s[idx] == '-')
            {
                sign = -1;
                idx++;
            }
            else if (s[idx] == ' ')
            {
                idx++;
            }
            else if (s[idx]-'0' >=0 && s[idx]-'0'<=9)
            {
                var num = 0;
                while (idx < s.Length && s[idx]-'0' >=0 && s[idx]-'0'<=9)
                {
                    num = num*10 + (s[idx]-'0');
                    idx++;
                }
                
                nums.Push(sign*num);
            }
            else
            {
                bool isMulti = s[idx] == '*';
                
                var prevNum = nums.Pop();                
                var nextNum = 0;                
                idx++;
                while (s[idx] == ' ') idx++;
                
                while (idx < s.Length && s[idx]-'0' >=0 && s[idx]-'0'<=9)
                {
                    nextNum = nextNum*10 + (s[idx]-'0');
                    idx++;
                }                
                
                nums.Push(isMulti ? prevNum*nextNum : prevNum/nextNum);
            }
        }
        
        int result = 0;
        while (nums.Count > 0)
        {
            result += nums.Pop();
        }
        
        return result;
    }
}
