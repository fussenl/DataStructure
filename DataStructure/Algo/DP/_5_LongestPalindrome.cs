namespace DataStructure.Algo.DP;

public class _5_LongestPalindrome
{
    public string LongestPalindrome(string s)
    {
        if (s.Length == 0) return "";
        string res = s[0].ToString();
        bool[][] dp = new bool[s.Length][];
        for (int i = 0; i < s.Length; i++)
        {
            dp[i] = new bool[s.Length];
        }

        for (int i = 0; i < s.Length; i++)
        {
            dp[i][i] = true;
        }
        
        for (int j = 1; j < s.Length; j++)
        {
            for (int i = 0; i < j; i++)
            {
                bool isCharEqual = s[i] == s[j];
                if (j - i == 1)
                {
                    dp[i][j] = isCharEqual;
                }
                else
                {
                    dp[i][j] = isCharEqual && dp[i + 1][j - 1];//i+1 j-1 判断的是长度大于2的子串中间的字符是不是回文
                }

                if (dp[i][j] && j - i + 1 > res.Length)
                {
                    res=s.Substring(i, j - i + 1);
                }
            }
        }

        return res;
    }

    public static void Test()
    {
        var s = "babad";
        var longestPalindrome = new _5_LongestPalindrome().LongestPalindrome(s);
        Console.WriteLine(longestPalindrome);
    }
}