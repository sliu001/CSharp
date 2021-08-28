/*
LC518. Coin Change 2 - You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
Return the number of combinations that make up that amount. If that amount of money cannot be made up by any combination of the coins, return 0.

Input: amount = 5, coins = [1,2,5]
Output: 4
Explanation: there are four ways to make up the amount:
5=5
5=2+2+1
5=2+1+1+1
5=1+1+1+1+1

Input: amount = 3, coins = [2]
Output: 0
*/
//dp[i] = sum(dp[i-coin[j]])

public class Solution {
    public int Change(int amount, int[] coins) {
        int[] dp = new int[amount+1];
        dp[0] = 1;
        
        for (int i=1; i<=amount; i++)
        {
            dp[i] = 0;
        }
        
        for (int i=0; i<coins.Length; i++)
        {
            for (int j=1; j<=amount; j++)
            {
                if (j >= coins[i])
                    dp[j] += dp[j-coins[i]];
            }
        }
        
        return dp[amount];
    }
}
