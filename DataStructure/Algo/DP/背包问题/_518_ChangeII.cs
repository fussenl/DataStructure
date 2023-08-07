namespace DataStructure.Algo.DP.背包问题;

public class _518_ChangeII
{
    public int Change(int amount, int[] coins)
    {
        //DP[i] 表示凑出金额i的组合数
        int[] dp = new int[amount + 1];
        dp[0] = 1;
        foreach (var c in coins)
        {
            for (int i = c; i <= amount; i++)
            {
                //我们可以在已经凑出金额i-coin的基础上，
                ////再使用一枚硬币面额为coin，就可以凑出金额i。
                dp[i] = dp[i] + dp[i - c];
            }
        }

        return dp[amount];
    }

    public static void Test()
    {
        int amount = 5;
        int[] coins = { 1, 2, 5 };
        var change = new _518_ChangeII().Change(amount, coins);
        Console.WriteLine(change);
    }
}