import pytest
from typing import List

class Solution:
    
    def permute(self, nums: List[int]) -> List[List[int]]:
        result = []
        def backtrack(vals: List[int]): 
            if len(vals) == len(nums): 
                result.append(vals)
            else: 
                for num in nums: 
                    if not num in vals: 
                        vals.append(num)
                        backtrack(vals.copy())
                        vals.pop()
    
        backtrack([])
        return result

    
"""
Example 1:
Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

Example 2:
Input: nums = [0,1]
Output: [[0,1],[1,0]]

Example 3:
Input: nums = [1]
Output: [[1]]
"""
@pytest.mark.parametrize("nums, expected", [
     ([1,2,3], [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]), 
     ([0,1], [[0,1],[1,0]]), 
     ([1], [[1]])
])
def test_permute(nums: List[int], expected: List[List[int]]):
    result = Solution().permute(nums)
    assert(len(result) == len(expected))
    for group in expected: 
        assert group in result

if __name__ == "__main__":
    pytest.main([__file__]) 