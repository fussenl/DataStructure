namespace DataStructure.Algo.DP.背包问题;

public class _474_FindMaxForm
{
    //二维背包问题
    //物品是字符串数组的字符串 选择每个字符串有两个代价
    //分别为0的个数和1的个数
    //两个选择都有最大值  m  n
    //求选择字符串得到的最大子集的大小
    public int FindMaxForm(string[] strs, int m, int n)
    {
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 0; i < strs.Length; i++)
        {
            int[] count = countzeroesones(strs[i]);
            int zeroes = count[0], ones = count[1];
            for (int zero = m; zero >=zeroes; zero--)
            {
                for (int one = n; one >= ones; one--)
                {
                    dp[zero, one] = Math.Max(
                        dp[zero, one], dp[zero - zeroes, one - ones] + 1);
                }
            }
        }

        return dp[m, n];
    }

    private int[] countzeroesones(string str)
    {
        int[] c = new int[2];
        for (int i = 0; i < str.Length; i++)
        {
            c[str[i] - '0']++;
        }

        return c;
    }

    public static void Test()
    {
        string[] strs = { "10", "0001", "111001", "1", "0" };
        int m = 5, n = 3;
        var findMaxForm = new _474_FindMaxForm().FindMaxForm(strs, m, n);
        Console.WriteLine(findMaxForm);
    }
}