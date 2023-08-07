namespace DataStructure.Algo.DP.背包问题;

public class _139_WordBreak
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var dict = new HashSet<string>(wordDict);// 将wordDict转换为哈希集合，以便快速查
        //dp[i]表示s的前i个字符是否可以被拆分成字典中的单词
        bool[] dp = new bool[s.Length + 1];
        
        dp[0] = true;// 空字符串可以被拆分，所以dp[0]为true

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {// 如果dp[j]为true且s的子串[j, i)在字典中存在，则dp[i]为true
                if (dp[j] && dict.Contains(s.Substring(j, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[s.Length];
    }

    public static void Test()
    {
        string s = "leetcode";
        string[] wordDict = { "leet", "code" };
        var wordBreak = new _139_WordBreak().WordBreak(s,wordDict);
        Console.WriteLine(wordBreak);
    }
}