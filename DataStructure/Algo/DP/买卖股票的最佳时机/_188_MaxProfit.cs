namespace DataStructure.Algo.DP.买卖股票的最佳时机;

public class _188_MaxProfit
{//123是枚举出来的 但我们不知道k的次数 所以我们for循环 枚举
    // dp[i][k][0] = max(dp[i - 1][k][0], dp[i - 1][k][1] + prices[i])
    // dp[i][k][1] = max(dp[i - 1][k][1], dp[i - 1][k - 1][0] - prices[i])
    public int MaxProfit(int k, int[] prices)
    {
        int n = prices.Length;
        if (k==0||n<2) return 0;
        if (k >= n / 2) return maxprofit(prices);
        
        int[,,] dp = new int[n, k + 1, 2]; //第n天 第几次交易 是否持有股票
        // //初始化 
        // dp[0, k - 1, 0] = 0;
        // dp[0, k - 1, 1] = -prices[0]; //第0天第一次交易持有股票的最大利润
        // dp[0, k, 0] = 0;
        // dp[0, k, 1] = -prices[0];

        //初始化
        for (int j = 1; j <=k; j++)
        {
            dp[0, j, 0] = 0;
            dp[0, j, 1] = -prices[j];
        }

        for (int i = 1; i < prices.Length; i++)
        {
            for (int j = 1; j <=k; j++)
            {
                dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], dp[i - 1, j, 1] + prices[i]);
                dp[i, j, 1] = Math.Max(dp[i - 1, j, 1], dp[i - 1, j - 1, 0] - prices[i]);
            }
        }

        return dp[n - 1, k, 0];
    }

    private int maxprofit(int[] prices)
    {
        int maxprofit = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] > prices[i - 1])
            {
                maxprofit += prices[i] - prices[i - 1];
            }
        }

        return maxprofit;
    }

    public static void Test()
    {
        int k = 2;
        int[] prices = { 2, 4, 1 };
        var profit = new _188_MaxProfit().MaxProfit(k, prices);
        Console.WriteLine(profit);
    }
}