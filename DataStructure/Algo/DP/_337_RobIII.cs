namespace DataStructure.Algo.DP;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class _337_RobIII
{
    public int Rob(TreeNode root)
    {
        var res = dfs(root);
        return Math.Max(res[0], res[1]);
    }

    private int[] dfs(TreeNode node)
    {
        if (node == null) return new int[2];

        int[] left = dfs(node.left);
        int[] right = dfs(node.right);

        var res = new int[2]; //第一个元素代表不偷 第二个代表偷
        // 1. 选择不偷当前的节点，当前节点能偷到的最大钱数
        //          = 左孩子能偷到的最大钱 + 右孩子能偷到的最大钱
        res[0] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
        // 2. 选择偷当前的节点：当前节点能偷到的最大钱数
        //              = 左孩子选择自己不偷时能得到的最大钱 +
        //                  右孩子选择不偷时能得到的最大钱 + 当前节点的钱数
        res[1] = left[0] + right[0] + node.val;
        return res;
    }

    public static void Test()
    {
        var root = new TreeNode(3);
        root.left = new TreeNode(4);
        root.left.left = new TreeNode(1);
        root.left.right = new TreeNode(3);

        root.right = new TreeNode(5);
        root.right.right = new TreeNode(1);

        var rob = new _337_RobIII().Rob(root);
        Console.WriteLine(rob);
    }
}