using System.Xml;

namespace DataStructure.Algo.DP;

public class _62_UniquePaths
{
    public int UniquePaths(int m, int n)
    {
        //dp[i,j] 表示到达ij 位置的路径数
        int[,] dp = new int[m + 1, n + 1];

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (i == 0||j==0)
                {// 如果是第一行或第一列 设置为1
                    dp[i, j] = 1;
                }
                else
                {// 否则，路径数量等于上方格子和左方格子的路径数量之和
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
        }

        return dp[m - 1, n - 1];
    }

    public static void Test()
    {
        var uniquePaths = new _62_UniquePaths().UniquePaths(3,2);
        Console.WriteLine(uniquePaths);
    }
}