namespace DataStructure.Algo.DP;

public class _746_MinCostClimbingStairs
{
    public int MinCostClimbingStairs(int[] cost)
    {
        int n = cost.Length;
        int[] dp = new int[n + 1];
        dp[0] = dp[1] = 0;
        for (int i = 2; i <= n; i++)
        {
            dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
        }
        

        return dp[n];
    }

    public static void Test()
    {
        int[] cost = { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
        var minCostClimbingStairs = new _746_MinCostClimbingStairs().MinCostClimbingStairs(cost);
        Console.WriteLine(minCostClimbingStairs);
    }
}