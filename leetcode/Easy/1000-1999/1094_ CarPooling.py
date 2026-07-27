import pytest 
from typing import List

class Solution:
    def carPooling(self, trips: List[List[int]], capacity: int) -> bool:
        maxDist = -1
        for stop in trips: 
            maxDist = max(maxDist, stop[2])

        path = [0] * (maxDist + 1)

        for folks, fm, to in trips: 
            for i in range(fm, to): 
                path[i] += folks
                if path[i] > capacity: 
                    return False
        return True



"""
Example 1:
Input: trips = [[2,1,5],[3,3,7]], capacity = 4
Output: false

Example 2:
Input: trips = [[2,1,5],[3,3,7]], capacity = 5
Output: true

TC 43
trips = [[2,1,5],[3,5,7]]
capacity = 3
True

"""
@pytest.mark.parametrize("trips, capacity, expected", [
     ([[2,1,5],[3,3,7]], 4, False), 
     ([[2,1,5],[3,3,7]], 5, True), 
     ([[2,1,5],[3,5,7]], 3, True)
])
def test_carPooling(trips: List[List[int]], capacity: int, expected:  bool):
    result = Solution().carPooling(trips, capacity)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__]) 