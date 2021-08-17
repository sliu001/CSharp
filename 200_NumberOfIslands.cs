/*
LC200
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
Method1: DFS recursive + mark 1 to 0 if visited.
Method2: DFS recursive + "boolean visited[][] = new boolean[n][m];" to record if dot has been visited.
Method3: DFS iterative -> using Stack<Tuple<int,int>> or Queue to push surrounding 4 points, + mark 1 to 0 if visited
Method4: Union-Find. Need to create a seperate "class UF with Union()/Find()/.Count", and convert 2 dimensional indecies to 1 dimension index, and union.
https://leetcode.com/problems/number-of-islands/discuss/56364/Java-Union-Find-Solution
*/

public class Solution {
    public int NumIslands(char[][] grid) {
        int result = 0;

        for (var i=0; i<grid.Length; i++)
        {
            for (var j=0; j<grid[0].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    result++;
                    dfs(grid, i, j);
                }
            }
        }

        return result;
    }

    public void dfs(char[][] board, int i, int j)
    {
        if (i<0 || j<0 || i>=board.Length || j>=board[0].Length || board[i][j]=='0')
            return

        board[i][j] = '0';
        dfs(board, i-1, j);
        dfs(board, i, j-1);
        dfs(board, i+1, j);
        dfs(board, i, j+1);       
    }
}
