namespace DataStructure.Algo.DP;

public class _54_MaxSubArray
{
    public int MaxSubArray(int[] nums)
    {
        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        int maxSum = dp[0];
        for (int i = 1; i < nums.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
            maxSum = Math.Max(maxSum, dp[i]);
        }

        return maxSum;
    }

    public static void Test()
    {
        int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        var maxSubArray = new _54_MaxSubArray().MaxSubArray(nums);
        Console.WriteLine(maxSubArray);
    }
}