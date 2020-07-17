using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sudoku_Solver.Classes
{
    public class SudokuGenerator
    {
        private Random rnd = new Random();
        public List<int> board { get; private set; } = new List<int>();

        public SudokuGenerator()
        {
            for (int i = 0; i < 81; i++)
            {
                board.Add(0);
            }

            for (int row = 0, col = 0; row < 9 && col < 9; row += 3, col += 3)
            {
                List<int> randomValues = GetShuffledValues();
                generateSection(row, col, randomValues);
            }
        }

        private List<int> GetShuffledValues()
        {
            List<int> shuffledList = new List<int>();
            List<int> values = new List<int>();

            for (int i = 1; i < 10; i++)
            {
                values.Add(i);
            }

            while (values.Count > 0)
            {
                int num = rnd.Next(1, 10);

                for (int i = 0; i < values.Count; i++)
                {
                    if (num == values[i])
                    {
                        values.RemoveAt(i);
                        shuffledList.Add(num);
                    }
                }
            }

            return shuffledList;
        }

        private void generateSection(int row, int col, List<int> values)
        {
            int index = 0;

            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    board[i * 9 + j] = values[index];
                    index++;
                }
            }
        }
    }
}