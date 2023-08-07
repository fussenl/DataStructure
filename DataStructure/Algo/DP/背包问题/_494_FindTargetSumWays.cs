namespace DataStructure.Algo.DP.背包问题;

public class _494_FindTargetSumWays
{
    // 假设数组中所有数字的总和为 sum
    // 假设前面设置为负数的数字的总和是 neg，那么设置为正数的数字的总和为 sum - neg
    // (sum - neg) - neg = target => neg = (sum - target) / 2
    // 在数组 nums 列表中不可重复的选择数字组合，使得组合中所有数字之和为 neg(背包容量)
    // 求有多少组合数？
    // 0 - 1 背包问题

    public int FindTargetSumWays(int[] nums, int target)
    {
        int sum = 0;
        foreach (var num in nums)
        {
            sum += num;
        }

        //如果目标数大于总和 或者s+t为奇数 则无法分配满足条件的符号
        if (Math.Abs(target) > Math.Abs(sum) || (sum + target) % 2 == 1) return 0;
        int tar = (target + sum) / 2; //目标和的一半
        //dp[i] 为前i个元素使用符号和为j的方法数
        int[] dp = new int[tar + 1];
        dp[0] = 1;
        foreach (var num in nums)
        {
            for (int i = tar; i >= num; i--)
            {
                dp[i] += dp[i - num];
            }
        }

        return dp[tar];
    }

    public static void Test()
    {
        int[] nums = { 1, 1, 1, 1, 1 };
        int[] nums1 = { 100 };

        int target = 3;
        int target1 = -200;
        var findTargetSumWays = new _494_FindTargetSumWays().FindTargetSumWays(nums1, target1);
        Console.WriteLine(findTargetSumWays);
    }
}