namespace DataStructure.Algo.DP.背包问题;

public class _377_CombinationSum4
{
    public int CombinationSum4(int[] nums, int target)
    {//这是一个完全背包问题
        int[] dp = new int[target + 1];
        dp[0] = 1;
            // 1. 状态定义：dp[c] : 能够凑成 target 为 c 的组合数。
        for (int i = 1; i <=target; i++)
        {//与硬币兑换相反 从左往右遍历
            foreach (var num in nums)
            {
                if (i>=num)
                {
                    dp[i] += dp[i - num];
                }
            }
        }
      

        return dp[target];
    }

    public static void Test()
    {
        int[] nums = { 1, 2, 3 };
        int target = 4;
        var combinationSum4 = new _377_CombinationSum4().CombinationSum4(nums,target);
        Console.WriteLine(combinationSum4);
    }
}