namespace DataStructure.Algo.DP;

public class _213_RobII
{
    public int Rob(int[] nums)
    {
        int n = nums.Length;
        int[] dp1 = new int[n];//dp1[i]表示在不偷窃第一个房屋的情况下，从前i个房屋中能够偷窃的最大金额
        int[] dp2 = new int[n];//dp2[i]表示在不偷窃最后一个房屋的情况下，从前i个房屋中能够偷窃的最大金额。

        dp1[0] = nums[0];
        dp1[1] = nums[0];
        dp2[1] = nums[1];
        for (int i = 2; i < n; i++)
        {
            dp1[i] = Math.Max(dp1[i - 1], dp1[i - 2] + nums[i]);
            dp2[i] = Math.Max(dp2[i - 1], dp2[i - 2] + nums[i]);
        }

        return Math.Max(dp1[n - 1], dp2[n - 2]);
        //不偷窃第一个房屋的情况下，最后一个房屋一定可以偷窃；
        //不偷窃最后一个房屋的情况下，第一个房屋一定可以偷窃
    }
    
    public static void Test()
    {
        int[] nums = { 1,2, 3, 1 };
        var rob = new _213_RobII().Rob(nums);
        Console.WriteLine(rob);
    }
}