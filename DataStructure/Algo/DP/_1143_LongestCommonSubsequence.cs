namespace DataStructure.Algo.DP;

public class _1143_LongestCommonSubsequence
{
    public int LongestCommonSubsequence1(string text1, string text2)
    {
        int m = text1.Length;
        int n = text2.Length;

        int[,] dp = new int[m + 1, n + 1];

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (text1[i - 1] == text2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[m, n];
    }

    //优化
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int m = text1.Length;
        int n = text2.Length;
        if (m < n) return LongestCommonSubsequence(text2, text1);

        int[] dp = new int[n + 1];
        for (int i = 1; i <= m; i++)
        {
            int prevNum = 0;
            int prevNewNum = 0;
            for (int j = 1; j <= n; j++)
            {
                prevNewNum = prevNum;
                prevNum = dp[j];
                if (text1[i - 1] == text2[j - 1])
                {
                    dp[j] = 1 + prevNewNum;
                }
                else
                {
                    dp[j] = Math.Max(prevNum, dp[j - 1]);
                }
            }
        }

        return dp[n];
    }


    public static void Test()
    {
        string text1 = "abc", text2 = "abc";
        var longestCommonSubsequence = new _1143_LongestCommonSubsequence().LongestCommonSubsequence(text1, text2);
        Console.WriteLine(longestCommonSubsequence);
    }
}