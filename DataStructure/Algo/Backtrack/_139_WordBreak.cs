namespace DataStructure.Algo.Backtrack;

public class _139_WordBreak
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        Dictionary<int, bool> meno = new Dictionary<int, bool>();

        return dfs(s, new HashSet<string>(wordDict), 0, meno);
    }

    private bool dfs(string s, HashSet<string> wordDict, int index, Dictionary<int, bool> meno)
    {
        if (index == s.Length) return true;
        if (meno.ContainsKey(index)) return meno[index];
        for (int i = index + 1; i <= s.Length; i++)
        {
            var word = s.Substring(index, i - index);

            if (!wordDict.Contains(word)) continue;
            if (dfs(s, wordDict, i, meno))
            {
                meno[index] = true;
                return true;
            }
        }

        meno[index] = false;
        return false;
    }

    public static void Test()
    {
        string s = "leetcode";
        string[] wordDict = { "leet", "code" };
        var wordBreak = new _139_WordBreak().WordBreak(s, wordDict);
        Console.WriteLine(wordBreak);
    }
}