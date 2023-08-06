using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class SudokuBoard : ICloneable
    {
        public event EventHandler<ValueSetEventArgs> ValueSet;

        protected virtual void OnValueSet(int row, int column, int value)
        {
            ValueSet?.Invoke(this, new ValueSetEventArgs(row, column, value));
        }

        public SudokuBoard()
        {
            Board = new List<List<SudokuCell>>();
        }
        public List<List<SudokuCell>> Board { get; set; }

        public int this[int y, int x] 
        {
            get
            {
                return Board[y][x].Value;
            }
        }

        public static SudokuBoard Create(char[][] board)
        {
            SudokuBoard sudokuBoard = new SudokuBoard();

            for (int i = 0; i < 9; i++)
            {
                sudokuBoard.Board.Add(new List<SudokuCell>());
                for (int j = 0; j < 9; j++)
                {
                    sudokuBoard.Board[i].Add(new SudokuCell());
                    if (board[i][j] != '.')
                    {
                        sudokuBoard.Board[i][j].Value = int.Parse(board[i][j].ToString());
                        OnValueSet(i, j, sudokuBoard.Board[i][j].Value);
                    }
                    else
                    {
                        sudokuBoard.Board[i][j].PossibleValues.AddRange(Enumerable.Range(1, 9));
                    }
                    sudokuBoard.Board.Add(new List<SudokuCell>()); 
                }
            }

            return sudokuBoard;
        }

        public static SudokuBoard Create(string board) 
        {
            char[][] chars = new char[9][];
            int row = 0; 
            string[] lines = board.Split("\r\n");
            foreach (string line in lines) 
            {
                //line = line.Replace("\n", "");
                string[] cells = line.Split(',');
                chars[row] = new char[9]; 
                for (int i = 0; i < 9; i++) 
                {
                    chars[row][i] = char.Parse(cells[i].Replace("'", "")); 
                }
                row++; 
            }
            return Create(chars); 
        }

        /// <summary>
        /// When single value is found for cell, eliminate this value for all other cells in 
        /// row, column, section. Called recursively as additional values are found.
        /// </summary>
        internal void FilterCell(int row, int col)
        {
            // get val from cell 
            int val = Board[row][col].Value;

            // remove value from columns in same row
            for (int x = 0; x < 9; x++)
            {
                if (Board[row][x].Contains(val))
                {
                    Board[row][x].Remove(val);

                    if (Board[row][x].PossibleValues.Count == 1)
                    {
                        Board[row][x].Value = Board[row][x].PossibleValues[0];
                        OnValueSet(row, x, Board[row][x].Value);
                        FilterCell(row, x);
                    }
                }
            }

            // remove value from rows in same col
            for (int y = 0; y < 9; y++)
            {
                if (Board[y][col].Contains(val))
                {
                    Board[y][col].Remove(val);
                    if (Board[y][col].PossibleValues.Count == 1)
                    {
                        Board[y][col].Value = Board[y][col].PossibleValues[0];
                        OnValueSet(y, col, Board[y][col].Value);
                        FilterCell(y, col);
                    }
                }
            }

            // remove value from same section
            Section section = Section.GetSection(row, col);
            for (int x = section.BeginColumn; x <= section.EndColumn; x++)
            {
                for (int y = section.BeginRow; y <= section.EndRow; y++)
                {
                    if (Board[y][x].Contains(val))
                    {
                        Board[y][x].Remove(val);
                        if (Board[y][x].PossibleValues.Count == 1)
                        {
                            Board[y][x].Value = Board[y][x].PossibleValues[0];
                            OnValueSet(y, x, Board[y][x].Value);
                            FilterCell(y, x);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Remove this value from cells in this row, column, and section. 
        /// Returns true if there are still cells that have multiple possibilities.
        /// </summary>
        internal void Filter()
        {
            // Filter Rows
            for (int row = 0; row < 9; row++)
            {
                FilterRange(0, 8, row, row);
            }

            // Filter Columns
            for (int col = 0; col < 9; col++)
            {
                FilterRange(col, col, 0, 8);
            }
            // Filter Sections
            for (int i = 0; i < 9; i++)
            {
                Section section = Section.SudokuSections[i];
                FilterRange(section.BeginColumn, section.EndColumn, section.BeginRow, section.EndRow);
            }
        }

        internal void FilterRange(int beginX, int endX, int beginY, int endY)
        {
            List<int> singleValues = new List<int>();
            List<(int, int)> multiIndexCells = new List<(int, int)>();
            for (int y = beginY; y <= endY; y++)
            {
                for (int x = beginX; x <= endX; x++)
                {
                    if (Board[y][x].Value < 1)
                    {
                        multiIndexCells.Add((y, x));
                    }
                    else
                    {
                        singleValues.Add(Board[y][x].Value);
                    }
                }
            }

            // filter out single values from cells with multiple possibilities
            foreach ((int row, int col) in multiIndexCells)
            {
                Board[row][col].PossibleValues.RemoveAll(l => singleValues.Contains(l));

                // if we are left with a single value, clean up the row, col, and section containing this value
                if (Board[row][col].PossibleValues.Count == 1)
                {
                    Board[row][col].Value = Board[row][col].PossibleValues[0];
                    OnValueSet(row, col, Board[row][col].Value);
                    FilterCell(row, col);
                }
            }

        }

        /// <summary>
        /// Check for values that can only be one of the cells in a row, col, or section 
        /// Ex: in a row, one cell has possible values 1, 3, 6, and no other cell in that row can be 6, we know this cell is 6 and we can eliminate the other possibilities
        /// </summary>
        internal void Eliminate()
        {
            // check each row
            for (int row = 0; row < 9; row++)
            {
                EliminateRange(0, 8, row, row);
            }
            // check each col
            for (int col = 0; col < 9; col++)
            {
                EliminateRange(col, col, 0, 8);
            }

            // check each section
            for (int i = 0; i < 9; i++)
            {
                Section section = Section.SudokuSections[i];
                EliminateRange(section.BeginColumn, section.EndColumn, section.BeginRow, section.EndRow);
            }
        }

        internal void EliminateRange(int beginX, int endX, int beginY, int endY)
        {
            // index corresponds to value 1-9, bool indicates if the Value is known
            bool[] values = new bool[10];

            // index corresponds to value, possible cells are cells in the range that could be this value
            List<List<(int, int)>> possibleCells = new List<List<(int, int)>>();

            for (int i = 0; i <= 9; i++)
            {
                possibleCells.Add(new List<(int, int)>());
            }

            for (int row = beginY; row <= endY; row++)
            {
                for (int col = beginX; col <= endX; col++)
                {
                    if (Board[row][col].Value > 0)
                    {
                        values[Board[row][col].Value] = true;
                    }
                    else
                    {
                        foreach (int val in Board[row][col].PossibleValues)
                        {
                            possibleCells[val].Add((row, col));
                        }
                    }
                }
            }


            for (int i = 0; i < possibleCells.Count; i++)
            {
                if (possibleCells[i].Count == 1)
                {
                    (int y, int x) = possibleCells[i][0];
                    Board[y][x].PossibleValues.Clear();
                    Board[y][x].PossibleValues.Add(i);
                    Board[y][x].Value = i;
                    OnValueSet(y, x, Board[y][x].Value);
                    FilterCell(y, x);
                }
            }
        }

        public bool CheckSudokuBoard()
        {
            bool result = true;
            // vertical 
            for (int col = 0; col < 9; col++)
            {
                result = result && CheckRegion(col, col, 0, 8);
                if (!result) break;
            }

            if (result)
            {
                for (int row = 0; row < 9; row++)
                {
                    result = result && CheckRegion(0, 8, row, row);
                    if (!result) break;
                }
            }

            if (result)
            {
                for (int i = 0; i < 9; i++)
                {
                    Section section = Section.SudokuSections[i];
                    result = result && CheckRegion(section.BeginColumn, section.EndColumn, section.BeginRow, section.EndRow);
                    if (!result) break;
                }
            }

            return result;
        }

        internal bool CheckRegion(int beginX, int endX, int beginY, int endY)
        {
            bool[] values;
            for (int x = beginX; x <= endX; x++)
            {
                values = new bool[10];
                for (int y = beginY; y <= endY; y++)
                {
                    if (Board[y][x].Value == 0 || values[Board[y][x].Value]) return false;
                    values[Board[y][x].Value] = true;
                }
            }
            return true;
        }

        public char[][] ToCharArray()
        {
            char[][] board = new char[9][];
            for (int i = 0; i < 9; i++)
            {
                board[i] = new char[9];
            }

            // update board
            for (int col = 0; col < 9; col++)
            {
                for (int row = 0; row < 9; row++)
                {
                    if (Board[col][row].Value > 0)
                    {
                        board[col][row] = (char)(Board[col][row].Value + '0');
                    }
                    else
                    {
                        board[col][row] = '.';
                    }
                }
            }

            return board;
        }

        public object Clone()
        {
            SudokuBoard cloned = new SudokuBoard();
            foreach (List<SudokuCell> row in Board)
            {
                List<SudokuCell> clonedRow = new List<SudokuCell>();
                foreach (SudokuCell cell in row)
                {
                    clonedRow.Add(cell);
                }
                cloned.Board.Add(clonedRow);
            }

            return cloned;
        }
    }
}
