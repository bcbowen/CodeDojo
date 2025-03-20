import pytest
from collections import deque

class Solution:
    def nearestExit(self, maze: list[list[str]], entrance: list[int]) -> int:
        def is_outside(row: int, col: int) -> bool:
            if row < 0 or row >= len(maze): 
                return True
            if col < 0 or col >= len(maze[0]):
                return True
            return False

        # N E S W 
        directions = [(-1, 0), (0, 1), (1, 0), (0, -1)]

        seen = set()
        queue = deque()
        steps = 0
        queue.append(entrance)
        seen.add(tuple(entrance))
        while queue: 
            for _ in range(len(queue)): 

                row, col = queue.popleft()
                
                for dy, dx in directions: 
                    nextRow = row + dy
                    nextCol = col + dx
                    if is_outside(nextRow, nextCol): 
                        if entrance != [row, col]: 
                            return steps
                    elif maze[nextRow][nextCol] == '.' and not (nextRow, nextCol) in seen: 
                        queue.append([nextRow, nextCol])
                        seen.add((nextRow, nextCol))
            steps += 1
        return -1

"""
Input: maze = [["+","+",".","+"],[".",".",".","+"],["+","+","+","."]], entrance = [1,2]
Output: 1
Explanation: There are 3 exits in this maze at [1,0], [0,2], and [2,3].
Initially, you are at the entrance cell [1,2].
- You can reach [1,0] by moving 2 steps left.
- You can reach [0,2] by moving 1 step up.
It is impossible to reach [2,3] from the entrance.
Thus, the nearest exit is [0,2], which is 1 step away.


Input: maze = [["+","+","+"],[".",".","."],["+","+","+"]], entrance = [1,0]
Output: 2
Explanation: There is 1 exit in this maze at [1,2].
[1,0] does not count as an exit since it is the entrance cell.
Initially, you are at the entrance cell [1,0].
- You can reach [1,2] by moving 2 steps right.
Thus, the nearest exit is [1,2], which is 2 steps away.

Input: maze = [[".","+"]], entrance = [0,0]
Output: -1
Explanation: There are no exits in this maze.
"""
@pytest.mark.parametrize("maze, entrance, expected", [
    ([["+","+",".","+"],[".",".",".","+"],["+","+","+","."]], [1,2], 1), 
    ([["+","+","+"],[".",".","."],["+","+","+"]], [1,0], 2), 
    ([[".","+"]],[0,0], -1)
])
def test_nearestExit(maze: list[list[str]], entrance: list[int], expected: int):
    result = Solution().nearestExit(maze, entrance)
    assert(result == expected)
    

if __name__ == "__main__": 
    pytest.main([__file__])