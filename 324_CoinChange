/*
LC322 - You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1

Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1

Input: coins = [2], amount = 3
Output: -1
*/

//dp[i] = min(dp[i-coins[j]])+1

public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if (amount == 0) return 0;
        
        int[] dp = new int[amount+1];
        dp[0] = 0;
        for (int i=1; i<=amount; i++)
        {
            dp[i] = Int32.MaxValue;
        }
        
        for (int i=1; i<=amount; i++)
        {
            for (int j=0; j<coins.Length; j++)
            {
                if (i-coins[j]>=0 && dp[i-coins[j]] != Int32.MaxValue)
                    dp[i] = Math.Min(dp[i], dp[i-coins[j]]+1);
            }
        }
        
        return dp[amount] == Int32.MaxValue ? -1 : dp[amount];
    }
}
