namespace DataStructure.Algo.DP.背包问题;

//容量为c的背包 n种物体  重量为W 价值为V
//第 i个物体 重量为 W[i] 价值为 V[i];
//可以放哪些物品 使不超过容量 价值最大

public class _01背包问题
{
    #region DFS前序解决

    // Capacity 为容量 W为重量 V为价值

    public int CAwaner(int[] w, int[] v, int C)
    {
        return dfs(-1, C, 0, w, v, 0); //物品索引 剩余容量 累计价值  最大价值
    }

    private int dfs(int index, int c, int value, int[] w, int[] v, int maxvalue)
    {
        maxvalue = Math.Max(maxvalue, value);
        for (int i = index; i < w.Length; i++)
        {
            int childIndex = i + 1;
            if (childIndex == w.Length) continue; //剪枝  超出物品个数了
            if (c < w[childIndex]) continue; //放的物品的容量超过背包的容量
            maxvalue = dfs(childIndex, c - w[childIndex], value + v[childIndex], w, v, maxvalue);
        }

        return maxvalue;
    }

    #endregion

    #region DFS后序

    public int knapsack(int[] w, int[] v, int C)
    {
        return dfs2(-1, C, w, v);
    }

    private int dfs2(int index, int c, int[] W, int[] V)
    {
        int maxValue = 0;
        for (int i = index; i < W.Length; i++)
        {
            int childindex = i + 1;
            if (childindex == W.Length) continue;
            if (c < W[childindex]) continue;
            int childValue = dfs2(childindex, c - W[childindex], W, V);
            maxValue = Math.Max(childValue, maxValue);
        }

        return maxValue + (index == -1 ? 0 : V[index]);
    }

    #endregion

    public int knapsack2(int[] w, int[] v, int Capacity)
    {
        int n = w.Length;
        // 1. 状态定义：dp[i][c] 表示从 [0...i]中选取物品放入容量为 c 的背包中的最大价值
        int[,] dp = new int[n + 1, Capacity + 1];

        for (int i = 1; i <=n; i++)
        {
            //当前物品的重量
            int weight = w[i - 1];
            int value = v[i - 1];//当前物品的价值
            for (int c = 1; c <=Capacity; c++)
            {
                if (weight > c)
                {  // 如果当前物品的重量超过背包的容量，无法放入背包
                    // 则当前子问题的最优解与上一个子问题的最优解相同
                    dp[i, c] = dp[i - 1, c];
                }
                else
                {  // 否则，需要比较放入当前物品和不放入当前物品两种情况下的最优解  
                    dp[i, c] = Math.Max(dp[i - 1, c], dp[i - 1, c - weight] + value);
                }
            }
        }
        
        return dp[n , Capacity]; //返回最后一个物品的容量江能得到他的最大值
    }

    public static void Test()
    {
        int[] w = { 3, 4, 5 };
        int[] v = { 15, 10, 12 };
        var cAwaner = new _01背包问题().CAwaner(w, v, 10);
        var knapsack = new _01背包问题().knapsack(w, v, 10);
        var knapsack2 = new _01背包问题().knapsack2(w, v, 10);
        Console.WriteLine(cAwaner);
        Console.WriteLine(knapsack);
        Console.WriteLine(knapsack2);
    }
}