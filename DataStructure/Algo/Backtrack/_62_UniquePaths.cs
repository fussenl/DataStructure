namespace DataStructure.Algo.Backtrack;

public class _62_UniquePaths
{
    public int UniquePaths(int m, int n)
    {
        int[][] meno = new int[m][];
        for (int i = 0; i < m; i++)
        {
            meno[i] = new int[n];
        }

        for (int i = 0; i < m; i++)
        {
            Array.Fill(meno[i], -1);
        }

        return dfs(m, n, 0, 0, meno);
    }

    private int dfs(int m, int n, int i, int j, int[][] meno)
    {
        if (i == m - 1 || j == n - 1) return 1;
        if (i == m || j == n) return 0;
        if (meno[i][j] != -1) return meno[i][j];
        int left = dfs(m, n, i, j + 1, meno);
        int right = dfs(m, n, i + 1, j, meno);
        meno[i][j] = left + right;
        return meno[i][j];
    }

    public static void Test()
    {
        var uniquePaths = new _62_UniquePaths().UniquePaths(3, 2);
        Console.WriteLine(uniquePaths);
    }
}