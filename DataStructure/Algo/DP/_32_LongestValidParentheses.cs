namespace DataStructure.Algo.DP;

public class _32_LongestValidParentheses
{
    //动态规划
    public int LongestValidParentheses(string s) {
        int n = s.Length;
        int[] dp = new int[n]; // 创建长度为n的dp数组，用于存储以每个字符结尾的最长有效括号子串的长度
        int maxLen = 0; // 最长有效括号子串的长度
    
        //一对符号长度是2
        for (int i = 1; i < n; i++) {
            if (s[i] == ')') { // 当前字符为')'
                if (s[i - 1] == '(') { // 前一个字符为'('，可以形成一个有效括号子串
                    dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2; // 更新当前字符的最长有效括号子串长度
                } else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(') {
                    // 前一个字符为')'，需要判断前一个字符的最长有效括号子串的前一个字符是否为'('，如果是，则可以形成一个有效括号子串
                    // 更新当前字符的最长有效括号子串长度
                    dp[i] = dp[i - 1] + 2 + (i - dp[i - 1] >= 2 ? dp[i - dp[i - 1] - 2] : 0);
                }
            
                maxLen = Math.Max(maxLen, dp[i]); // 更新最长有效括号子串的长度
            }
        }
    
        return maxLen; // 返回最长有效括号子串的长度
    }


    //暴力解法
    public int LongestValidParentheses1(string s)
    {
        int maxLen = 0;
        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (isValid(s.Substring(j, i - j)))
                {
                    maxLen = Math.Max(maxLen, i - j);
                }
            }
        }

        return maxLen;
    }

    public bool isValid(string s)
    {
        if (s.Length % 2 == 1) return false;
        var stack = new Stack<char>();
        foreach (var c in s.ToCharArray())
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                stack.Pop();
            }
        }

        return stack.Count == 0;
    }

    public static void Test()
    {
        string s = ")()())";
        var i = new _32_LongestValidParentheses().LongestValidParentheses(s);
        Console.WriteLine(i);
    }
}