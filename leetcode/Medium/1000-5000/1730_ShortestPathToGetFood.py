import ast
import pytest
import os

class Solution:
    def getFood(self, grid: list[list[str]]) -> int:
        q = []
        start = None
        result = -1
        for row in range(len(grid)): 
            for col in range(len(grid[0])): 
                if grid[row][col] == '*':
                    start = (row, col)
                    break
            if start: 
                break
        if not start: 
            return result
        q.append((start, 0))
        # N E S W
        d_row = [-1, 0, 1, 0]
        d_col = [0, 1, 0, -1]
        #visited = []
        #visited.append(start)
        def inbounds(loc: tuple[int, int]) -> bool: 
            if loc[0] < 0 or loc[0] >= len(grid): 
                return False
            if loc[1] < 0 or loc[1] >= len(grid[0]): 
                return False
            return True
           
        while q: 
            current, step = q.pop(0)
                        
            for d in range(4):
                next = ((current[0] + d_row[d], current[1] + d_col[d]))
                if inbounds(next): 
                    if grid[next[0]][next[1]] == '#': 
                        return step + 1
                
                    #if not next in visited and grid[next[0]][next[1]] == 'O': 
                    if grid[next[0]][next[1]] == 'O': 
                        q.append((next, step + 1))
                        #visited.append(next)
                        grid[next[0]][next[1]] = 'V'
        return result


def get_path(file_name: str) -> str: 
    # Get the directory of the current script
    script_dir = os.path.dirname(os.path.abspath(__file__))

    # Construct the full path to the file
    path = os.path.join(script_dir, file_name)
    return path

def test_huge_arrays(): 
    file_name = "1730_78.txt"
    path = get_path(file_name)
    with open(path, "r") as file: 
        grid = ast.literal_eval(file.readline())


    solution = Solution() 
    expected = 198
    result = solution.getFood(grid)
    assert(result == expected)

"""
Input: grid = [["X","X","X","X","X","X"],["X","*","O","O","O","X"],["X","O","O","#","O","X"],["X","X","X","X","X","X"]]
Output: 3
Explanation: It takes 3 steps to reach the food.

Input: grid = [["X","X","X","X","X"],["X","*","X","O","X"],["X","O","X","#","X"],["X","X","X","X","X"]]
Output: -1
Explanation: It is not possible to reach the food.

Input: grid = [["X","X","X","X","X","X","X","X"],["X","*","O","X","O","#","O","X"],["X","O","O","X","O","O","X","X"],["X","O","O","O","O","#","O","X"],["X","X","X","X","X","X","X","X"]]
Output: 6
Explanation: There can be multiple food cells. It only takes 6 steps to reach the bottom food.
"""
@pytest.mark.parametrize("grid, expected", [
    ([["X","X","X","X","X","X"],["X","*","O","O","O","X"],["X","O","O","#","O","X"],["X","X","X","X","X","X"]], 3), 
    ([["X","X","X","X","X"],["X","*","X","O","X"],["X","O","X","#","X"],["X","X","X","X","X"]], -1), 
    ([["X","X","X","X","X","X","X","X"],["X","*","O","X","O","#","O","X"],["X","O","O","X","O","O","X","X"],["X","O","O","O","O","#","O","X"],["X","X","X","X","X","X","X","X"]], 6),
    ([["O","*"],["#","O"]], 2)
])
def test_getFood(grid: list[list[str]], expected: int): 
    solution = Solution() 
    result = solution.getFood(grid)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])