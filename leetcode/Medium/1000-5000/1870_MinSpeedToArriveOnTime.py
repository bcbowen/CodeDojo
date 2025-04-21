import math
import pytest
from typing import List

class Solution:
    def minSpeedOnTime(self, dist: List[int], hour: float) -> int:
        def check_speed(speed: int): 
            total_time = 0
            for i in range(len(dist) - 1): 
                total_time += math.ceil(dist[i] / speed)
            total_time += (dist[-1] / speed)

            return total_time <= hour
        
        # the min departure time for a leg is len(leg) - 1
        if hour < len(dist) - 1: 
            return -1
        
        max_speed = 10**7
        left = 1
        right = max_speed
        found = False
        while left <= right: 
            mid = (left + right) // 2
            if check_speed(mid): 
                right = mid - 1
                found = True
            else: 
                left = mid + 1
        return left if found else -1


"""
Example 1:
Input: dist = [1,3,2], hour = 6
Output: 1
Explanation: At speed 1:
- The first train ride takes 1/1 = 1 hour.
- Since we are already at an integer hour, we depart immediately at the 1 hour mark. The second train takes 3/1 = 3 hours.
- Since we are already at an integer hour, we depart immediately at the 4 hour mark. The third train takes 2/1 = 2 hours.
- You will arrive at exactly the 6 hour mark.

Example 2:
Input: dist = [1,3,2], hour = 2.7
Output: 3
Explanation: At speed 3:
- The first train ride takes 1/3 = 0.33333 hours.
- Since we are not at an integer hour, we wait until the 1 hour mark to depart. The second train ride takes 3/3 = 1 hour.
- Since we are already at an integer hour, we depart immediately at the 2 hour mark. The third train takes 2/3 = 0.66667 hours.
- You will arrive at the 2.66667 hour mark.

Example 3:
Input: dist = [1,3,2], hour = 1.9
Output: -1
Explanation: It is impossible because the earliest the third train can depart is at the 2 hour mark.

TC 60: 
dist =
[1,1,100000]
hour =
2.01
Expected
10000000
"""
@pytest.mark.parametrize("dist, hour, expected", [
    ([1,1,100000], 2.01, 10000000), 
    ([1,3,2], 2.7, 3), 
    ([1,3,2], 1.9, -1),
    ([1,3,2], 6, 1), 
    ([1,1], 1, -1)
    
])
def test_minSpeedOnTime(dist: List[int], hour: float, expected: int):
    result = Solution().minSpeedOnTime(dist, hour); 
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])