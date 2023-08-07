using DataStructure.Algo.Backtrack;

namespace DataStructure.Algo.DP;

public class _131_Partition
{
    public IList<IList<string>> Partition(string s)
    {
        var res = new List<IList<string>>();
        var path = new List<string>();
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
                    dp[i][j] = isCharEqual && dp[i + 1][j - 1];
                }
            }
        }

        dfs(s, 0, path, res, dp);
        return res;
    }

    private void dfs(string s, int start, List<string> path, List<IList<string>> res, bool[][] dp)
    {
        if (start == s.Length)
        {
            res.Add(new List<string>(path));
            return;
        }

        for (int i = start; i < s.Length; i++)
        {
            if (!dp[start][i]) continue; //剪枝 如果当前不是回文串 就跳过
            path.Add(s.Substring(start, i - start + 1));
            dfs(s, i + 1, path, res, dp);
            path.RemoveAt(path.Count - 1);
        }
    }

    public static void Test()
    {
        var partition = new _131_Partition().Partition("aab");
        foreach (var p in partition)
        {
            foreach (var s in p)
            {
                Console.Write(s);
            }

            Console.WriteLine();
        }
    }
}