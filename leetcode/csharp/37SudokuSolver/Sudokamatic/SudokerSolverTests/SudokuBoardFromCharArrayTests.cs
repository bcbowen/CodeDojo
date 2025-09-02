using SudokerSolver;

namespace SudokerSolverTests; 

[TestFixture]
public class SudokuBoardFromCharArrayTests
{
    private SudokuBoard? _board = null; 

    [OneTimeSetUp]
    public void Setup()
    {
        char[][] chars =
        {
            new []{'5','3','.','.','7','.','.','.','.'},
            new []{'6','.','.','1','9','5','.','.','.'},
            new []{'.','9','8','.','.','.','.','6','.'},
            new []{'8','.','.','.','6','.','.','.','3'},
            new []{'4','.','.','8','.','3','.','.','1'},
            new []{'7','.','.','.','2','.','.','.','6'},
            new []{'.','6','.','.','.','.','2','8','.'},
            new []{'.','.','.','4','1','9','.','.','5'},
            new []{'.','.','.','.','8','.','.','7','9'}
        };
        _board = SudokuBoard.Create(chars);
    }

    [TestCase(0, 0, 5)]
    [TestCase(0, 1, 3)]
    [TestCase(0, 2, 0)]
    [TestCase(0, 4, 7)]
    [TestCase(2, 1, 9)]
    [TestCase(3, 0, 8)]
    [TestCase(8, 0, 0)]
    [TestCase(8, 4, 8)]
    [TestCase(8, 7, 7)]
    [TestCase(8, 8, 9)]
    public void BoardPopulatedWithExpectedValues(int row, int col, int expected)
    {
        int value = _board.Board[row][col].Value;
        Assert.That(value, Is.EqualTo(expected));
        
    }
}
