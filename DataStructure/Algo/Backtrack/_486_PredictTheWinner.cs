namespace DataStructure.Algo.Backtrack;

public class _486_PredictTheWinner
{
    public bool PredictTheWinner(int[] nums)
    {
        int n = nums.Length;
        // int[,] meno = new int[n, n];
        // for (int i = 0; i < nums.Length; i++)
        // {
        //     for (int j = 0; j < nums.Length; j++)
        //     {
        //         Array.Fill(new[] { meno[i,j] }, int.MaxValue);
        //     }
        // }
        int[][] meno = new int[n][];
        for (int i = 0; i < n; i++)
        {
            meno[i] = new int[n];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            Array.Fill(meno[i],int.MaxValue);
        }
        
        return dfs1(nums, 0, nums.Length - 1, meno)>=0;
    }

    private int dfs1(int[] nums, int i, int j, int[][] meno)
    {
        if (i == j) return nums[i];
        if (meno[i ][j] != int.MaxValue)
        {
            return meno[i ][j];
        }

        int left = nums[i] - dfs1(nums, i + 1, j, meno);
        int right = nums[j] - dfs1(nums, i, j - 1, meno);
        meno[i][j] = Math.Max(left, right);
        return meno[i][j];
;    }


    public bool PredictTheWinner1(int[] nums)
    {
        return dfs(nums, 0, nums.Length - 1) >= 0;
    }

    private int dfs(int[] nums, int i, int j)
    {
        if (i==j)
        {
            return nums[i];//只有一个数了
        }

        int left = nums[i] - dfs(nums, i + 1, j);
        int right = nums[j] - dfs(nums, i , j-1);
        return Math.Max(left, right);
    }

    public static void Test()
    {
        int[] nums = { 1, 5, 2 };
        var predictTheWinner = new _486_PredictTheWinner().PredictTheWinner(nums);
        Console.WriteLine(predictTheWinner);
    }
}