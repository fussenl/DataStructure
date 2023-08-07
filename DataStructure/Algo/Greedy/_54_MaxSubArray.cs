namespace DataStructure.Algo.Greedy;

public class _54_MaxSubArray
{
    public int MaxSubArray(int[] nums)
    {
        int curSum = 0;
        int MaxSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            curSum = Math.Max(nums[i], curSum + nums[i]);
            MaxSum = Math.Max(MaxSum, curSum);
        }

        return MaxSum;
    }

    public static void Test()
    {
        int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        var maxSubArray = new _54_MaxSubArray().MaxSubArray(nums);
        Console.WriteLine(maxSubArray);
    }
}