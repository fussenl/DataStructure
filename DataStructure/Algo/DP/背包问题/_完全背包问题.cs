namespace DataStructure.Algo.DP.背包问题;

// 完全背包：
// 有 n 种物品和一个容量为 C 的背包
// 第 i 种物品的重量是 w[i]，价值是 v[i]，件数是无限
// 求将哪些物品装入背包可使得价值总和最大
public class _完全背包问题
{
    #region DFS

    public int Cbp(int[] w, int[] v, int capacity)
    {
        return dfs(-1, capacity, w, v);
    }

    private int dfs(int index, int capacity, int[] w, int[] v)
    {
        int maxValue = 0;
        for (int i = index; i < w.Length; i++)
        {
            int childIndex = i ;
            if (childIndex == w.Length) continue;
            if (childIndex == -1 || capacity < w[childIndex]) continue; //如果子索引超过了物品的个数
            int childValue = dfs(childIndex, capacity - w[childIndex], w, v);
            maxValue = Math.Max(maxValue, childValue);
        }

        return maxValue + (index == -1 ? 0 : v[index]);
    }

    #endregion

    public int Cbp1(int[] w, int[] v, int capacity)
    {
        int n = w.Length;
        int[,] dp = new int[n + 1, capacity + 1];
        for (int i = 1; i <=n ; i++)
        {
            int weight = w[i - 1];
            int value = v[i - 1];
            for (int c = 1; c <= capacity; c++)
            {
                if (weight <= c)
                {//如果当前物品的重量小于容量 能装
                    dp[i, c] = Math.Max(dp[i - 1, c], dp[i, c - weight] + value);
                }
                else
                {
                    dp[i, c] = dp[i - 1, c ];
                }
            }
        }

        return dp[n, capacity];
    }

    public static void Test()
    {
        int[] w = { 3, 4, 5 };
        int[] v = { 15, 10, 12 };
        var cbp = new _完全背包问题().Cbp(w,v,10);
        var cbp1 = new _完全背包问题().Cbp1(w,v,10);
        Console.WriteLine(cbp);
        Console.WriteLine(cbp1);
    }
}