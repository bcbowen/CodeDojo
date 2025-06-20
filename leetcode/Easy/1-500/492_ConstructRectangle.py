import pytest
from typing import List

class Solution:
    def constructRectangle(self, area: int) -> List[int]:
        result = [] 
        factors = self.get_factors(area)
        min_diff = float('inf')
        for factor in factors:
            if factor[0] < factor[1]: 
                break
            if factor[0] - factor[1] < min_diff: 
                min_diff = factor[0] - factor[1]
                result = factor
        return result
    
    def get_factors(self, num: int) -> List[List[int]]:
        result = [[num, 1]] 
        limit = num
        for i in range(2, limit):
            if i == limit: 
                break
            if num % i == 0: 
                limit = num // i
                result.append([limit, i])
        return result 
"""
Example 1:
Input: area = 4
Output: [2,2]
Explanation: The target area is 4, and all the possible ways to construct it are [1,4], [2,2], [4,1]. 
But according to requirement 2, [1,4] is illegal; according to requirement 3,  [4,1] is not optimal compared to [2,2]. So the length L is 2, and the width W is 2.

Example 2:
Input: area = 37
Output: [37,1]

Example 3:
Input: area = 122122
Output: [427,286]

TC 52
Area: 16
expected [4,4]
"""
@pytest.mark.parametrize("area, expected", [
    (4, [2,2]), 
    (37, [37,1]), 
    (122122, [427,286]), 
    (16, [4,4])
])
def test_constructRectangle(area: int, expected: List[int]):
    result = Solution().constructRectangle(area)
    assert(result == expected)


@pytest.mark.parametrize("num, expected", [
    (4, [[4,1], [2,2]]), 
    (8, [[8,1],[4,2]]), 
    (37, [[37,1]])
])
def test_get_factors(num: int, expected: List[List[int]]): 
    result = Solution().get_factors(num)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])