namespace DataStructure.Algo.DP;

public class _140_WordBreak
{
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        int n = s.Length;
        //dp[i] 表示s的前i字符能构成的句子
        var dp = new List<string>[n + 1];

        dp[0] = new List<string>(){""};

        for (int i = 1; i <=n; i++)
        {
            dp[i] = new List<string>();
            for (int j = 0; j < i; j++)
            {
                var word = s.Substring(j, i - j);
                if (wordDict.Contains(word))
                {
                    //遍历前j个字符 查看能构成的句子 然后和word组合添加到dp中
                    foreach (var sentence in dp[j])
                    {
                        dp[i].Add(sentence+(sentence==""?"":" ")+word);
                    }
                }
            }
        }

        return dp[n];
    }
    

    public static void Test()
    {
        string s = "catsanddog";
        IList<string> wordDict = new List<string>(){ "cat", "cats", "and", "sand", "dog" };

        var wordBreak = new _140_WordBreak().WordBreak(s,wordDict);
        foreach (var str in wordBreak)
        {
            Console.Write(str+"  ");
        }

        Console.WriteLine();
    }
}