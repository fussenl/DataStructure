namespace DataStructure.Algo.DP;

public class _718_FindLength
{
    public int FindLength(int[] nums1, int[] nums2)
    {
        int m = nums1.Length;
        int n = nums2.Length;
        int[,] dp = new int[m + 1, n + 1];
        int res = 0;
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                dp[i, j] = nums1[i ] == nums2[j ] ? dp[i + 1, j + 1] + 1 : 0;
                res = Math.Max(res, dp[i, j]);
            }
            
        }

        return res;
    }

    public static void Test()
    {
        int[] nums1 = { 1, 2, 3, 2, 1 }, nums2 = { 3, 2, 1, 4, 7 };
        var findLength = new _718_FindLength().FindLength(nums1, nums2);
        Console.WriteLine(findLength);
    }
}