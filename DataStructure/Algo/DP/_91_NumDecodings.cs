namespace DataStructure.Algo.DP;

public class _91_NumDecodings
{
    public int NumDecodings(string s)
    {
        int n = s.Length;
        //dp[i]：表示以第 i 个字符开头的子串能解码的个数
        int[] dp = new int[n + 1];
        dp[n] = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            if (s[i] != '0')
            {
                dp[i] += dp[i + 1];
                if (i < n - 1)
                {
                    int one = s[i + 1] - '0';
                    int ten = (s[i] - '0') * 10;
                    if (one + ten <= 26)
                    {
                        dp[i] += dp[i + 2];
                    }
                }
            }
        }
        return dp[0];
    }

    public static void Test()
    {
        string s = "12";
        var numDecodings = new _91_NumDecodings().NumDecodings(s);
        Console.WriteLine(numDecodings);
    }
}