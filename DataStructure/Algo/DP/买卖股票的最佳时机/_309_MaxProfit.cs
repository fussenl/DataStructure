namespace DataStructure.Algo.DP.买卖股票的最佳时机;

public class _309_MaxProfit
{//和122号算法题差不多 只是加了一个冷却时间

    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        int[,] dp = new int[n, 2];
        dp[0, 0] = 0;
        dp[0, 1] = -prices[0];

        for (int i = 1; i < n; i++)
        {
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
            // 在有「冷却时间」的情况下，如果在第 i - 1 天卖出了股票，就不能在第 i 天买入股票。
            // 因此，如果要在第 i 天买入股票，那么在第 i - 1 天就不能卖出股票
            // 那么第 i - 1 天不买股票并且不持有股票获取最大的利润就
            // 等于第 i - 2 天不持有股票的最大利润 dp[i - 2][0]
            //i>=2 是防止越界的判断
            dp[i, 1] = Math.Max(dp[i - 1, 1], (i >= 2 ? dp[i - 2, 0] : 0) - prices[i]);
        }

        return dp[n - 1, 0];
    }
    
    
    public int MaxProfit1(int[] prices) {
        int buy = int.MinValue; // 买入股票的最大利润
        int sell = 0; // 卖出股票的最大利润
        int rest = 0; // 休息的最大利润
    
        for (int i = 0; i < prices.Length; i++) {
            int prevBuy = buy;
            buy = Math.Max(buy, rest - prices[i]); // 更新买入股票的最大利润
            rest = Math.Max(rest, sell); // 更新休息的最大利润
            sell = Math.Max(sell, prevBuy + prices[i]); // 更新卖出股票的最大利润
        }
    
        return sell;
    }


    public int MaxProfit2(int[] prices)
    {
        int prevProfit = 0;
        int profit1 = 0;
        int profit2 = -prices[0];
        for (int i = 1; i < prices.Length; i++)
        {
            int nextprofit1 = Math.Max(profit1, profit2 + prices[i]);
            int nextprofit2 = Math.Max(profit2, prevProfit - prices[i]);
            prevProfit = profit1;
            profit1 = nextprofit1;
            profit2 = nextprofit2;
        }

        return profit1;
    }

    public static void Test()
    {
        int[] prices = { 1, 2, 3, 0, 2 };
        var maxProfit = new _309_MaxProfit().MaxProfit(prices);
        var maxProfit1 = new _309_MaxProfit().MaxProfit1(prices);
        var maxProfit2 = new _309_MaxProfit().MaxProfit2(prices);
        Console.WriteLine(maxProfit);
        Console.WriteLine(maxProfit1);
        Console.WriteLine(maxProfit2);
    }
}