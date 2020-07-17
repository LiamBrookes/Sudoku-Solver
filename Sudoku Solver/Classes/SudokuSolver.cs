using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sudoku_Solver.Classes
{
    public class SudokuSolver
    {
        // Maps the 2D row index onto the 1D array
        private int GetCurrentRow(int index)
        {
            return index * 9;
        }

        public bool AttemptSolve(List<int> board)
        {
            for(int i = 0; i < board.Count; i++)
            {
                if(board[i] < 0 || board[i] > 9)
                {
                    return false;
                }
            }

            // Recursively call solve until result is found
            if (Solve(board))
            {
                return true;
            }

            return false;
        }

        private bool Solve(List<int> board)
        {
            int find = FindEmpty(board);

            if (find == -1)
                return true;

            int row = find / 9;
            int col = find - (row * 9);

            for (int i = 1; i < 10; i++)
            {
                if (IsValid(board, row, col, i))
                {
                    board[find] = i;

                    if (Solve(board))
                        return true;

                    board[find] = 0;
                }
            }

            return false;
        }

        private int FindEmpty(List<int> board)
        {
            // Find the firts empty position in the board
            for (int i = 0; i < 9; i++)
            {
                int row = GetCurrentRow(i);
                for (int j = row; j < row + 9; j++)
                {
                    if (board[j] == 0)
                    {
                        return j;
                    }
                }
            }

            // No empty positions left return -1
            return -1;
        }

        private bool IsValid(List<int> board, int row, int col, int num)
        {
            // Check to see if the number fits in the row and column
            if (CheckRow(board, row, num) && CheckColumn(board, col, num))
            {
                // Check if the number fits in the (3x3) section
                if (CheckBoardSection(board, row, col, num))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckRow(List<int> board, int row, int num)
        {
            int currentRow = GetCurrentRow(row);

            for (int i = currentRow; i < currentRow + 9; i++)
            {
                if (board[i] == num)
                    return false;
            }

            return true;
        }

        private bool CheckColumn(List<int> board, int col, int num)
        {
            for (int i = col; i < board.Count; i += 9)
            {
                if (board[i] == num)
                    return false;
            }

            return true;
        }

        private bool CheckBoardSection(List<int> board, int row, int col, int num)
        {
            int sectionSize = 3;

            // Get the start index for the row and column
            int rowSecIndex = (row / sectionSize) * sectionSize;
            int colSecIndex = (col / sectionSize) * sectionSize;

            int startRow = GetCurrentRow(rowSecIndex);
            int endRow = GetCurrentRow(rowSecIndex + 2);

            for (int i = startRow; i <= endRow; i += 9)
            {
                for (int j = colSecIndex; j < colSecIndex + 3; j++)
                {
                    if (board[i + j] == num)
                        return false;
                }
            }

            return true;
        }
    }
}