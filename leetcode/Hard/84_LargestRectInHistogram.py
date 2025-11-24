import pytest

from typing import List

class Solution:
    def largestRectangleArea(self, heights: List[int]) -> int:
        stack = [-1]
        max_area = heights[0]
        
        for i in range(len(heights)): 
            while stack[-1] != -1 and heights[stack[-1]] >= heights[i]: 
                current_height = heights[stack.pop()]
                current_width = i - stack[-1] - 1
                max_area = max(max_area, current_height * current_width)    
            stack.append(i)

        while stack[-1] != -1: 
            current_height = heights[stack.pop()]
            current_width = len(heights) - stack[-1] - 1
            max_area = max(max_area, current_height * current_width)   

        return max_area

"""
Example 1:
Input: heights = [2,1,5,6,2,3]
Output: 10
Explanation: The above is a histogram where width of each bar is 1.
The largest rectangle is shown in the red area, which has an area = 10 units.

Example 2:
Input: heights = [2,4]
Output: 4
"""
@pytest.mark.parametrize("heights, expected", [
    ([2,1,5,6,2,3], 10), 
    ([2,4], 4)
])
def test_largestRectangleArea(heights: List[int], expected: int):
    result = Solution().largestRectangleArea(heights)
    assert(result == expected)



if __name__ == "__main__":
    pytest.main([__file__]) 