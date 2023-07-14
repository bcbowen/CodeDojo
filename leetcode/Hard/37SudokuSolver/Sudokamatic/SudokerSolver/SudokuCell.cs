using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokerSolver
{
    public class SudokuCell : ICloneable
    {
        public SudokuCell()
        {
            PossibleValues = new List<int>();
        }

        public int Value { get; set; }
        public List<int> PossibleValues { get; set; }

        public bool Contains(int value)
        {
            return PossibleValues.Contains(value);
        }

        public bool Remove(int value)
        {
            return PossibleValues.Remove(value);
        }

        public int RemoveRange(List<int> values)
        {
            return PossibleValues.RemoveAll(value => values.Contains(value));
        }

        public object Clone()
        {
            SudokuCell cloned = new SudokuCell();
            cloned.Value = Value;
            foreach (int possibleValue in PossibleValues)
            {
                cloned.PossibleValues.Add(possibleValue);
            }
            return cloned;
        }

    }
}
