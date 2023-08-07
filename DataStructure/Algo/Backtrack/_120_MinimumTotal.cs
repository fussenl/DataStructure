namespace DataStructure.Algo.Backtrack;

public class _120_MinimumTotal
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        int n = triangle.Count;
        int[][] meno = new int[n][];
        for (int i = 0; i < n; i++)
        {
            meno[i] = new int[n];
        }

        for (int i = 0; i < n; i++)
        {
            Array.Fill(meno[i], int.MaxValue);
        }

        return dfs(triangle, 0, 0, meno);
    }

    private int dfs(IList<IList<int>> triangle, int i, int j, int[][] meno)
    {
        if (i == triangle.Count)
        {
            return 0;
        }

        if (meno[i][j] != int.MaxValue) return meno[i][j];
        int left = dfs(triangle, i + 1, j, meno);
        int right = dfs(triangle, i + 1, j + 1, meno);

        meno[i][j] = Math.Min(left , right) + triangle[i][j];
        return meno[i][j];
    }

    public static void Test()
    {
        int[][] triangle =
        {
            new int[] { 2 },
            new int[] { 3, 4 },
            new int[] { 6, 5, 7 },
            new int[] { 4, 1, 8, 3 }
        };

        var total = new _120_MinimumTotal().MinimumTotal(triangle);
        Console.WriteLine(total);
    }
}