namespace DataStructure.Algo.DP;

public class _300_LengthOfLIS
{
    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;
        int[] dp = new int[n];
        int res = 1;
        Array.Fill(dp, 1);
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                    res = Math.Max(dp[i], res);
                }
            }
        }

        return res;
    }

    public static void Test()
    {
        var nums = new[] { 10, 9, 2, 5, 3, 7, 101, 18 };
        var lengthOfLis = new _300_LengthOfLIS().LengthOfLIS(nums);
        Console.WriteLine(lengthOfLis);
    }
}