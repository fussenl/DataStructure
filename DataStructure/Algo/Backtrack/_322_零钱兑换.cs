namespace DataStructure.Algo.Backtrack;

public class _322_零钱兑换
{
    private int minCoins = Int32.MaxValue;

    public int CoinChange(int[] coins, int amount)
    {
        var res = new List<int>();

        backtrack(amount, coins, res);

        return minCoins == Int32.MinValue ? -1 : minCoins;
    }

    private void backtrack(int amount, int[] coins, List<int> res)
    {
        if (amount == 0)
        {
            minCoins = Math.Min(minCoins, res.Count);
        }

        for (int i = 0; i < coins.Length; i++)
        {
            if (amount - coins[i] < 0) continue;
            res.Add(coins[i]);
            backtrack(amount - coins[i], coins, res);
            res.RemoveAt(res.Count - 1);
        }
    }

    public int CoinChange2(int[] coins, int amount)
    {
        return backtrack2(amount, coins);
    }

    private int backtrack2(int amount, int[] coins)
    {
        if (amount == 0) return 0;
        int minCoins = int.MaxValue;
        for (int i = 0; i < coins.Length; i++)
        {
            if (amount - coins[i] < 0) continue;
            int subMin = backtrack2(amount - coins[i], coins);
            if (subMin == -1) continue;
            minCoins = Math.Min(minCoins, subMin + 1);
        }

        return minCoins == int.MaxValue ? -1 : minCoins;
    }


    public static void Test()
    {
        var coins = new[] { 3, 5 };
        int amount = 11;

        var coinChange = new _322_零钱兑换().CoinChange2(coins, amount);
        Console.WriteLine(coinChange);
    }
}