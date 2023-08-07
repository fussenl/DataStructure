namespace DataStructure.Algo.Backtrack;

public class _746_MinCostClimbingStairs
{
    public int MinCostClimbingStairs(int[] cost)
    {
        int n = cost.Length;
        return dfs(cost, n);
    }

    private int dfs(int[] cost, int n)
    {
        if (n == 0 ||n == 1)
        {
            return 0;
        }

        int left = dfs(cost, n - 1);
        int right = dfs(cost, n - 2);

        return Math.Min(left + cost[n - 1], right + cost[n - 2]);
    }

    public static void Test()
    {
        int[] cost = { 10, 15, 20 };
        var minCostClimbingStairs = new _746_MinCostClimbingStairs().MinCostClimbingStairs(cost);
        Console.WriteLine(minCostClimbingStairs);
    }
}