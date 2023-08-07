namespace DataStructure.Algo.Backtrack;

public class _91_NumDecodings
{
    public int NumDecodings(string s)
    {
        int[] meno = new int[s.Length + 1];
        Array.Fill(meno, -1);
        return dfs(s, 0, meno);
    }

    private int dfs(string s, int i, int[] meno)
    {
        if (i == s.Length) return 1;
        if (s[i] == '0') return 0;
        if (meno[i] != -1) return meno[i];

        //将当前字符解码 方式1
        int res = 0;
        res += dfs(s, i + 1, meno); 

        if (i < s.Length - 1)
        {
            int one = s[i + 1] - '0';
            int ten = (s[i] - '0') * 10;
            if (one + ten <= 26)
            {//解码下一个位置字符  一个字符能解码 判断这个字符和下一个字符一起能不能解码 能就再递归下一个字符
                res += dfs(s, i + 2, meno);
            }
        }

        meno[i] = res;
        return res;
    }

    public static void Test()
    {
        string s = "12";
        var numDecodings = new _91_NumDecodings().NumDecodings(s);
        Console.WriteLine(numDecodings);
    }
}