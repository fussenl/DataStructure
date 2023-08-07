namespace DataStructure.Algo.Backtrack;

public class _140_WordBreak
{
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        return dfs(s, new HashSet<string>(wordDict), 0);
    }

    private IList<string> dfs(string s, HashSet<string> wordDic, int index)
    {
        List<string> res = new List<string>();
        if (index == s.Length)
        {
            res.Add("");
            return res;
        }

        for (int i = index + 1; i <= s.Length; i++)
        {
            string word = s.Substring(index, i - index);
            if (!wordDic.Contains(word)) continue;
            IList<string> list = dfs(s, wordDic, i);
            foreach (var l in list)
            {
                res.Add(word + (l.Equals("") ? "" : " ") + l);
            }
        }

        return res;
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