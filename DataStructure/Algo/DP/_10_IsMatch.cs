namespace DataStructure.Algo.DP;

public class _10_IsMatch
{
    public bool IsMatch(string s, string p)
    {
        int m = s.Length;
        int n = p.Length;

        bool[,] dp = new bool[m + 1, n + 1];
        dp[0, 0] = true;
        for (int i = 1; i <= n; i++)
        {
            if (p[i - 1] == '*')
            {//* 表示前面的字符出现0次或者多次 可以忽略 p[i-1]
                dp[0, i] = dp[0, i - 2];
            }
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] != '*')
                {//如果j-1不是 *且 j-1 和 i-1 相等 或者能用 . 匹配
                    if (p[j - 1] == s[i - 1] || p[j - 1] == '.')
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                }
                else
                {
                    if (p[j - 2] != s[i - 1] && p[j - 2] != '.')
                    {//如果 p的j前2 个位置不等   则无法匹配  说明 j前位置的为空
                        dp[i, j] = dp[i, j - 2];
                    }
                    else
                    {
                        dp[i, j] = dp[i, j - 2] || dp[i - 1, j];
                    }
                }
            }
        }

        return dp[m, n];
    }

    public static void Test()
    {
        string s = "aab", p = "c*a.b";
        var isMatch = new _10_IsMatch().IsMatch(s, p);
        Console.WriteLine(isMatch);
    }
}