namespace DataStructure.Algo.DP;

public class _72_MinDistance
{
    public int MinDistance(string word1, string word2)
    {
        int m = word1.Length;
        int n = word2.Length;

        int[,] dp = new int[m + 1, n + 1];
        for (int i = 0; i < m; i++)
        {
            dp[i, 0] = i;
        }

        for (int i = 0; i < n; i++)
        {
            dp[0, i] = i;
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1]; //相同无操作次数,就是前一个位置的操作次数
                }
                else
                {
                    int insert = dp[i, j - 1] + 1;// 删除和插入要么是在当前元素前插要么删 所以就是i-1 j-1
                    int delete = dp[i - 1, j] + 1;//如 abc ac 删除和插入同理
                    int replace = dp[i - 1, j - 1] + 1;//如 AB AC 替换都是前一个元素操作+1

                    dp[i, j] = Math.Min(insert, Math.Min(delete, replace));//三个操作找出 最少步骤的
                }
            }
        }

        return dp[m, n];
    }

    public static void Test()
    {
        string word1 = "", word2 = "a";
        var minDistance = new _72_MinDistance().MinDistance(word1, word2);
        Console.WriteLine(minDistance);
    }
}