import pytest

from enum import Enum
from typing import List

class Direction(Enum):
    """
    An enumeration for cardinal and ordinal directions, 
    with values as [dx, dy] integer lists.
    """
    NORTH = [-1, 0]
    EAST = [0, -1]
    SOUTH = [1, 0]
    WEST = [0, 1]
    
    
    

class Solution:
    # n e s w
    directions = [(-1, 0), (0, -1), (1, 0), (0, 1)]

    # A stop is a space before the destination with a wall on the other side
    def get_stops(self, maze: List[List[int]], destination: List[int]) -> List[List[int]]: 
        stops = [] 


        return stops


    def hasPath(self, maze: List[List[int]], start: List[int], destination: List[int]) -> bool:
        
        
        return False
    
"""
Example 1:
Input: maze = [[0,0,1,0,0],[0,0,0,0,0],[0,0,0,1,0],[1,1,0,1,1],[0,0,0,0,0]], start = [0,4], destination = [4,4]
Output: true
Explanation: One possible way is : left -> down -> left -> down -> right -> down -> right.

Example 2:
Input: maze = [[0,0,1,0,0],[0,0,0,0,0],[0,0,0,1,0],[1,1,0,1,1],[0,0,0,0,0]], start = [0,4], destination = [3,2]
Output: false
Explanation: There is no way for the ball to stop at the destination. Notice that you can pass through the destination but you cannot stop there.

Example 3:
Input: maze = [[0,0,0,0,0],[1,1,0,0,1],[0,0,0,0,0],[0,1,0,0,1],[0,1,0,0,0]], start = [4,3], destination = [0,1]
Output: false
"""
@pytest.mark.parametrize("maze, start, destination, expected", [
    ([[0,0,1,0,0],[0,0,0,0,0],[0,0,0,1,0],[1,1,0,1,1],[0,0,0,0,0]], [0,4], [4, 4], True), 
    ([[0,0,1,0,0],[0,0,0,0,0],[0,0,0,1,0],[1,1,0,1,1],[0,0,0,0,0]], [0,4], [3, 2], False), 
    ([[0,0,0,0,0],[1,1,0,0,1],[0,0,0,0,0],[0,1,0,0,1],[0,1,0,0,0]], [4, 3], [0, 1], False)
])
def test_hasPath(maze: List[List[int]], start: List[int], destination: List[int], expected: bool):
    result = Solution().hasPath(maze, start, destination)
    assert(result == expected)

"""
    ex: 
    . . . . 
    . . G x
    . . . . 
    result: [[1, 1]]

    . . . . 
    . x G x
    . . . . 
    result: []

    . . x . 
    . . G x
    . . . . 
    result: [[1, 1], [2, 2]]

    . . x . 
    . . G .
    . . . . 
    result: [[2, 2]]

"""
@pytest.mark.parametrize("", [
    (), 
])
def test_get_stops(walls: List[List[int]], goal: List[int], expected: List[List[int]]): 
    pass





if __name__ == "__main__": 
    pytest.main([__file__])    