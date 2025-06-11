import pytest
from typing import List

class Solution:
    def carPooling(self, trips: List[List[int]], capacity: int) -> bool:
        return False

"""
Example 1:
Input: trips = [[2,1,5],[3,3,7]], capacity = 4
Output: false

Example 2:
Input: trips = [[2,1,5],[3,3,7]], capacity = 5
Output: true
"""
@pytest.mark.parametrize("trips, capacity, expected", [
    ([[2,1,5],[3,3,7]], 4), False, 
    ([[2,1,5],[3,3,7]], 5, True)
])
def carPooling(trips: List[List[int]], capacity: int, expected: bool):
    result = Solution().carPooling(trips, capacity)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])