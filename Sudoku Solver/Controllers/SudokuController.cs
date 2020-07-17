using Sudoku_Solver.Classes;
using Sudoku_Solver.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sudoku_Solver.Controllers
{
    public class SudokuController : Controller
    {
        private SudokuSolver solver = new SudokuSolver();

        public ActionResult Index()
        {
            var sudoku = new SudokuModel();
            return View(sudoku);
        }

        [HttpPost]
        public ActionResult Index(SudokuModel model)
        {
            TempData["sudoku"] = model;
            return RedirectToAction("Solve");
        }

        public ActionResult Solve()
        {
            if (TempData["sudoku"] != null)
            {
                SudokuModel sudoku = (SudokuModel)TempData["sudoku"];
                TempData.Remove("sudoku");

                if (solver.AttemptSolve(sudoku.board))
                {
                    return View(sudoku);
                }
                {
                    return RedirectToAction("Unsolvable");
                }
            }

            return View();
        }

        public ActionResult Generate()
        {
            var sudoku = new SudokuModel();
            var generator = new SudokuGenerator();

            sudoku.board = generator.board;

            return View(sudoku);
        }

        [HttpPost]
        public ActionResult Generate(SudokuModel model)
        {
            TempData["sudoku"] = model;
            return RedirectToAction("Solve");
        }

        public ActionResult Unsolvable()
        {
            return View();
        }
    }
}