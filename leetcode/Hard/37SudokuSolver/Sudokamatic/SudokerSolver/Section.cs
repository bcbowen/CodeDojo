namespace SudokuSolver
{
    public struct Section
    {
        public Section(int beginRow, int beginColumn, int endRow, int endColumn)
        {
            BeginRow = beginRow;
            BeginColumn = beginColumn;
            EndRow = endRow;
            EndColumn = endColumn;
        }

        public int BeginRow { get; set; }
        public int EndRow { get; set; }

        public int BeginColumn { get; set; }
        public int EndColumn { get; set; }

        private static Section[] _sudokuSections = null;
        public static Section[] SudokuSections
        {
            get
            {
                if (_sudokuSections == null)
                {
                    _sudokuSections = new Section[9];
                    int i = 0;
                    for (int row = 0; row < 7; row += 3)
                    {
                        for (int col = 0; col < 7; col += 3)
                        {
                            Section section = new Section(row, col, row + 2, col + 2);
                            _sudokuSections[i++] = section;
                        }
                    }
                }

                return _sudokuSections;
            }
        }

        public static Section GetSection(int row, int col)
        {
            for (int i = 8; i >= 0; i--)
            {
                if (SudokuSections[i].BeginRow <= row && SudokuSections[i].BeginColumn <= col) return SudokuSections[i];
            }

            throw new ArgumentOutOfRangeException($"Section not found for row {row}, col {col}");
        }
    }
}