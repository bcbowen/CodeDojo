import pytest
from typing import List

class Solution:
    def isRectangleOverlap(self, rec1: List[int], rec2: List[int]) -> bool:
        r1x1, r1y1, r1x2, r1y2 = rec1
        r2x1, r2y1, r2x2, r2y2 = rec2

        # check if either rect is a line
        if (r1x1 == r1x2 or r1y1 == r1y2 or
            r2x1 == r2x2 or r2y1 == r2y2): 
            return False
        
        return not (r1x2 <= r2x1 or # left 
                    r1y2 <= r2y1 or # bottom 
                    r1x1 >= r2x2 or # right
                    r1y1 >= r2y2    # top
                )


    def isRectangleOverlap1(self, rec1: List[int], rec2: List[int]) -> bool:
        r1x1, r1y1, r1x2, r1y2 = rec1
        r2x1, r2y1, r2x2, r2y2 = rec2
        
        def is_between(v1: int, v2: int, test: int) -> bool: 
            return test > v1 and test < v2
        
        def is_between_2d(x1: int, y1: int, x2: int, y2: int, xt: int, yt: int) -> bool: 
            return is_between(x1, x2, xt) and is_between(y1, y2, yt)
        
        return is_between_2d(r1x1, r1y1, r1x2, r1y2, r2x1, r2y1) or is_between_2d(r1x1, r1y1, r1x2, r1y2, r2x2, r2y2)
    

"""
Example 1:
Input: rec1 = [0,0,2,2], rec2 = [1,1,3,3]
Output: true

Example 2:
Input: rec1 = [0,0,1,1], rec2 = [1,0,2,1]
Output: false

Example 3:
Input: rec1 = [0,0,1,1], rec2 = [2,2,3,3]
Output: false

31: 
rec1 = [7,8,13,15]
rec2 = [10,8,12,20]
Expected = true
"""
@pytest.mark.parametrize("rec1, rec2, expected", [
    ([0,0,2,2], [1,1,3,3], True), 
    ([0,0,1,1], [1,0,2,1], False), 
    ([0,0,1,1], [2,2,3,3], False), 
    ([7,8,13,15], [10,8,12,20], True)
])
def test_isRectangleOverlap(rec1: List[int], rec2: List[int], expected: bool):
    result = Solution().isRectangleOverlap(rec1, rec2)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 