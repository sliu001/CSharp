/*
LC200
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
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
