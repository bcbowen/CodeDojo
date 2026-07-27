from typing import List

class Solution:
    def numSpecial(self, mat: List[List[int]]) -> int:
        result = 0

        for row in range(len(mat)):
            for col in range(len(mat[0])): 
                if mat[row][col] == 1 and self.is_special(mat, row, col): 
                    result += 1
                
                
        return result
     
    def is_special(self, mat: List[List[int]], row: int, col: int) -> bool: 
        for check_row in range(len(mat)): 
            if check_row == row: 
                continue
            if mat[check_row][col] == 1: 
                return False
        for check_col in range(len(mat[0])): 
            if check_col == col: 
                continue
            if mat[row][check_col] == 1: 
                return False
        return True 