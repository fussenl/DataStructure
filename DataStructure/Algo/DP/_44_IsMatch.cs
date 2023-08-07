namespace DataStructure.Algo.DP;

public class _44_IsMatch
{
    public bool IsMatch(string s, string p)
    {
        int m = s.Length;
        int n = p.Length;

        // dp[i,j] 表示 s的前i p的前j 是否匹配
        bool[,] dp = new bool[m + 1, n + 1];
        dp[0, 0] = true;
        for (int i = 1; i <= n; i++)
        { // 初始化 dp[0, i]，表示空字符串与模式 p 的匹配情况
            if (dp[0, i - 1] && p[i - 1] == '*')
                dp[0, i] = true;
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (s[i - 1] == p[j - 1] || p[j - 1] == '?')
                {// 当 s[i-1] 与 p[j-1] 相等，或者 p[j-1] 是通配符 '?' 时，dp[i, j] 的值与 dp[i-1, j-1] 相同
                    dp[i, j] = dp[i - 1, j - 1];
                }else if (p[j - 1] == '*')
                { // 当 p[j-1] 是通配符 '*' 时，dp[i, j] 的值可以通过 dp[i-1, j] 或 dp[i, j-1] 推导得到
                    dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
                }
            }
        }

        return dp[m, n];
    }

    public static void Test()
    {
        string s = "aa", p = "a";
        var isMatch = new _44_IsMatch().IsMatch(s,p);
        Console.WriteLine(isMatch);
    }
}