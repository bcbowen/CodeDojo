import pytest
from typing import List



class Solution:
    def findShortestSubArray(self, nums: List[int]) -> int:
        return 3
            
def test_findShortestSubArray(nums: List[int], expected: int):
    result = Solution().findShortestSubArray(nums)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])