namespace DataStructure.Algo.DP.买卖股票的最佳时机;

public class _714_MaxProfit
{
    public int MaxProfit(int[] prices, int fee)
    {
        int n = prices.Length;
        int[,] dp = new int[n, 2];
        dp[0, 0] = 0;
        dp[0, 1] = -prices[0] - fee;
        for (int i = 1; i < n; i++)
        {
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i] - fee);
        }

        return dp[n - 1, 0];
    }

    public int MaxProfit1(int[] prices, int fee)
    {
        int profit1 = 0;
        int profit2 = -prices[0] - fee;
        for (int i = 1; i < prices.Length; i++)
        {
            profit1 = Math.Max(profit1, profit2 + prices[i]);
            profit2 = Math.Max(profit2, profit1 - prices[i] - fee);
        }

        return profit1;
    }


    public int MaxProfit2(int[] prices, int fee)
    {
        int buy = -prices[0]; // 买入股票的最大利润
        int sell = 0; // 卖出股票的最大利润

        for (int i = 1; i < prices.Length; i++)
        {
            int prevBuy = buy;
            buy = Math.Max(buy, sell - prices[i]); // 更新买入股票的最大利润
            sell = Math.Max(sell, prevBuy + prices[i] - fee); // 更新卖出股票的最大利润
        }

        return sell;
    }


    public static void Test()
    {
        int[] prices = { 1, 3, 2, 8, 4, 9 };

        var maxProfit = new _714_MaxProfit().MaxProfit(prices, 2);
        var maxProfit1 = new _714_MaxProfit().MaxProfit1(prices, 2);
        var maxProfit2 = new _714_MaxProfit().MaxProfit2(prices, 2);
        Console.WriteLine(maxProfit);
        Console.WriteLine(maxProfit1);
        Console.WriteLine(maxProfit2);
    }
}