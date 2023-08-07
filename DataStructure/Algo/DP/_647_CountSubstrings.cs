using System.Text;

namespace DataStructure.Algo.DP;

public class _647_CountSubstrings
{
    #region 动态规划

    public int CountSubstrings(string s)
    {
        if (s.Length == 0) return 0;
        //定义状态，dp[i][j] 表示子数组区间 [i, j] 对应的子串是否是回文
        bool[][] dp = new bool[s.Length][];
        for (int i = 0; i < s.Length; i++)
        {
            dp[i] = new bool[s.Length];
        }

        int res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            dp[i][i] = true;
            res++;
        }

        for (int j = 1; j < s.Length; j++)
        {
            for (int i = 0; i < j; i++)
            {
                bool isPalindRome = s[i] == s[j];
                if (i - 1 == j)
                {
                    dp[i][j] = isPalindRome;
                }
                else
                {
                    dp[i][j] = isPalindRome && dp[i + 1][j - 1];
                }

                if (dp[i][j]) res++;
            }
        }

        return res;
    }

    #endregion

    #region 暴力解法

    public int CountSubstrings1(string s)
    {
        if (s.Length == 0) return 0;
        int res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                string str = s.Substring(i, j - i + 1);
                if (isPalindrome(str)) res++;
            }
        }

        return res;
    }

    public bool isPalindrome(string s)
    {
        int i = 0, j = s.Length - 1;
        while (i < j)
        {
            if (s[i] != s[j])
            {
                return false;
            }

            i++;
            j--;
        }

        return true;
    }

    #endregion

    

    public static void Test()
    {
        string s = "abc";
        var countSubstrings1 = new _647_CountSubstrings().CountSubstrings(s);
        Console.WriteLine(countSubstrings1);
    }
}