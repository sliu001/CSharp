/*
LC470 - Given the API rand7() that generates a uniform random integer in the range [1, 7], 
write a function rand10() that generates a uniform random integer in the range [1, 10]. 
You can only call the API rand7(), and you shouldn't call any other API.

    1   2   3   4   5   6   7
1   1   2   3   4   5   6   7
2   8   9  10  11  12  13  14
3  15  16  17  18  19  20  21
4  22  23  24  25  26  27  28
5  29  30  31  32  33  34  35
6  36  37  38  39  40   *   *  
7   *   *   *   *   *   *   *

*/
public class Solution {
    public int Rand10() {
        int row, col, idx;        
        
        do {
            row = Rand7();
            col = Rand7();
            idx = (row-1) * 7 + col;
        } while (idx > 40);

        return 1 + (idx-1)%10;
    }
}
