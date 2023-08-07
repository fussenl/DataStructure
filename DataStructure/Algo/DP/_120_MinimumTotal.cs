namespace DataStructure.Algo.DP;

public class _120_MinimumTotal
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        int n = triangle.Count;
        // dp[i][j] 表示从点 [i, j] 到底边的最小路径和。
        //例如 6 下边4 1  dp[i][j]为7
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
        }

        for (int i = 0; i < n; i++)
        {//初始化最后一行的元素的最小路径 就等于本身元素的值
            dp[n - 1][i] = triangle[n - 1][i];
        }

        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = 0; j <= i; j++)
            {//从倒数第二行开始，依次计算每个位置的最小路径和。对于当前位置dp[i][j]，
             //它可以通过下一行的相邻两个位置dp[i+1][j]和dp[i+1][j+1]的最小值加上当前位置的值triangle[i][j]得到。
             //即dp[i][j] = Math.Min(dp[i+1][j], dp[i+1][j+1]) + triangle[i][j]。
                dp[i][j] = Math.Min(dp[i + 1][j], dp[i + 1][j + 1]) + triangle[i][j];
            }
        }

        return dp[0][0];
    }
    public static void Test()
    {
        int[][] triangle =
        {
            new int[] { 2 },
            new int[] { 3, 4 },
            new int[] { 6, 5, 7 },
            new int[] { 4, 1, 8, 3 }
        };

        var total = new _120_MinimumTotal().MinimumTotal(triangle);
        Console.WriteLine(total);
    }
}