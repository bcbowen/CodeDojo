import pytest
from typing import List


class Solution:
    def areaOfMaxDiagonal(self, dimensions: List[List[int]]) -> int:
        max_diag = 0
        max_area = 0

        def calc_diag(l: int, w: int) -> float: 
            return (l**2 + w**2) ** .5
        
        for l, w in dimensions: 
            diag = calc_diag(l, w)
            if diag > max_diag: 
                max_area = l * w
                max_diag = diag
            elif diag == max_diag: 
                max_area = max(max_area, (l * w))           

        return max_area

"""

Example 1:
Input: dimensions = [[9,3],[8,6]]
Output: 48
Explanation: 
For index = 0, length = 9 and width = 3. Diagonal length = sqrt(9 * 9 + 3 * 3) = sqrt(90) ≈ 9.487.
For index = 1, length = 8 and width = 6. Diagonal length = sqrt(8 * 8 + 6 * 6) = sqrt(100) = 10.
So, the rectangle at index 1 has a greater diagonal length therefore we return area = 8 * 6 = 48.

Example 2:
Input: dimensions = [[3,4],[4,3]]
Output: 12
Explanation: Length of diagonal is the same for both which is 5, so maximum area = 12.

TC 695: 
dimensions =
[[2,6],[5,1],[3,10],[8,4]]
Expected
30

TC 754: 
dimensions =
[[6,5],[8,6],[2,10],[8,1],[9,2],[3,5],[3,5]]
Expected
20
"""
@pytest.mark.parametrize("dimensions, expected", [
    ([[9,3],[8,6]], 48), 
    ([[3,4],[4,3]], 12), 
    ([[2,6],[5,1],[3,10],[8,4]], 30), 
    ([[6,5],[8,6],[2,10],[8,1],[9,2],[3,5],[3,5]], 20)
])
def test_areaOfMaxDiagonal(dimensions: List[List[int]], expected: int):
    result = Solution().areaOfMaxDiagonal(dimensions)
    assert(result == expected)

if __name__ == "__main__":     
    pytest.main([__file__])