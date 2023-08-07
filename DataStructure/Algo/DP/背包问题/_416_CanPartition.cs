namespace DataStructure.Algo.DP.背包问题;

public class _416_CanPartition
{
    //抽象为01背包问题
    // 先计算得到数组的总和为 sum，然后将 sum / 2 得到一半，记为 target(背包容量)
    // 问题转变为 0-1 背包问题：
    // 在数组 nums 中不可重复的选择数字组合，是否存在和等于 target 的组合呢？
    public bool CanPartition(int[] nums)
    {
        int sum = 0;
        foreach (var num in nums)
        {
            sum += num;
        }

        if (sum % 2 == 1) return false;
        int target = sum / 2;
        
        //dp[i] 表示是否能够找到 总和为i的集合
        bool[] dp = new bool[target + 1];
        dp[0] = true;
        foreach (var num in nums)
        {
            for (int i = target; i >= num; i--)
            {
                dp[i] = dp[i]|| dp[i - num];
            }
        }

        return dp[target];
    }

    public static void Test()
    {
        int[] nums = { 1, 5, 11, 5 };
        var canPartition = new _416_CanPartition().CanPartition(nums);
        Console.WriteLine(canPartition);
    }
}