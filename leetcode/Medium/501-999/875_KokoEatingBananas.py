import math
import pytest
from typing import List

class Solution:
    def minEatingSpeed(self, piles: List[int], h: int) -> int:
        
        def check_size(k : int) -> bool: 
            hours_spent = 0
            for pile in piles: 
                hours_spent += math.ceil(pile / k)
                if hours_spent > h: 
                    break
            
            return hours_spent <= h

        pile_max = max(piles)        
        left = 1
        right = pile_max
        while left <= right: 
            mid = (left + right) // 2
            if check_size(mid): 
                right = mid - 1
            else: 
                left = mid + 1

        return left

"""
Example 1:
Input: piles = [3,6,7,11], h = 8
Output: 4

Example 2:
Input: piles = [30,11,23,4,20], h = 5
Output: 30

Example 3:
Input: piles = [30,11,23,4,20], h = 6
Output: 23

TC 19: 
[312884470], 968709470
"""
@pytest.mark.parametrize("piles, h, expected", [
    ([3,6,7,11], 8, 4), 
    ([30,11,23,4,20], 5, 30), 
    ([30,11,23,4,20], 6, 23), 
    ([312884470], 968709470, 1)
])
def test_minEatingSpeed(piles: List[int], h: int, expected: int):
    result = Solution().minEatingSpeed(piles, h)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])