namespace DataStructure.Algo.DP;

public class _152_MaxProduct
{
    public int MaxProduct(int[] nums)
    {
        int n = nums.Length;

        int[] maxP = new int[n];
        int[] minP = new int[n];
        maxP[0] = nums[0]; // 初始化最大乘积为第一个元素
        minP[0] = nums[0]; // 初始化最小乘积为第一个元素
        int res = nums[0]; // 初始化结果为第一个元素

        for (int i = 1; i < n; i++)
        {
            // 计算当前位置的最大乘积，取值为：前一个位置的最大乘积乘以当前元素、当前元素本身、前一个位置的最小乘积乘以当前元素的最大值
            maxP[i] = Math.Max(maxP[i - 1] * nums[i], Math.Max(nums[i], minP[i - 1] * nums[i]));
            // 计算当前位置的最小乘积，取值为：前一个位置的最小乘积乘以当前元素、当前元素本身、前一个位置的最大乘积乘以当前元素的最小值
            minP[i] = Math.Min(minP[i - 1] * nums[i], Math.Min(nums[i], maxP[i - 1] * nums[i]));
            res = Math.Max(res, maxP[i]); // 更新结果为当前位置的最大乘积和之前的结果中的较大值
        }

        return res; // 返回最大乘积
    }


    public static void Test()
    {
        int[] nums = { 2, 3, -2, 4 };
        var maxProduct = new _152_MaxProduct().MaxProduct(nums);
        Console.WriteLine(maxProduct);
    }
}