from typing import List

import pytest

class Solution:
    def distanceBetweenBusStops(self, distance: List[int], start: int, destination: int) -> int:
        forward = 0 
        backward = 0 

        n = len(distance)
        i = start
        while i != destination: 
            forward += distance[i]
            i = (i + 1) % n

        i = start
        while i != destination: 
            j = len(distance) - 1 if i == 0 else i - 1
            backward += distance[j]
            i = j

        return min(forward, backward)

"""
Example 1:
Input: distance = [1,2,3,4], start = 0, destination = 1
Output: 1
Explanation: Distance between 0 and 1 is 1 or 9, minimum is 1.

Example 2:
Input: distance = [1,2,3,4], start = 0, destination = 2
Output: 3
Explanation: Distance between 0 and 2 is 3 or 7, minimum is 3.
 

Example 3:
Input: distance = [1,2,3,4], start = 0, destination = 3
Output: 4
Explanation: Distance between 0 and 3 is 6 or 4, minimum is 4.

 TC 7: 
 distance = [7,10,1,12,11,14,5,0]
start = 7
destination = 2
expected = 18
"""
@pytest.mark.parametrize("distance, start, destination, expected", [
    ([1,2,3,4], 0, 1, 1), 
    ([1,2,3,4], 0, 2, 3), 
    ([1,2,3,4], 0, 3, 4),
    ([7,10,1,12,11,14,5,0], 7, 2, 17) 
])
def test_distanceBetweenBusStops(distance: List[int], start: int, destination: int, expected: int):
    result = Solution().distanceBetweenBusStops(distance, start, destination)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 