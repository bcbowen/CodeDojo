using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class ValueSetEventArgs : EventArgs
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public int Value { get; private set; }
        public ValueSetEventArgs(int row, int column, int value) 
        {
            Row = row; 
            Column = column;
            Value = value;
        }
    }
}
