namespace DataStructure.Algo.DP;

public class _354_MaxEnvelopes
{
    public int MaxEnvelopes(int[][] envelopes) {
        // 对信封按照宽度进行升序排序，如果宽度相同，则按照高度进行降序排序
        Array.Sort(envelopes, (a, b) => {
            if (a[0] == b[0]) {
                return b[1] - a[1];
            }
            return a[0] - b[0];
        });
    
        int n = envelopes.Length;
        int[] dp = new int[n]; // 用于保存以当前信封结尾的最长递增子序列的长度
        int maxLen = 0; // 最长递增子序列的长度
    
        for (int i = 0; i < n; i++) {
            dp[i] = 1; // 初始化当前信封的最长递增子序列长度为1
        
            // 遍历之前的所有信封，找到高度小于当前信封的最长递增子序列长度
            for (int j = 0; j < i; j++) {
                if (envelopes[j][1] < envelopes[i][1]) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        
            maxLen = Math.Max(maxLen, dp[i]); // 更新最长递增子序列的长度
        }
    
        return maxLen;
    }

    public int MaxEnvelopes1(int[][] envelopes) {
        int n = envelopes.Length;
        if (n == 0) return 0;
    
        // 按照宽度升序排序，如果宽度相同，则按照高度降序排序
        Array.Sort(envelopes, (a, b) => {
            if (a[0] == b[0]) {
                return b[1] - a[1];
            }
            return a[0] - b[0];
        });
    
        int[] dp = new int[n];
        int len = 0;
    
        for (int i = 0; i < n; i++) {
            //使用二分查找在dp数组中找到第一个大于等于当前信封高度的位置，将该位置的值更新为当前信封高度。
            int index = Array.BinarySearch(dp, 0, len, envelopes[i][1]);
            //如果这个位置超过了当前dp数组的长度，说明当前信封高度比之前所有信封都要大，
            //将dp数组的长度加1，并将当前信封高度放入新的位置。
            if (index < 0) {
                index = -(index + 1);
            }
            dp[index] = envelopes[i][1];
            if (index == len) {
                len++;
            }
        }
    
        return len;
    }


    public static void Test()
    {
        int[][] envelopes =
        {
            new int[] { 5, 4 },
            new int[] { 6, 4 },
            new int[] { 6, 7 },
            new int[] { 2, 3 }
        };

        var maxEnvelopes = new _354_MaxEnvelopes().MaxEnvelopes1(envelopes);
        Console.WriteLine(maxEnvelopes);
    }
}