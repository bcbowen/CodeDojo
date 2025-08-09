import pytest
from typing import List

class Solution:
    def smallestCommonElement(self, mat: List[List[int]]) -> int:
        counts = [0] * 10001
        for row in mat: 
            for col in row:
                counts[col] += 1 
                if counts[col] == len(mat): 
                    return col
        return -1

"""
Example 1:
Input: mat = [[1,2,3,4,5],[2,4,5,8,10],[3,5,7,9,11],[1,3,5,7,9]]
Output: 5

Example 2:
Input: mat = [[1,2,3],[2,3,4],[2,3,5]]
Output: 2
"""
@pytest.mark.parametrize("mat, expected", [
    ([[1,2,3,4,5],[2,4,5,8,10],[3,5,7,9,11],[1,3,5,7,9]], 5),
    ([[1,2,3],[2,3,4],[2,3,5]], 2) 
])
def test_smallestCommonElement(mat: List[List[int]], expected: int):
    result = Solution().smallestCommonElement(mat)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 