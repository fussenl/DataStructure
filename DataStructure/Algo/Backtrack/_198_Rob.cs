namespace DataStructure.Algo.Backtrack;

public class _198_Rob
{
    public int Rob(int[] nums)
    {
        int n = nums.Length;
        int[] sub = new int[n + 1];
        return dfs(nums, 0);
    }

    private int dfs(int[] nums, int i)
    {
        if (i >= nums.Length)
        {
            return 0;
        }

        int left = dfs(nums, i + 1);
        int right = dfs(nums, i + 2);
        return Math.Max(left, right + nums[i]);
    }

    public static void Test()
    {
        int[] nuns = { 1, 2, 3, 1 };
        var rob = new _198_Rob().Rob(nuns);
        Console.WriteLine(rob);
    }
}