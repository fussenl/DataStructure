namespace DataStructure.Algo.DP;

public class _376_WiggleMaxLength
{
    public int WiggleMaxLength(int[] nums)
    {
        int n = nums.Length;
        int[] up = new int[n]; //表示以第i个元素结尾的最长的上升摆动序列的长度，
        int[] down = new int[n]; //表示以第i个元素结尾的最长的下降摆动序列的长度。
        up[0] = 1;
        down[0] = 1;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] > nums[i - 1]) //上升
            {
                up[i] = down[i - 1] + 1;
                down[i] = down[i - 1];
            }
            else if (nums[i] < nums[i - 1]) //下降
            {
                down[i] = up[i - 1] + 1;
                up[i] = up[i - 1];
            }
            else
            {//相等
                up[i] = up[i - 1];
                down[i] = down[i - 1];
            }
        }

        return Math.Max(up[n - 1], down[n - 1]);
    }

    public static void Test()
    {
        int[] nums = { 1, 7, 4, 9, 2, 5 };
        var wiggleMaxLength = new _376_WiggleMaxLength().WiggleMaxLength(nums);
        Console.WriteLine(wiggleMaxLength);
    }
}