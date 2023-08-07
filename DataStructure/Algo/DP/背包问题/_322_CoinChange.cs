namespace DataStructure.Algo.DP.背包问题;

public class _322_CoinChange
{
    public int CoinChange(int[] coins, int amount)
    {
        if (amount < 0) return -1;
        if (amount == 0) return 0;
        int[] dp = new int[amount + 1];

        //状态初始化  dp[i]表示 amount 为i需要的最小conis
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        for (int target = 1; target <= amount; target++)
        {
            foreach (var c in coins)
            {
                if (target >= c && dp[target - c] != int.MaxValue)
                {// 如果当前硬币可以使用且剩余金额有有效的解决方案  状态方程
                    dp[target] = Math.Min(dp[target], dp[target - c] + 1);
                }
            }
        }

        //返回最终需要的状态值
        return dp[amount] == int.MaxValue ? -1 : dp[amount];// 如果dp[amount]不是int.MaxValue（表示有效解决方案），则返回dp[amount]，否则返回-1
    }

    public static void Test()
    {
        int[] coins = { 1, 2, 5 };
        int amount = 11;
        var coinChange = new _322_CoinChange().CoinChange(coins, amount);
        Console.WriteLine(coinChange);
    }
}