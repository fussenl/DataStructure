namespace DataStructure.Algo;

public class _2563_CountFairPairs
{
    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        long ans = 0;
        if (lower > upper) return ans;
        Array.Sort(nums);
        var right = CountFP(nums, upper);
        var left = CountFP(nums, lower - 1); //排除等于的数对
        return right - left;
    }

    private long CountFP(int[] nums, int value)
    {
        int i = 0, j = nums.Length - 1;
        long ans = 0;
        while (i < j)
        {
            if (nums[i] + nums[j] <= value)
            {
                ans += j - i;
                i++;
            }
            else
            {
                j--;
            }
        }

        return ans;
    }


   

    public static void Test()
    {
        int[] nums = { 0, 1, 7, 4, 4, 5 };
        int lower = 3;
        int upper = 6;

        var countFairPairs = new _2563_CountFairPairs().CountFairPairs(nums, lower, upper);
        Console.WriteLine(countFairPairs);

       
    }
}