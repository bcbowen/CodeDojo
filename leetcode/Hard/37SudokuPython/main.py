#import pytest 
from typing import List
from modules.sudoku_board import SudokuBoard

class Solution:
    def solveSudoku(self, values: List[List[str]]) -> None:
        board = SudokuBoard.parse(values)

#if __name__ == "__main__":
    #pytest.main([__file__]) 
    
