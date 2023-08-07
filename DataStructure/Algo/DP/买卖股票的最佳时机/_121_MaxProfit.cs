namespace DataStructure.Algo.DP.买卖股票的最佳时机;

public class _121_MaxProfit
{
    //n 股票的价格的长度  i 表示第 i 天 [0，n-1]  k 交易次数 
    // dp[i][0][0] = 0  在121中k为1 无限制
    //原式 dp[i][k][0] = max (dp[i - 1][k][0],dp[i - 1][k][1] + prices[i])
    //     dp[i][k][1] = max (dp[i - 1][k][0],dp[i - 1][k - 1][1] - prices[i])
    // dp[i][k][0] = max(dp[i - 1][0], dp[i - 1][1] + prices[i])
    // dp[i][k][1] = max(dp[i - 1][1], -prices[i])
    public int MaxProfit(int[] prices)
    {
        //dp[i][k] 表示第i天进行了 k次交易后的最大利润
        //dp[i][k][0 || 1] 表示第i天进行了 k次交易后的最大利润 是否持有股票
        int n = prices.Length;

        int[,] dp = new int[n, 2]; // 2 为 0 1 持有和不持有
        dp[0, 0] = 0; //第0 天不持有股票
        dp[0, 1] = -prices[0]; //第0 天持有股票

        for (int i = 1; i < n; i++)
        {
            //当天不持有股票的最大利润= 前一天不持有股票的利润 和持有股票的利润  的最大值
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
            //当天持有股票的最大利润= 前一天持有股票的利润 和 当天不持有股票的利润 的最大值
            dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
        }

        return dp[n - 1, 0]; //最后一天不持有股票的最大利润 如果有股票就亏了 卖出去才有利润
    }

    //状态数组压缩
    public int MaxProfit1(int[] prices)
    {
        int profit1 = 0;
        int profit2 = -prices[0];
        for (int i = 1; i < prices.Length; i++)
        {
            profit1 = Math.Max(profit1, profit2 + prices[i]);
            profit2 = Math.Max(profit2, -prices[i]);
        }

        return profit1;
    }
    
    public static void Test()
    {
        int[] prices = { 7, 1, 5, 3, 6, 4 };
        var maxProfit = new _121_MaxProfit().MaxProfit(prices);
        var maxProfit1 = new _121_MaxProfit().MaxProfit1(prices);
        Console.WriteLine(maxProfit);
        Console.WriteLine(maxProfit1);
    }
}