namespace DataStructure.Algo.DP.背包问题;

// 多重背包：
// 有 n 种物品和一个容量为 C 的背包
// 第 i 种物品的重量是 w[i]，价值是 v[i]，件数是 p[i]
// 求将哪些物品装入背包可使得价值总和最大

public class _多重背包问题
{
    #region DFS

    private int maxvalue;

    public int Mbp(int[] w, int[] v, int[] p, int capacity)
    {
        dfs(w, v, p, capacity, 0, 0);
        return maxvalue;
    }

    private void dfs(int[] w, int[] v, int[] p, int capacity, int curw, int curv)
    {
        if (curw > capacity) return;

        maxvalue = Math.Max(maxvalue, curv);
        for (int i = 0; i < w.Length; i++)
        {
            if (p[i] > 0)
            {
                p[i]--;
                int newW = curw + w[i];
                int newV = curv + v[i];
                dfs(w, v, p, capacity, newW, newV);
                p[i]++;
            }
        }
    }

    #endregion

    public int Mbp1(int[] w, int[] v, int[] p, int capacity)
    {
        int n = w.Length;
        int[,] dp = new int[n + 1, capacity + 1];
        for (int i = 1; i <= n; i++)
        {
            int weight = w[i - 1];
            int value = v[i - 1];
            for (int j = 0; j <= capacity; j++)
            {
                for (int k = 0; k <= p[i - 1] &&
                                k * weight  <= j; k++)
                {//遍历物品数量,物品*重量=总重量 要小于容量 就能装进背包
                    dp[i, j] = Math.Max(dp[i, j], 
                        dp[i - 1, j - k * weight] + k * value);
                }
            }
        }

        return dp[n, capacity];
    }

    public static void Test()
    {
        int[] weights1 = { 2, 3, 4 };
        int[] values1 = { 3, 4, 5 };
        int[] counts1 = { 1, 2, 3 };
        var mbp = new _多重背包问题().Mbp(weights1, values1, counts1, 10);
        Console.WriteLine(mbp);
        var mbp1 = new _多重背包问题().Mbp1(weights1, values1, counts1, 10);
        Console.WriteLine(mbp1);
    }
}