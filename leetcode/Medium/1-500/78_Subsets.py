import pytest
from typing import List

class Solution:
    def subsets(self, nums: List[int]) -> List[List[int]]:
        result = [] 
        
        def backtrack(vals: List[int], index: int, length: int): 
            if len(vals) == length: 
                result.append(vals)
                return 
            for i in range(index, len(nums)): 
                num = nums[i]
                if not num in vals: 
                    vals.append(num)
                    backtrack(vals.copy(), i, length)
                    vals.pop()


        result.append([])
        for i in range(1, len(nums)): 
            backtrack([], 0, i)
        result.append(nums)
        return result

"""
Example 1:
Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

Example 2:
Input: nums = [0]
Output: [[],[0]]

"""
@pytest.mark.parametrize("nums, expected", [
    ([1,2,3], [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]), 
    ([0], [[],[0]])
])
def test_subsets(nums: List[int], expected: List[List[int]]):
    result = Solution().subsets(nums)
    assert(len(expected) == len(result))
    for subset in result: 
        assert subset in expected

if __name__ == "__main__": 
    pytest.main([__file__])