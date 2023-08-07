namespace DataStructure.Algo.DP.买卖股票的最佳时机;

public class _123_MaxProfit
{
   // dp[i][0][0] = 0
   // dp[i][1][0] = max(dp[i - 1][1][0], dp[i - 1][1][1] + prices[i])
   // dp[i][1][1] = max(dp[i - 1][1][1], dp[i - 1][0][0] - prices[i])
   // dp[i][2][0] = max(dp[i - 1][2][0], dp[i - 1][2][1] + prices[i])
   // dp[i][2][1] = max(dp[i - 1][2][1], dp[i - 1][1][0] - prices[i])
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        int[,,] dp = new int[n, 3, 2];//第n天 第几次交易 是否持有股票
        //初始化 
        dp[0, 1, 0] = 0;
        dp[0, 1, 1] = -prices[0];//第0天第一次交易持有股票的最大利润
        dp[0, 2, 0] = 0;
        dp[0, 2, 1] = -prices[0];

        for (int i = 1; i < prices.Length; i++)
        {
            //看121题解释 这题最多两笔交易 多初始化了一个数组 3 表示 012 两次交易
            dp[i, 1, 0] = Math.Max(dp[i - 1, 1, 0], dp[i - 1, 1, 1] + prices[i]);
            dp[i, 1, 1] = Math.Max(dp[i - 1, 1, 1], dp[i - 1, 0, 0] - prices[i]);
            dp[i, 2, 0] = Math.Max(dp[i - 1, 2, 0], dp[i - 1, 2, 1] + prices[i]);
            dp[i, 2, 1] = Math.Max(dp[i - 1, 2, 1], dp[i - 1, 1, 0] - prices[i]);
        }

        return dp[n - 1, 2, 0];
    }

    public int MaxProfit1(int[] prices)
    {
        int n = prices.Length;
       
        //初始化 
       int profit1 = 0;
       int profit12 = -prices[0];//第0天第一次交易持有股票的最大利润
       int profit3 = 0;
       int profit34 = -prices[0];

        for (int i = 1; i < prices.Length; i++)
        {
            //看121题解释 这题最多两笔交易 多初始化了一个数组 3 表示 012 两次交易
           profit1 = Math.Max(profit1, profit12 + prices[i]);
           profit12 = Math.Max(profit12,- prices[i]);
           profit3 = Math.Max(profit3, profit34 + prices[i]);
           profit34 = Math.Max(profit34, profit1 - prices[i]);
        }

        return profit3;
    }

    public int MaxProfit2(int[] prices) {
        int buy1 = int.MaxValue; // 第一次买入的最低价格
        int sell1 = 0; // 第一次卖出的最大利润
        int buy2 = int.MaxValue; // 第二次买入的最低价格
        int sell2 = 0; // 第二次卖出的最大利润
    
        for (int i = 0; i < prices.Length; i++) {
            buy1 = Math.Min(buy1, prices[i]); // 更新第一次买入的最低价格
            sell1 = Math.Max(sell1, prices[i] - buy1); // 更新第一次卖出的最大利润
            buy2 = Math.Min(buy2, prices[i] - sell1); // 更新第二次买入的最低价格
            sell2 = Math.Max(sell2, prices[i] - buy2); // 更新第二次卖出的最大利润
        }
    
        return sell2;
    }

    
    public static void Test()
    {
        int[] prices = { 3, 3, 5, 0, 0, 3, 1, 4 };
        var maxProfit = new _123_MaxProfit().MaxProfit(prices);
        var maxProfit1 = new _123_MaxProfit().MaxProfit1(prices);
        var maxProfit2 = new _123_MaxProfit().MaxProfit2(prices);
        Console.WriteLine(maxProfit);
        Console.WriteLine(maxProfit1);
        Console.WriteLine(maxProfit2);
    }
}