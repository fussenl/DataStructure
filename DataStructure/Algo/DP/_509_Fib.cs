namespace DataStructure.Algo.DP;

public class _509_Fib
{
    //动态规划  自底而上的思路
    public int Fib(int n)
    {
        if (n <= 1) return n;

        int[] dp = new int[n + 1];//1.定义状态数组 dp[i] 表示状态值

        dp[0] = 0;
        dp[1] = 1;//状态初始化

        for (int i = 2; i <=n ; i++)
        {//转移状态 可以根据状态转移方程
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }
    
    // 优化: 状态空间压缩 
    public int Fib3(int n)
    {
        if (n <= 1) return n;

       

        var prev = 0;
        var curr = 1;//状态初始化

        for (int i = 2; i <=n ; i++)
        {
            int sum = prev + curr;
            prev = curr;
            curr = sum;
        }

        return curr;
    }

    
    //递归
    public int Fib1(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        return Fib1(n - 1) + Fib1(n - 2);
    }

    private Dictionary<int, int> map = new();
    public int Fib2(int n)
    {
        return dfs(n);
    }

    private int dfs(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        if (map.TryGetValue(n, out var dfs1))
        {
            return dfs1;
        }
        int left = dfs(n - 1);
        int right = dfs(n - 2);
        map.Add(n, left + right);
        return left + right;
    }

    public static void Test()
    {
        var fib = new _509_Fib().Fib3(3);
        Console.WriteLine(fib);
    }
}