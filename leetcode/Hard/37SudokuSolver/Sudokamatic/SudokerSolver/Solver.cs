using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokerSolver
{
    public class Solver
    {
        public SudokuBoard Board { get; private set; }

        public void Solve(SudokuBoard board)
        {
            Board = board;

            bool isSolved = false;

            Board.Filter();
            isSolved = Board.CheckSudokuBoard();

            if (!isSolved) Board.Eliminate();

            isSolved = Board.CheckSudokuBoard();

            //Console.Write($"Solved after {reps} reps"); 
        }



        /// <summary>
        /// Find a cell with the minumum possible values (most likely 2) and test each possibility with the cascading effects. One choice will be right and we'll keep that, 
        /// we discard bad choices. 
        /// 
        /// 
        /// TODO: We need to move filter, eliminate, and this one to the board object. We don't want them to belong to the solver since at this point the solver 
        /// needs to work with mutliple possible boards. 
        /// </summary>
        internal void PickAndGrin()
        {
            Stack<SudokuBoard> boardStack = new Stack<SudokuBoard>();
            (int y, int x) minCell;
            int minCount;
            while (!Board.CheckSudokuBoard())
            {
                minCount = 11;
                minCell = (0, 0);
                // find candidate with min possible values
                for (int y = 0; y < 9; y++)
                {
                    List<SudokuCell> row = Board.Board[y];
                    for (int x = 0; x < 9; x++)
                    {
                        SudokuCell cell = row[x];
                        if (cell.PossibleValues.Count < minCount)
                        {
                            minCell = (y, x);
                        }
                    }
                }

                foreach (int val in Board.Board[minCell.y][minCell.x].PossibleValues)
                {
                    SudokuBoard newBoard = Board.Clone() as SudokuBoard;
                    newBoard.Board[minCell.y][minCell.x].Value = val;
                    newBoard.FilterCell(minCell.y, minCell.x);
                    boardStack.Push(newBoard);
                }
            }
        }
    }
}
