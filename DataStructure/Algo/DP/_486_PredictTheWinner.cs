namespace DataStructure.Algo.DP;

public class _486_PredictTheWinner
{
    public bool PredictTheWinner(int[] nums)
    {
        int n = nums.Length;
        //dp[i][j]表示在数组的闭区间[i, j]内，当前玩家能够获得的最大分数差。
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
        }

        for (int i = 0; i < n; i++)
        {
            dp[i][i] = nums[i];
        }

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            //行从倒数第二行开始 对角线处理了一个元素
            for (int j = i + 1; j < nums.Length; j++)
            {
                //列从i+1开始
                dp[i][j] = Math.Max(nums[i] - dp[i + 1][j],
                    nums[j] - dp[i][j - 1]);
            }
        }

        return dp[0][n - 1] >= 0;
    }

    public static void Test()
    {
        int[] nums = { 1, 5, 233, 7 };
        var predictTheWinner = new _486_PredictTheWinner().PredictTheWinner(nums);
        Console.WriteLine(predictTheWinner);
    }
}