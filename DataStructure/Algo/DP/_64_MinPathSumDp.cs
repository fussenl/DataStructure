namespace DataStructure.Algo.DP;

public class _64_MinPathSumDp
{
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] dp = new int[m][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
        }

        dp[0][0] = grid[0][0];

        for (int i =0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j != 0)
                {
                    dp[i][j] = grid[i][j] + dp[i][j - 1];
                }
                else if (i != 0 && j == 0)
                {
                    dp[i][j] = grid[i][j] + dp[i - 1][j];
                }
                else if (i != 0 && j != 0)
                {
                    dp[i][j] = grid[i][j] + Math.Min(dp[i - 1][j], dp[i][j - 1]);
                }
            }
        }

        return dp[m-1][n-1];
    }

    public static void Test()
    {
        int[][] grid =
        {
            new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 }
        };
        var pathSum = new _64_MinPathSumDp().MinPathSum(grid);
        Console.WriteLine(pathSum);
    }
}