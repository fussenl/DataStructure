namespace DataStructure.Algo.Backtrack;

public class _64_MinPathSum
{
    //int minPathSum = int.MaxValue;
    int[][] dirs = { new int[] { 1, 0 }, new int[] { 0, 1 } };

    public int MinPathSum(int[][] grid)
    {
        //backtrack(grid, 0, 0, grid[0][0]);

        int[][] map = new int[grid.Length][];
        for (int i = 0; i < grid.Length; i++)
        {
            map[i] = new int[grid[0].Length];
            Array.Fill(map[i], int.MaxValue);
        }

        return backtrack(grid, 0, 0, grid[0][0], map);
    }

    private int backtrack(int[][] grid, int row, int col, int sum, int[][] map)
    {
        if (row == grid.Length - 1 && col == grid[0].Length - 1)
        {
            //minPathSum = Math.Min(minPathSum, sum);
            return grid[row][col];
        }

        if (map[row][col] != int.MaxValue)
        {
            return map[row][col];
        }

        int minPathSum = int.MaxValue;
        foreach (var dir in dirs)
        {
            int nextRow = row + dir[0];
            int nextCol = col + dir[1];
            if (nextRow < 0 || nextCol < 0 || nextRow >= grid.Length || nextCol >= grid[0].Length) continue;
            //sum += grid[nextRow][nextCol];
            int min = backtrack(grid, nextRow, nextCol, sum, map);
            //sum -= grid[nextRow][nextCol];
            minPathSum = Math.Min(minPathSum, min);
        }

        map[row][col] = minPathSum + grid[row][col];
        return map[row][col];
    }

    public static void Test()
    {
        int[][] grid =
        {
            new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 }
        };
        var pathSum = new _64_MinPathSum().MinPathSum(grid);
        Console.WriteLine(pathSum);
    }
}