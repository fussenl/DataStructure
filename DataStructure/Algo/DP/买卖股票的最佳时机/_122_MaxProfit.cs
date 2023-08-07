namespace DataStructure.Algo.DP.买卖股票的最佳时机;

public class _122_MaxProfit
{
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        int[,] dp = new int[n, 2];
        dp[0, 0] = 0;
        dp[0, 1] = -prices[0];
        for (int i = 1; i < n; i++)
        {
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]); //和 121 区别是 k为无限大 k-1不会是0
        }

        return dp[n - 1, 0];
    }

    public int MaxProfit1(int[] prices)
    {
        int profit1 = 0;
        int profit2 = -prices[0];
        for (int i = 1; i < prices.Length; i++)
        {
            profit1 = Math.Max(profit1, profit2 + prices[i]);
            profit2 = Math.Max(profit2, profit1 - prices[i]);
        }

        return profit1;
    }


    //贪心算法
    //只要上涨我们就买卖
    public int MaxProfit2(int[] prices)
    {
        int maxProfit = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] > prices[i - 1])
            {
                maxProfit += prices[i] - prices[i - 1];
            }
        }

        return maxProfit;
    }

    public static void Test()
    {
        int[] prices = { 7, 1, 5, 3, 6, 4 };

        var maxProfit = new _122_MaxProfit().MaxProfit(prices);
        var maxProfit1 = new _122_MaxProfit().MaxProfit1(prices);
        var maxProfit2 = new _122_MaxProfit().MaxProfit2(prices);
        Console.WriteLine(maxProfit);
        Console.WriteLine(maxProfit1);
        Console.WriteLine(maxProfit2);
    }
}