namespace DataStructure.Algo.DP;

public class _63_UniquePathsWithObstacles
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;

        //dp[m][n]  到达 m，n位置的路径数量
        int[][] dp = new int[m][];
        for (int i = 0; i < m; i++)
        {
            dp[i] = new int[n];
        }

        //格子第一个格子如果没有障碍物那就有1个数量 不然无法到达
        dp[0][0] = obstacleGrid[0][0] == 0 ? 1 : 0;
        //初始化一列到终点的路径
        for (int i = 1; i < m; i++)
        {
            //如果这一列上没有障碍物 前一个位置上是路径数为1
            if (obstacleGrid[i][0] == 0 && dp[i - 1][0] == 1)
            {
                //那么这个位置上的总路径数为1
                dp[i][0] = 1;
            }
        }

        //初始化一行到终点的路径
        for (int i = 1; i < n; i++)
        {
            if (obstacleGrid[0][i] == 0 && dp[0][i - 1] == 1)
            {
                dp[0][i] = 1;
            }
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                //如果这个位置上有障碍物 那么不能通过 这个位置路径为0
                if (obstacleGrid[i][j] == 1)
                {
                    dp[i][j] = 0;
                    continue;
                }

                //能通过这个位置路径数是上方格子和左方格子的总和
                dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
            }
        }

        return dp[m - 1][n - 1];
    }


    public static void Test()
    {
        int[][] obstacleGrid =
        {
            new int[] { 0, 0, 0 },
            new int[] { 0, 1, 0 },
            new int[] { 0, 0, 0 }
        };
        
        int[][] obstacleGrid1 =
        {
            new int[] { 0, 1 },
            new int[] { 0, 0 }
        };
        var obstacles = new _63_UniquePathsWithObstacles().UniquePathsWithObstacles(obstacleGrid1);
        Console.WriteLine(obstacles);
    }
}