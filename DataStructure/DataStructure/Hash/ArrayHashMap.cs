namespace DataStructure.DataStructure.Hash;

/* 键值对 int->string */
public class Pair
{
    public int key;
    public string val;

    public Pair(int key, string val)
    {
        this.key = key;
        this.val = val;
    }
}

/* 基于数组简易实现的哈希表 */
public class ArrayHashMap
{
    private List<Pair?> buckets;

    public ArrayHashMap()
    {
        // 初始化数组，包含 100 个桶
        buckets = new();
        for (int i = 0; i < 100; i++)
        {
            buckets.Add(null);
        }
    }

    /* 哈希函数 */
    private int hashFunc(int key)
    {
        int index = key % 100;
        return index;
    }

    /// <summary>
    /// 查询操作
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string? get(int key)
    {
        int index = hashFunc(key);
        Pair? pair = buckets[index];
        if (pair == null) return null;
        return pair.val;
    }

    /// <summary>
    /// 添加操作
    /// </summary>
    /// <param name="key"></param>
    /// <param name="val"></param>
    public void put(int key, string val)
    {
        Pair pair = new Pair(key, val);
        int index = hashFunc(key);
        buckets[index] = pair;
    }

    /// <summary>
    /// 删除操作
    /// </summary>
    /// <param name="key"></param>
    public void remove(int key)
    {
        int index = hashFunc(key);
        // 置为 null ，代表删除
        buckets[index] = null;
    }


    /// <summary>
    /// 获取所有键值对
    /// </summary>
    /// <returns></returns>
    public List<Pair> pairSet()
    {
        List<Pair> pairSet = new();
        foreach (Pair? pair in buckets)
        {
            if (pair != null)
                pairSet.Add(pair);
        }

        return pairSet;
    }

    /// <summary>
    /// 获取所有键
    /// </summary>
    /// <returns></returns>
    public List<int> keySet()
    {
        List<int> keySet = new();
        foreach (Pair? pair in buckets)
        {
            if (pair != null)
                keySet.Add(pair.key);
        }

        return keySet;
    }

    /// <summary>
    /// 获取所有值
    /// </summary>
    /// <returns></returns>
    public List<string> valueSet()
    {
        List<string> valueSet = new();
        foreach (Pair? pair in buckets)
        {
            if (pair != null)
                valueSet.Add(pair.val);
        }

        return valueSet;
    }


    public void print()
    {
        foreach (Pair kv in pairSet())
        {
            Console.WriteLine(kv.key + " -> " + kv.val);
        }
    }

    public static void Test()
    {
        ArrayHashMap map = new();
        map.put(1, "mac");
        map.put(2, "苹果");
        map.put(3, "安卓");
        map.put(4, "Windows");
        map.print();
        map.remove(2);
        Console.WriteLine(map.get(3));

        map.valueSet().ForEach(Console.WriteLine);
        map.pairSet().ForEach(kv => Console.WriteLine(kv.key + "->" + kv.val));
    }
}