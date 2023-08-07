namespace DataStructure.Algo.DP;

public class _97_IsInterleave
{
    //转为二维数组路径问题
    public bool IsInterleave(string s1, string s2, string s3)
    {
        int m = s1.Length;
        int n = s2.Length;

        //dp[i,j] 表示s1的前i个字符 和s2的前j个字符 是否存在s3的i+j 交错字符
        bool[,]dp = new bool[m+1,n+1];
        dp[0, 0] = true;//s1 s2的前0个字符和s3的前0个字符存在交替
        for (int i = 1; i <=m; i++)
        {//如果第一列的字符和s3相等 
            if (s1[i-1]==s3[i-1])
            {
                dp[i, 0] = true;
            }
            else
                break;
        }

        for (int i = 1; i <=n; i++)
        {
            if (s2[i - 1] == s3[i - 1])
            {
                dp[0, i] = true;
            }else
                break;
        }

        for (int i = 1; i <=m; i++)
        {
            for (int j = 1; j <=n; j++)
            {
                int k = j + i;
                var s1ISs3 = s1[i - 1] == s3[k - 1] && dp[i - 1, j];
                var s2ISs3 = s2[j - 1] == s3[k - 1] && dp[i, j - 1];
                dp[i, j] = s1ISs3 || s2ISs3;
            }
        }

        return dp[m, n];
    }

    public static void Test()
    {
        string s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac";
        var isInterleave = new _97_IsInterleave().IsInterleave(s1,s2,s3);
        Console.WriteLine(isInterleave);
    }
}