namespace DataStructure.Algo.DP;

public class _221_MaximalSquare
{
    public int MaximalSquare(char[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int ans = 0;
        //dp[i,j] 以 i j 这个元素为右下角最大的正方形边长
        int[,] dp = new int[m + 1, n + 1];

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (matrix[i - 1][j - 1] == '1')
                {
                    //当前这个元素的 上一列 左上角 左边的元素谁最小 加上1
                    // dp[i, j]的值由其左边、上边和左上方的三个位置的dp值决定，取最小值加1 自身也是一个正方形
                    dp[i, j] = Math.Min(dp[i, j - 1], Math.Min(dp[i - 1, j - 1], dp[i - 1, j])) + 1;
                    ans = Math.Max(ans, dp[i, j]);
                }
            }
        }

        return ans * ans;
    }

    public static void Test()
    {
        char[][] matrix =
        {
            new char[] { '1', '0', '1', '0', '0' },
            new char[] { '1', '0', '1', '1', '1' },
            new char[] { '1', '1', '1', '1', '1' },
            new char[] { '1', '0', '0', '1', '0' }
        };
        var maximalSquare = new _221_MaximalSquare().MaximalSquare(matrix);
        Console.WriteLine(maximalSquare);
    }
}