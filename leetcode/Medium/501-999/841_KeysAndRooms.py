import pytest


class Solution:
    def canVisitAllRooms(self, rooms: list[list[int]]) -> bool:
        pass

"""
Example 1:
Input: rooms = [[1],[2],[3],[]]
Output: true
Explanation: 
We visit room 0 and pick up key 1.
We then visit room 1 and pick up key 2.
We then visit room 2 and pick up key 3.
We then visit room 3.
Since we were able to visit every room, we return true.

Example 2:

Input: rooms = [[1,3],[3,0,1],[2],[0]]
Output: false
Explanation: We can not enter room number 2 since the only key that unlocks it is in that room.
"""

def test_canVisitAllRooms(rooms: list[list[int]], expected: bool):
    result = Solution().canVisitAllRooms(rooms)
    assert(result == expected)



if __name__ == "__main__": 
    pytest.main([__file__])