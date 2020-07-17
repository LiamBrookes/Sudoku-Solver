using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Sudoku_Solver.Models
{
    public class SudokuModel
    {
        [Range(0, 9, ErrorMessage = "Error")]
        public List<int> board { get; set; } = new List<int>();

        public SudokuModel()
        {
            for(int i = 0; i < 81; i++)
            {
                board.Add(0);
            }
        }
    }
}