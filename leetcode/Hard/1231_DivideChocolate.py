import pytest
from typing import List

class Solution:
    def maximizeSweetness(self, sweetness: List[int], k: int) -> int:
        def is_valid

"""
Example 1:
Input: sweetness = [1,2,3,4,5,6,7,8,9], k = 5
Output: 6
Explanation: You can divide the chocolate to [1,2,3], [4,5], [6], [7], [8], [9]

Example 2:
Input: sweetness = [5,6,7,8,9,1,2,3,4], k = 8
Output: 1
Explanation: There is only one way to cut the bar into 9 pieces.

Example 3:
Input: sweetness = [1,2,2,1,2,2,1,2,2], k = 2
Output: 5
Explanation: You can divide the chocolate to [1,2,2], [1,2,2], [1,2,2]
"""
@pytest.mark.parametrize("sweetness, k, expected", [
    ([1,2,3,4,5,6,7,8,9], 5, 6), 
    ([5,6,7,8,9,1,2,3,4], 8, 1), 
    ([1,2,2,1,2,2,1,2,2], 2, 5)
])
def test_maximizeSweetness(sweetness: List[int], k: int, expected: int):
    result = Solution().maximizeSweetness(sweetness, k)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 