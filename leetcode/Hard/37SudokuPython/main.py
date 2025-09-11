from pathlib import Path
import sys
import argparse
import pytest 
from typing import List
from modules.sudoku_board import SudokuBoard

class Solution:
    def solveSudoku(self, values: List[List[str]]) -> None:
        board = SudokuBoard.parse(values)

def run_pytest(extra_args=None) -> int:
    root = Path(__file__).resolve().parent
    tests_dir = root / "tests"

    # Ensure project root is importable (belt-and-suspenders; keep pytest.ini if you like)
    if str(root) not in sys.path:
        sys.path.insert(0, str(root))

    args = [
        "-q",                  # quieter output
        "-s",                  # show print() output
        "--import-mode=importlib",
        str(tests_dir),
    ]
    if extra_args:
        args.extend(extra_args)
    return pytest.main(args)

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--test", action="store_true", help="Run test suite")
    # Everything after '--' goes straight to pytest (e.g. -k test_sudoku_board)
    parser.add_argument("pytest_args", nargs=argparse.REMAINDER)
    args = parser.parse_args()

    # Your normal program flow…
    # e.g., Solution().solveSudoku(values)

    if args.test:
        code = run_pytest(args.pytest_args)
        raise SystemExit(code)

if __name__ == "__main__":
    main()
    #pytest.main(['./tests']) 
    #pytest.main([__file__]) 
    
