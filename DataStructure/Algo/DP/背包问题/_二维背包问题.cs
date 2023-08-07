namespace DataStructure.Algo.DP.背包问题;

// 二维费用背包问题：
// 有 n 种物品，每种物品只有 1 件，选择一种物品必须付出两种代价
// 第 i 种物品第一种代价值是 w[i]，第二种代价值是 g[i]，物品的价值是 v[i]
// 对于每种代价都有一个可付出的最大值（两种背包容量）W 和 G
// 问怎样选择物品可以得到最大的价值。

public class _二维背包问题
{
    public int TwoDBag(int[] w, int[] g, int W, int G, int[] v)
    {
        int[,] dp = new int[W + 1, G + 1];
        for (int i = 0; i < w.Length; i++)
        {
            for (int j = W; j >=w[i]; j--)
            {
                for (int k = G; k >=g[i]; k--)
                {
                    //W限制,G限制 减去这间物品的信息wg 加上价值 就是能得到的价值
                    //此时背包的重量和体积分别减少了w[i]和g[i]，并且总价值增加了v[i]。
                    //因此，我们可以通过比较不放入物品i和放入物品i两种情况下的总价值，
                    //选择其中较大的值作为当前状态的最优解
                    dp[j, k] = Math.Max(dp[j, k], dp[j - w[i], k - g[i]] + v[i]);
                }
            }
        }

        return dp[W, G];
    }
}