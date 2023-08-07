namespace DataStructure.Algo.Backtrack;

public class _494_FindTargetSumWays
{
    // 假设数组中所有数字的总和为 sum
    // 假设前面设置为负数的数字的总和是 neg，那么设置为正数的数字的总和为 sum - neg
    // (sum - neg) - neg = target => neg = (sum - target) / 2
    // 在数组 nums 列表中不可重复的选择数字组合，使得组合中所有数字之和为 neg(背包容量)
    // 求有多少组合数？
    // 0 - 1 背包问题

    private int ans = 0;

    public int FindTargetSumWays(int[] nums, int target)
    {
        dfs(nums, target, 0, 0);
        return ans;
    }

    private void dfs(int[] nums, int target, int i, int sum)
    {
        if (i == nums.Length)
        {
            if (sum == target)
            {
                ans++;
            }
            return;
        }

        dfs(nums, target, i + 1, sum + nums[i]);
        dfs(nums, target, i + 1, sum - nums[i]);
    }
}