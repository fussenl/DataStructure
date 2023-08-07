namespace DataStructure.Algo.Backtrack;

public class _213_RobII
{
    public int Rob(int[] nums)
    {
        int n = nums.Length;
        int leftrob = dfs(nums, 0, n - 2);
        int rightrob = dfs(nums, 1, n - 1);
        return Math.Max(leftrob, rightrob);
    }

    private int dfs(int[] nums, int start, int end)
    {
        if (start >= end)
        {
            return 0;
        }

        int left = dfs(nums, start + 1, end - 2);
        int r = dfs(nums, start + 2, end - 1);
        return Math.Max(left, r + nums[start]);
    }

    public static void Test()
    {
        int[] nums = { 2, 3, 2 };
        var rob = new _213_RobII().Rob(nums);
        Console.WriteLine(rob);
    }
}