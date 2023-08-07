namespace DataStructure.Algo.DP;

public class _198_Rob
{
    public int Rob(int[] nums)
    {
        int n = nums.Length;
        int[] dp = new int[n + 1];

        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);
        for (int i = 2; i < n; i++)
        {
            dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);//当前的i值加上i-2的值
        }
        return dp[n - 1];
    }
    
    public static void Test()
    {
        int[] nuns = { 1, 2, 3, 1 };
        var rob = new _198_Rob().Rob(nuns);
        Console.WriteLine(rob);
    }
}