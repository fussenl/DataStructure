namespace DataStructure.Algo.DP.背包问题;

public class _279_NumSquares
{
    //完全平方数是1 最大是 sqrt(n)
    //范围在 1--- sqrt(n); 令其平方和为 n （背包容量）
    //求最少的完全平方数  和零钱兑换相似
    public int NumSquares(int n)
    {
        //dp[i] 表示 和为i的nums的 完全平方最少数
        int[] dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;
        for (int num = 1; num <= Math.Sqrt(n); num++)
        {
            for (int i = num * num; i <= n; i++)
            {
               
                dp[i] = Math.Min(dp[i], dp[i - num * num] + 1);
            }
        }

        return dp[n];
    }

    public static void Test()
    {
        var numSquares = new _279_NumSquares().NumSquares(12);
        Console.WriteLine(numSquares);
    }
}